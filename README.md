# MoviesHubAPI

## 1. Descripción  
Este proyecto es acerca de una aplicación web full stack para visualización de contenido de video para el programa Mega-Liderly, el frontend de este proyecto se realizó con Angular 16, el backend con ASP.NET Core 8 y la base de datos con SQL Server, la aplicación se ejecuta en contenedores Docker, un contenedor para la parte del frontend (Angular), otro contenedor para el Backend y otro más para la base de datos, además se utiliza kubernetes para la gestión de estos contenedores, cada uno con su propio Pod y la comunicación entre estos se realiza mediante el uso de servicios de kubernetes.
Este repositorio cuenta con 3 directorios de cada una de las partes que conforman el proyecto (Angular, asp.NET, SQL Server) en el cual cada uno contiene sus propios archivos Dockerfile, .dockerignore y deployment.yaml para la creación del despliegue y ejecución en contenedores.  

### Objetivo  
Crear una aplicación para la visualización de contenido de entretenimiento como películas, series y deportes, y además llevar la aplicación a contenedores para facilitar el despliegue y su escalabilidad.  
### Librerias utilizadas 
  #### Dependencias c#

Este proyecto utiliza los siguientes paquetes NuGet:

- **BCrypt.Net-Next (4.0.3)**: Una implementación en .NET de la función de hash de contraseñas BCrypt para el almacenamiento seguro de contraseñas.

- **Microsoft.AspNetCore.Authentication.JwtBearer**: Middleware que permite la autenticación mediante JWT (JSON Web Token) en aplicaciones ASP.NET Core.

- **Microsoft.EntityFrameworkCore.SqlServer (8.0.7)**: El proveedor de Entity Framework Core para SQL Server, facilitando las operaciones de base de datos con SQL Server.

- **Swashbuckle.AspNetCore (6.7.0)**: Un conjunto de herramientas Swagger para documentar APIs Web de ASP.NET Core, facilitando a los desarrolladores la comprensión e interacción con la API.

  #### Dependencias Angular
    - **SwiperJS**: Librería para crear deslizadores y carruseles táctiles con transiciones suaves. Utilizada para implementar galerías de imágenes y presentaciones interactivas.
    - **PrimeNG**: Colección de componentes UI para Angular. Proporciona una amplia gama de elementos reutilizables como tablas, gráficos y diálogos, facilitando la creación de interfaces de usuario atractivas y funcionales.
## 2. Requerimientos técnicos:  
Docker: Se debe tener un entorno capaz de ejecutar docker y kubernetes para correr la aplicación, puede ser Docker-desktop.  
- Docker-Desktop: es una aplicación que proporciona una forma sencilla y eficiente de desarrollar, probar y ejecutar aplicaciones en contenedores en un entorno local. Está disponible para sistemas operativos Windows y macOS, y actúa como una interfaz de usuario gráfica para Docker, permitiendo a los desarrolladores interactuar con Docker y Kubernetes.  

- GIT: Debe tener Instalado GIT si desea clonar el proyecto.
- SDK de .NET para compilacion y a su vez para crear imagen
- Node instalado apartir de una version 20.1.13  de igual manera

## 3. Proceso de desarrollo

### Detalles
Docker es una plataforma que permite a los desarrolladores y equipos de TI crear, desplegar y ejecutar aplicaciones en contenedores de manera eficiente y consistente. Su capacidad para empaquetar aplicaciones con todas sus dependencias y su portabilidad hacen que sea una herramienta fundamental en el desarrollo moderno de software, especialmente en desarrollo de microservicios y DevOps y que pueden ser ejecutados en cualquier entorno asegurando su funcionalidad.    

Kubernetes es una plataforma de orquestación de contenedores que automatiza el despliegue, la escalabilidad, y la gestión de aplicaciones en contenedores. Permite gestionar aplicaciones complejas en contenedores en un entorno distribuido de manera eficiente.  

El proceso de desarrollo estuvo compuesto por 4 fases, en las primeras 4 se desarrolló la aplicación en sus fases como Frontend, Backend, SQl Server y testeo, la quinta fase fue la implementación de Docker y Kubernetes al proyecto.  

## 4. ¿Cómo ejecutar la aplicación?
  ### Clonar repositorio de frontEnd
-- Clona el repositorio haciendo ```git clone https://github.com/EderGodinez/MovieHub``` o de manera alternativa descargalo como archivo ZIP y descomprimelo en una carpeta.  
-- Instala de los paquetes y módulos requeridos ejecuta: ```npm install``` en la terminal de Visual Studio Code para Angular 16
  ### Clonar repositorio de Backed
