CREATE FUNCTION [dbo].[GetAverageRateById] (@MediaId INT)
RETURNS FLOAT
AS
BEGIN
    DECLARE @AverageRate FLOAT;
    SELECT @AverageRate = AVG(Rate)
    FROM Ratings
    WHERE MediaId = @MediaId;
    RETURN @AverageRate;
END;

GO
CREATE FUNCTION [dbo].[GetLastViewDate](@UserId INT,@MediaId INT)
RETURNS SMALLDATETIME
AS 
BEGIN
	DECLARE @LastView SMALLDATETIME;
	SELECT TOP 1 @LastView=UA.ActionDate 
	FROM UserActions UA
	WHERE UA.TypeAction = 'V'
	AND (UA.MediaId = @MediaId AND UA.UserId=@UserId)
	ORDER BY UA.ActionDate DESC;
	IF @@ROWCOUNT = 0
    SET @LastView = NULL;

	RETURN @LastView;
END;


GO
CREATE FUNCTION [dbo].[GetLikesById](@MediaId INT)
RETURNS INT
AS
BEGIN
  DECLARE @LikeCount INT;
  SELECT @LikeCount = COUNT(*) 
  FROM UserActions UA
  WHERE UA.TypeAction = 'L'
  AND UA.MediaId = @MediaId;
  RETURN @LikeCount;
END;

GO
CREATE FUNCTION [dbo].[GetRecommendedMedia] (@UserId INT)
RETURNS TABLE
AS
RETURN
(
    --Obtener los medios que el usuario ha calificado con una alta puntuación
    WITH UserTopRatedMedia AS (
        SELECT MediaId
        FROM Ratings
        WHERE UserId = @UserId
        AND Rate >= 8 -- Ajusta este valor según tus criterios
    ),
    --Obtener los medios que el usuario ha visto
    UserSeenMedia AS (
        SELECT MediaId
        FROM UserActions
        WHERE UserId = @UserId
        AND TypeAction = 'V' 
    ),
 
    --Recomendar medios similares a los que el usuario ha calificado altamente o visto
    RecommendedMedia AS (
        SELECT DISTINCT m.Id AS MediaId
        FROM Media m
        INNER JOIN UserTopRatedMedia urtm ON m.Id <> urtm.MediaId -- Evita recomendar los medios que ya ha calificado
        INNER JOIN UserSeenMedia usm ON m.Id <> usm.MediaId -- Evita recomendar los medios que ya ha visto
        WHERE m.Id NOT IN (SELECT MediaId FROM Ratings WHERE UserId = @UserId)
    )
    SELECT MediaId
    FROM RecommendedMedia
);

GO
-- Crear la función que devuelve las acciones de un usuario sobre un medio
CREATE FUNCTION [dbo].[GetUserActionsDetails] (@UserId INT, @MediaId INT)
RETURNS TABLE
AS
RETURN
(
    SELECT UA.ActionDate AS FechaDeAccion, 
           UA.TypeAction, 
           M.TypeMedia AS Tipo, 
           M.Title AS Medio, 
		   M.Overview as Description,
           M.AgeRate AS Publico, 
           M.ImagePath, 
           M.PosterImage
    FROM UserActions UA
    INNER JOIN Media M ON M.Id = UA.MediaId
    INNER JOIN Users U ON U.Id = UA.UserId
    WHERE UA.UserId = @UserId 
    AND (@MediaId IS NULL OR UA.MediaId = @MediaId)
);
GO
CREATE PROCEDURE [dbo].[CreateNewUser]
    @Name NVARCHAR(100),
    @Email NVARCHAR(255),
    @Password NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @UserId INT;

    BEGIN TRY
        INSERT INTO Users (Name, Email, Password)
        VALUES (@Name, @Email, @Password);

        SET @UserId = SCOPE_IDENTITY();

        SELECT @UserId AS UserId;  -- Retorna el ID del usuario creado
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO
CREATE PROCEDURE [dbo].[DeleteMediaById](
    @MediaId INT
)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @MediaTitle VARCHAR(MAX);
    SELECT @MediaTitle = Title FROM Media WHERE Id = @MediaId;
    DELETE FROM Media WHERE Id = @MediaId;
    IF @@ROWCOUNT > 0
        SELECT 'Media "' + @MediaTitle + '" eliminado con éxito';
    ELSE
        SELECT 'Media con id ' + CAST(@MediaId AS VARCHAR(10)) + ' no existe';
