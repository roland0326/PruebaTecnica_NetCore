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
R// cuando se maneja los using tenemos una ventaja que estos hacen los cierres automaticos de nuestras conexiones no es neesario la parte del close de cada respuesta; tambien tenener encuenta que se debe contener en un metodo ASYNC para manejar los AWAIT
