# MoviesHubAPI

## 1. Descripción  
Este proyecto es acerca de una aplicación web full stack para visualización de contenido de video para el programa Mega-Liderly, el frontend de este proyecto se realizó con Angular 16, el backend con ASP.NET Core 8 y la base de datos con SQL Server, la aplicación se ejecuta en contenedores Docker, un contenedor para la parte del frontend (Angular), otro contenedor para el Backend y otro más para la base de datos, además se utiliza kubernetes para la gestión de estos contenedores, cada uno con su propio Pod y la comunicación entre estos se realiza mediante el uso de servicios de kubernetes.
Este repositorio cuenta con 3 directorios de cada una de las partes que conforman el proyecto (Angular, asp.NET, SQL Server) en el cual cada uno contiene sus propios archivos Dockerfile, .dockerignore y deployment.yaml para la creación del despliegue y ejecución en contenedores.  

### Objetivo  
Crear una aplicación para la visualización de contenido de entretenimiento como películas, series y deportes, y además llevar la aplicación a contenedores para facilitar el despliegue y su escalabilidad.  

## 2. Requerimientos técnicos:  
Docker: Se debe tener un entorno capaz de ejecutar docker y kubernetes para correr la aplicación, puede ser Docker-desktop.  
- Docker-Desktop: es una aplicación que proporciona una forma sencilla y eficiente de desarrollar, probar y ejecutar aplicaciones en contenedores en un entorno local. Está disponible para sistemas operativos Windows y macOS, y actúa como una interfaz de usuario gráfica para Docker, permitiendo a los desarrolladores interactuar con Docker y Kubernetes.  

GIT: Debe tener Instalado GIT si desea clonar el proyecto.  

## 3. Proceso de desarrollo

### Detalles
Docker es una plataforma que permite a los desarrolladores y equipos de TI crear, desplegar y ejecutar aplicaciones en contenedores de manera eficiente y consistente. Su capacidad para empaquetar aplicaciones con todas sus dependencias y su portabilidad hacen que sea una herramienta fundamental en el desarrollo moderno de software, especialmente en desarrollo de microservicios y DevOps y que pueden ser ejecutados en cualquier entorno asegurando su funcionalidad.    

Kubernetes es una plataforma de orquestación de contenedores que automatiza el despliegue, la escalabilidad, y la gestión de aplicaciones en contenedores. Permite gestionar aplicaciones complejas en contenedores en un entorno distribuido de manera eficiente.  

El proceso de desarrollo estuvo compuesto por 5 fases, en las primeras 5 se desarrolló la aplicación en sus fases como Frontend, Backend, SQl Server, Comunicación y testeo, la quinta fase fue la implementación de Docker y Kubernetes al proyecto.  

## 4. ¿Cómo ejecutar la aplicación?

-- Clona el repositorio haciendo ```git clone https://github.com/MoisesReyesOrea/Docker-Kubernetes-Application.git``` o de manera alternativa descargalo como archivo ZIP y descomprimelo en una carpeta.  

-- Instala de los paquetes y módulos requeridos ejecuta: ```npm install``` en la terminal de Visual Studio Code para Angular 16

-- Instala de los paquetes y módulos requeridos para asp.net core:  
```dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.0```  
```dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.0```  
```dotnet add package Microsoft.AspNetCore.App --version 8.0.0```  


-- Ejecuta el servicio de Docker como por ejemplo docker-desktop o minikube   

-- Creación de imágenes Docker, Abre la terminal en la dirección dentro de la carpeta del proyecto Angular y ejecuta el comando ```'docker build -t hub-de-entretenimiento_angularv16:1 .'``` esto creará la imagen con la configuración del archivo Dockerfile para la posterior creación del contenedor en los pods de kubernetes. Hacer lo mismo para la carpeta de ASP.NET con el comando ```'docker build -t aspnetcore8:1 .'``` y SQL Server ```'docker build -t sqlserver:1 .'```  

-- Creación de los Pods Kubernetes, en la misma terminal ejecuta los siguientes comandos ```'kubectl apply -f deployment.yaml'```  ```'kubectl apply -f asp-deployment.yaml'``` ```'kubectl apply -f sql-deployment.yaml'``` , esto creará los pod.  

-- La aplicación ya se estará ejecutando, abre el navegador y ve a la dirección `http://localhost:31000/` la aplicación se ejecutará en este enlace.  