END;
GO
CREATE PROCEDURE [dbo].[DeleteUser]
    @UserId INT
AS
BEGIN
    BEGIN TRY
        DELETE FROM Users
        WHERE Id = @UserId;
        DELETE FROM UserActions
        WHERE UserId = @UserId;
        DELETE FROM Ratings
        WHERE UserId = @UserId;
    END TRY
    BEGIN CATCH
        RAISERROR('Error al eliminar el usuario', 16, 1);
    END CATCH
END;
GO
CREATE PROCEDURE [dbo].[GetRecommendedMediaForUser]
    @UserId INT
AS
BEGIN
    BEGIN TRY
        SELECT MediaId
        FROM dbo.GetRecommendedMedia(@UserId);
    END TRY
    BEGIN CATCH
        RAISERROR('Error al obtener las recomendaciones de medios', 16, 1);
    END CATCH
END;
GO
CREATE PROCEDURE [dbo].[GetTrendingMovies]
AS
BEGIN
    WITH TrendingMovies AS (
        SELECT TOP 10 UA.MediaId, COUNT(UA.MediaId) AS TrendingRate
        FROM UserActions UA
        INNER JOIN Media ME ON ME.Id = UA.MediaId
        WHERE ME.IsActive = 1 AND UA.TypeAction <> 'H'
        GROUP BY UA.MediaId
        ORDER BY TrendingRate DESC
    )
    SELECT ME.*
    FROM Media ME
    INNER JOIN TrendingMovies TM ON ME.Id = TM.MediaId
    ORDER BY TM.TrendingRate DESC;
END;
GO
CREATE PROCEDURE [dbo].[InsertEpisode]
(
    @Title VARCHAR(255),
    @Overview VARCHAR(MAX),
    @E_Num INT,
    @Duration TIME,
    @ImagePath VARCHAR(255),
    @AddedDate SMALLDATETIME,
    @WatchLink VARCHAR(255),
    @RelaseDate SMALLDATETIME
)
AS
BEGIN
    INSERT INTO Episode
    (
        Title, Overview, E_Num, Duration, ImagePath, AddedDate, WatchLink, RelaseDate
    )
    VALUES
    (
        @Title, @Overview, @E_Num, @Duration, @ImagePath, @AddedDate, @WatchLink, @RelaseDate
    );
END;
GO
CREATE PROCEDURE [dbo].[RegisterMovie] (
    @Title VARCHAR(50) ,
    @OriginalTitle NVARCHAR(50),
    @Overview VARCHAR(MAX) ,
    @ImagePath VARCHAR(255) ,
    @PosterImage VARCHAR(255) ,
    @TrailerLink VARCHAR(255) ,
    @WatchLink VARCHAR(255) ,
    @AddedDate SMALLDATETIME ,
    @RelaseDate SMALLDATETIME ,
    @AgeRate CHAR(8),
    @Duration TIME 
)
AS
BEGIN
    INSERT INTO Media (
        Title,
        OriginalTitle,
        Overview,
        ImagePath,
        PosterImage,
        TrailerLink,
        WatchLink,
        AddedDate,
        TypeMedia,
        RelaseDate,
        AgeRate,
        IsActive
    )
    VALUES (
        @Title,
        @OriginalTitle,
        @Overview,
        @ImagePath,
        @PosterImage,
        @TrailerLink,
        @WatchLink,
        @AddedDate,
        'movie',
        @RelaseDate,
        @AgeRate,
        1 -- IsActive 
    );

    -- Obtener Id de media registrada
    DECLARE @MediaId INT;
    SET @MediaId = SCOPE_IDENTITY();
    INSERT INTO Movie (
        MediaId,
        Duration
    )
    VALUES (
        @MediaId,
        @Duration
    );
END;
GO
CREATE PROCEDURE [dbo].[RegisterRating]
    @UserId INT,
    @MediaId INT,
    @Rate TINYINT,
    @RateDate SMALLDATETIME
