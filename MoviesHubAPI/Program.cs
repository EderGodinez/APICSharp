
using EntityFrameworkExample.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MoviesHubAPI.Helpers;
using MoviesHubAPI.Services;
using MoviesHubAPI.Services.Files;
using MoviesHubAPI.Services.MovieS;
using MoviesHubAPI.Services.Series;
using MoviesHubAPI.Services.Users;
using System.Reflection;
using System.Text;


namespace MoviesHubAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            var builder = WebApplication.CreateBuilder(args);
            //Se agrega el Context para injearlo en los servicios
            builder.Services.AddTransient<IContextDB, ContextDB>();
            //Se agregan servicios necesarios para el funcionamiento de la API
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IFilesService,FilesService >();
            builder.Services.AddTransient<IMovieService, MovieService>();
            builder.Services.AddTransient<ISerieService, SerieService>();
            builder.Services.AddScoped<IAuthHelpers, AuthHelpers>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            // Add services to the container.
            builder.Services.AddDbContext<ContextDB>(options =>
            {
                
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddAuthentication(cfg => {
                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8
                        .GetBytes(builder.Configuration["ApplicationSettings:JWT_Secret"] ?? String.Empty)
                    ),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
            
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            }); 
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(docs => {
                docs.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieHub-Docs", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                docs.IncludeXmlComments(xmlPath);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(docs =>
                {
                    docs.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieHub docs v1");
                });
            }
            
            app.UseHttpsRedirection(); 
            
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
