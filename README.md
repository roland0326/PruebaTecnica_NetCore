# PruebaTecnica_NetCore
Se plantea el funcionamiento de un parqueadero en el cual se despliegan todos los endpoint pertinentes para su funcionalidad backend

# Componente teorico
1.1. Con tus propias palabras define el concepto de clase, interfaz, método
y objeto. Siéntete libre de utilizar ejemplos cotidianos y por qué no,
fragmentos de código en el lenguaje que prefieras.
# Clase
Es un molde contenedor de ciertos atributos o caracteristicas que identifican una entidad u objeto de nuestra realidad
![image](https://github.com/roland0326/PruebaTecnica_NetCore/assets/69539490/7a011fb1-a82b-403d-afad-c2e565d946ab)

# Interfaz 
  Restriciones de cumpliento que se asignan a una clase para el cumpliento de los metodos nombrados en la interfaz
![image](https://github.com/roland0326/PruebaTecnica_NetCore/assets/69539490/306596ad-150b-4a6e-9cea-7610639f0d92)

# Metodo
Contratos o acciones permitidas en una clase para un proceso especifico
![image](https://github.com/roland0326/PruebaTecnica_NetCore/assets/69539490/01cf4a1b-64cc-4b84-accc-35e9804ee044)

# Objeto
Espacio que se asigna en un sistema de información que tiene un estado y un comportamiento.

## 1.2. ¿Qué es la inyección de dependencias y por qué utilizarla?

La inyeccion de dependencias genera un patron de diseño el cual es utlizado en la programacion orientada a objetos, los cuales dan una para eficaz de contener los
datos y procesarlos de manera escalable.

# 1.3. Un desarrollador Junior hizo la siguiente implementación para establecer una conexión http con un proveedor externo y está pidiendo tu autorización para completar un pull request a desarrollo. ¿Qué comentarios le harías?
![image](https://github.com/roland0326/PruebaTecnica_NetCore/assets/69539490/accd3189-8fac-49e9-9172-5f12835d8532)
R// cuando se maneja los using tenemos una ventaja que estos hacen los cierres automaticos de nuestras conexiones no es neesario la parte del close de cada respuesta; tambien tenener encuenta que se debe contener en un metodo ***ASYNC*** para manejar los ***AWAIT***

# 1.4. ¿Por qué es conveniente utilizar índices en las tablas de bases de datos? ¿Consideras que se deben utilizar en todas las tablas o solo en algunas? ¿Qué consideraciones tendrías en cuenta a la hora de definir un índice para una tabla?
 El indice nos favorece en relaciones rapidas entre otras tablas, tomar la desicion si en todas las tablas es de analizar si la base de datos a crear es una base de datos relacionada o no relacionada. Cuando generamos indices vamos a medida de las consultas acomulando un log el cual se basa en estos y las consultas se vuelven mas optimas en el consumo.
 
 Tener en cuanta que los indices para crearlos se hace en base a datos relacionados o unicos que vaya contener esta tabla para mejorar la busqueda de estos tener en cuenta que un indece tiene un nombre unico en toda la base de datos
 
 # 2. Componente práctico backend
 ## Descripción proceso
 * 1.Descargar la informacion del repositorio
 * 2.En la siguiente ruta vamos a ejecutar el script de creacion de la base de datos con algunos datos de inicialización
 
 - ![image](https://github.com/roland0326/PruebaTecnica_NetCore/assets/69539490/a624a850-bcae-4e06-b5ca-67fe54a08f47)
 - ![image](https://github.com/roland0326/PruebaTecnica_NetCore/assets/69539490/8fc81a88-a14d-439e-95a0-0de5d78e7be8)


 
 