AS
BEGIN
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM Ratings WHERE UserId = @UserId AND MediaId = @MediaId)
        BEGIN
            UPDATE Ratings
            SET Rate = @Rate, RateDate = @RateDate
            WHERE UserId = @UserId AND MediaId = @MediaId;
        END
        ELSE
        BEGIN
            INSERT INTO Ratings (UserId, MediaId, Rate, RateDate)
            VALUES (@UserId, @MediaId, @Rate, @RateDate);
        END
    END TRY
    BEGIN CATCH
        RAISERROR('Error al registrar la calificación', 16, 1);
    END CATCH
END;
GO
CREATE PROCEDURE [dbo].[RegisterSerie] (
    @Title VARCHAR(50) ,
    @OriginalTitle NVARCHAR(50),
    @Overview VARCHAR(MAX) ,
    @ImagePath VARCHAR(255) ,
    @PosterImage VARCHAR(255) ,
    @TrailerLink VARCHAR(255) ,
    @WatchLink VARCHAR(255) ,
    @AddedDate SMALLDATETIME ,
    @RelaseDate SMALLDATETIME ,
    @AgeRate CHAR(8),
    @Duration TIME 
)
AS
BEGIN
BEGIN TRANSACTION;
    INSERT INTO Media (
        Title,
        OriginalTitle,
        Overview,
        ImagePath,
        PosterImage,
        TrailerLink,
        WatchLink,
        AddedDate,
        TypeMedia,
        RelaseDate,
        AgeRate,
        IsActive
    )
    VALUES (
        @Title,
        @OriginalTitle,
        @Overview,
        @ImagePath,
        @PosterImage,
        @TrailerLink,
        @WatchLink,
        @AddedDate,
        'series',
        @RelaseDate,
        @AgeRate,
        1 -- IsActive 
    );
	 COMMIT TRANSACTION;
END;
GO
CREATE PROCEDURE [dbo].[UpdateEpisode]
(
    @Id INT,
    @Title VARCHAR(255),
    @Overview VARCHAR(MAX),
    @E_Num INT,
    @Duration TIME,
    @ImagePath VARCHAR(255),
    @WatchLink VARCHAR(255),
    @RelaseDate SMALLDATETIME
)
AS
BEGIN
    UPDATE Episode
    SET
        Title = @Title,
        Overview = @Overview,
        E_Num = @E_Num,
        Duration = @Duration,
        ImagePath = @ImagePath,
        WatchLink = @WatchLink,
        RelaseDate = @RelaseDate
    WHERE Id = @Id;
END;
GO
CREATE PROCEDURE [dbo].[UpdateMovie](
    @MediaId INT,
    @Title VARCHAR(50),
    @OriginalTitle NVARCHAR(50),
    @Overview VARCHAR(MAX),
    @ImagePath VARCHAR(255),
    @PosterImage VARCHAR(255),
    @TrailerLink VARCHAR(255),
    @WatchLink VARCHAR(255) ,
    @RelaseDate SMALLDATETIME,
    @AgeRate CHAR(8) ,
    @Duration TIME 
)
AS
BEGIN
--Actualizar datos de media
    UPDATE Media
    SET Title = @Title,
        OriginalTitle = @OriginalTitle,
        Overview = @Overview,
        ImagePath = @ImagePath,
        PosterImage = @PosterImage,
        TrailerLink = @TrailerLink,
        WatchLink = @WatchLink,
        RelaseDate = @RelaseDate,
        AgeRate = @AgeRate
    WHERE Id = @MediaId;
	--Actualizar datos de tabla Movie
    UPDATE Movie
    SET Duration = @Duration
    WHERE MediaId = @MediaId;
END;
GO
CREATE PROCEDURE [dbo].[UpdateUserInfo]
    @UserId INT,
    @NewName NVARCHAR(100),
    @NewEmail NVARCHAR(255),
    @NewPassword NVARCHAR(255)
AS
BEGIN
    BEGIN TRY
        UPDATE Users
        SET Name = @NewName,
            Email = @NewEmail,
            Password = @NewPassword
        WHERE Id = @UserId;
    END TRY
    BEGIN CATCH
        RAISERROR('Error al actualizar la información del usuario', 16, 1);
    END CATCH
END;
GO