-- Instala de los paquetes y módulos requeridos para asp.net core:  
```dotnet restore```  
### 

-- Ejecuta el servicio de Docker como por ejemplo docker-desktop o minikube   

-- Creación de imágenes Docker, Abre la terminal en la dirección dentro de la carpeta del proyecto Angular y ejecuta el comando ```'docker build -t moviehub .'``` esto creará la imagen con la configuración del archivo Dockerfile para la posterior creación del contenedor en los pods de kubernetes. Hacer lo mismo para la carpeta de ASP.NET con el comando ```'docker build -t apimoviehub .'```.

-- Creación de los Pods Kubernetes, en la misma terminal ejecuta los siguientes comandos ```'kubectl apply -f deployment.yaml'```  ```'kubectl apply -f configMap.yaml'```, esto creará los pod.  

-- La aplicación ya se estará ejecutando, abre el navegador y ve a la dirección `http://localhost:80/` la aplicación se ejecutará en este enlace.  

## 5. Explicación  

Página de inicio de sesión, los campos de ingreso de datos cuentan con validaciones que deberán ser cumplidas para habilitar el boton de inicio de sesión y así entrar a la aplicación



Página de inicio de la aplicación aquí se muestran algunas recomendaciónes populares, en la parte de abajo esta la barra de navegación para visitar diferentes páginas y ver distinto contenido.



Pagina de peliculas, aqui se muestran todas las peliculas disponibles en el momento, hay otras páginas similares con contenido distinto como series, eventos deportivos, historial de visitas y favoritos.


### Pruebas Unitarias
Como parte de la calidad del software se realizan los testing correspondientes a los componentes y servicios de la aplicación.
##### Reporte Code Coverage:
![Coverage](https://github.com/EderGodinez/APICSharp/blob/main/public/code_coverage_stats.png)
##### Reporte de Testing:
![testing](https://github.com/EderGodinez/APICSharp/blob/main/public/testing.png)

### Imagenes de aplicacion 
### Desktop
![Search movie](/public/Busqueda.png)
![Movie Details](/public/Detalles_Pelicula.png)
![Home](/public/Inicio.png)
![Login](/public/login.png)
![Login form Validated](/public/login_validado.png)
![Favorite Page](/public/Pagina_Favoritos.png)
![Register form Validated](/public/registro_validado.png)
![Register](/public/registro.png)
### Mobile view
![Movie Details](/public/mobile_details.png)
![Movies](/public/mobile_view.png)
![Login](/public/mobile_login.png)



## 6. Base de datos normalizada (Diagrama).
![Login](/DB/DiagramaDB.png)


## 7. Documentación de API ASP.NET Core 8 - Swagger

Se utilizó Swagger para documentar y probar cada funcion de las APIs:
![Login](/public/swagger.png)

## 9. Mejoras a futuro.

La aplicación cuenta con los archivos necesarios para generar las imágenes, contenedores y pod de kubernetes, pero de igual manera se debe de considerar muchas medias de seguridad en cuanto a el uso de redes y ademas de servicios para asegurar de la mejor manera el deploy sin arriesgas credenciales importantes

La configuración de kubernetes está con especificaciones para llevar a cabo pruebas unicamente en local, para desplegar será necesario contar con las especificaciones que deberá tener en un ambiente de producción.  

## 10. Problemas conocidos.

1. Problemas de en el manejo de EntityFramework  
Descripción: Los contenedores de Docker pueden tener problemas de permisos, especialmente al intentar acceder a archivos o directorios en el sistema host.  
Solución: Llevar un control y analisis para que las consultas y demas sean lo mas simples posibles con el uso de store-procedures.  

2.- Problemas para conexion con los pods en local
Solucion : en proceso

## 11. Sprint Review
**¿Qué salio bien?**  
- La ejecución de la aplicación dentro de los contenedores fue completamente funcional , ademas de aplicacion seguridad a rutas importantes a la API REST .  

**¿Qué puedo hacer diferente?**
- Se pudieran crear servicios, organizar mejor los componentes y modulos para reutilizar de una mejor manera el código, ademas de que se da una mejor eficiencia y facilidad de escalamiento a la aplicación a demas de implementar seguridad en la parte de la aplicacion frontend.  

**¿Qué no salio bien ?**  
- Poder conectarme hacia los pods y poder realizar pruebas del deploy y verificar su correcto funcionamiento.   
