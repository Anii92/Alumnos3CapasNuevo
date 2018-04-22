# Alumnos3Capas
Está aplicación está hecha con una arquitectura de tres capas y un proyecto de windows form para la interfaz de usuario.
La aplicación permite realizar las siguientes acciones:
 - Crear un estudiante.
 - Leer los estudiantes almacenados.
 - Borrar un estudiante.
 - Cambiar de idioma.
 
El usuario de la aplicación podrá decidir donde crear/leer/borrar el estudiante:
 - Base de datos (mediante sentencias SQL o Stored Procedure).
 - Fichero de texto.
 - Fichero de json.
 - Fichero de xml.
# Arquitectura
La arquitectura que se ha utilizado es la de tres capas:
- Capa de presentación: se encuentra todo lo relaciando con la interfaz del usuario. Está capa solo se comunica con la capa de negocio.
- Capa de negocio: en está capa es donde se realiza toda la lógica de la aplicación. Se comunica con la capa de presentación y con la capa de datos.
- Capa de datos (dao): es la responsable de acceder a los datos que están almacenados en la base datos y los ficheros. Sólo se comunica con la capa de negocio.

# Patrones
Los patrones que se han utilizado son los siguientes:
- Adapter: este patrón permite que dos interfaces distintas puedan trabajar. 
  En la aplicación se ha utilizado para poder trabajar tanto con la libreria de logs Log4Net y Seriolog.
- Singleton: permite que solo se instancie una vez una clase.
  Se ha utilizado para leer el contenido de los ficheros json y xml cuando se arranca la aplicación.
- Factoria: es un patrón creacional y permeti construir una jerarquía de clases.
  Se utiliza en la capa de datos para decidir que cuál clase utilizar para acceder a los datos.

# Variables de entorno
Algunos datos de la aplicación, como por ejemplo la cadena de conexión a la base de datos, se han guardado en una variable de entorno. El nombre de la variable de entorno se ha guardado en el fichero app.config.

# Test
Se han realizado dos tipos de test:
- Test unitarios: los test unitarios mockan las dependencias. 
 Para hacer los mocks se ha utilizado NMock3.
- Test de integración: son los test de las funcionalidades.

# Code coverage