## 5. Explicación  

Página de inicio de sesión, los campos de ingreso de datos cuentan con validaciones que deberán ser cumplidas para habilitar el boton de inicio de sesión y así entrar a la aplicación



Página de inicio de la aplicación aquí se muestran algunas recomendaciónes populares, en la parte de abajo esta la barra de navegación para visitar diferentes páginas y ver distinto contenido.



Pagina de peliculas, aqui se muestran todas las peliculas disponibles en el momento, hay otras páginas similares con contenido distinto como series, eventos deportivos, historial de visitas y favoritos.


### Pruebas Unitarias
Como parte de la calidad del software se realizan los testing correspondientes a los componentes y servicios de la aplicación.
##### Reporte Code Coverage:



### Conexión con API REST desarrollada en ASP.NET Core 8 para acceder a base de datos realizada en SQL Server  
**NOTA: La carpeta que contiene el proyecto de la API está en el siguiente enlace: [https://github.com/MoisesReyesOrea/Docker-Kubernetes-Application/tree/main/HubDeEntretenimientoMegaLiderlyBackend](https://github.com/MoisesReyesOrea/Docker-Kubernetes-Application/tree/main/HubDeEntretenimientoMegaLiderlyBackend)**

En la siguiente imagen se muestra la página login de la interfaz en Angular conectada a la API

Si el usuario y contraseña son correctas devuelve mensaje 'Sesión iniciada correctamente'



Si el usuario ingresado no existe en la base de datos se devuelve un error y un mensaje de 'Usuario no registrado'.



## 6. Base de datos normalizada (Diagrama).



## 7. Documentación de API ASP.NET Core 8 - Swagger

Se utilizó Swagger para documentar y probar cada funcion de las APIs:


## 8. Archivos de configuración de ambientes, Docker y Kubernetes.

Los archivos Docker y .yaml se encuentran dentro de cada carpeta con la aplicación correspondiente. aquí los accesos directos:



## 9. Mejoras a futuro.

La aplicación cuenta con los archivos necesarios para generar las imágenes, contenedores y pod de kubernetes, pero aún no está desplegada en algún servidor para que otros usuarios puedan utilizarla, está en proceso de desarrollo, una mejora puede ser el despliegue de la aplicación en un servidor.  

La configuración de kubernetes está con especificaciones para dev, para desplegar será necesario contar con las especificaciones que deberá tener en un ambiente de producción.  

## 10. Problemas conocidos.

1. Problemas de Permisos  
Descripción: Los contenedores de Docker pueden tener problemas de permisos, especialmente al intentar acceder a archivos o directorios en el sistema host.  
Solución: Asegúrate de configurar los volúmenes correctamente y ajustar los permisos de los archivos en el host para que el usuario dentro del contenedor tenga acceso. También, puedes ejecutar contenedores con diferentes usuarios utilizando la opción --user en Docker.  

2. Problemas de Red y Conectividad  
Descripción: La configuración de red en Docker puede ser compleja, y es común enfrentarse a problemas donde los contenedores no pueden comunicarse entre sí o con el exterior.  
Solución: Verifica la configuración de red y asegúrate de que los contenedores estén conectados a la red correcta. Usa docker network para inspeccionar y administrar redes. En algunos casos, puede ser necesario crear redes personalizadas.  

3. Acumulación de Imágenes y Contenedores Antiguos  
Descripción: Docker no limpia automáticamente las imágenes, contenedores, volúmenes o redes no utilizados, lo que puede llevar a un uso innecesario de espacio en disco.  
Solución: Usa comandos como docker system prune para limpiar recursos no utilizados, docker image prune para eliminar imágenes sin contenedores asociados, y docker volume prune para limpiar volúmenes no utilizados.  

## 11. Sprint Review
**¿Qué salio bien?**  
- La ejecución de la aplicación dentro de los contenedores fue completamente funcional .  

**¿Qué puedo hacer diferente?**
- Se pudieran crear servicios, organizar mejor los componentes y modulos para reutilizar de una mejor manera el código, ademas de que se da una mejor eficiencia y facilidad de escalamiento a la aplicación.  

**¿Qué no salio bien ?**  
- Al momento de implementar los contenedores en pods de kubernetes la ejecución de las aplicaciones y el acceso a ellas no fue como esperaba, me enfrente a problemas de comunicación y acceso a las mismas.   
