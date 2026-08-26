TP Programación II – API REST de Mascotas

Autor: Esteban Soria
Curso: 2B
Materia: Programación II
Trabajo Práctico: API REST C# / ASP.NET Core Web API

**Descripción**

Este repositorio contiene una API REST desarrollada en C# con ASP.NET Core Web API, cuyo objetivo es gestionar mascotas (perros y gatos) mediante operaciones CRUD básicas y algunas consultas adicionales.

El proyecto implementa una jerarquía de clases con herencia:

Mascota (clase abstracta): contiene los atributos comunes a toda mascota (Id, Nombre, Edad).
Perro: hereda de Mascota y agrega el atributo Raza.
Gato: hereda de Mascota y agrega el atributo Color.

Toda la información se maneja en memoria, mediante una lista estática dentro del controller, por lo que no se requiere base de datos. Al iniciar la aplicación, la lista se carga con cuatro mascotas para facilitar pruebas.


**Endpoints**
CRUD básico
Método HTTP	    Endpoint	        Acción
GET	            /Mascota	        Obtener todas las mascotas
GET	            /Mascota/{id}	    Obtener una mascota por su Id
POST	        /Mascota/perro	    Registrar un nuevo perro
POST	        /Mascota/gato	    Registrar un nuevo gato
PUT	            /Mascota/perro/{id}	Modificar un perro existente
PUT	            /Mascota/gato/{id}	Modificar un gato existente
DELETE	        /Mascota/{id}	    Eliminar una mascota

Endpoints de desafío
Método HTTP	    Endpoint	                Acción
GET	         /Mascota/mayores-a/{edad}	    Devuelve todas las mascotas cuya edad sea mayor al valor recibido
GET	         /Mascota/tipo/{tipo}	        Devuelve las mascotas filtradas por tipo (perro o gato)


**Manejo de respuestas HTTP**
La API responde con los códigos de estado correspondientes según la operación realizada:

200 OK – Consultas exitosas (GetAll, GetById, filtros por edad/tipo).
201 Created – Al registrar un nuevo perro o gato, incluyendo la URL del recurso creado.
204 No Content – Al modificar una mascota existente (PUT).
404 Not Found – Cuando la mascota buscada, a modificar o a eliminar no existe.
400 Bad Request – Cuando se consulta un tipo de mascota inválido en /Mascota/tipo/{tipo}.

**Pruebas**
El proyecto fue probado íntegramente desde Swagger, verificando:

*Obtención de la lista completa de mascotas.
*Búsqueda de una mascota existente y una inexistente.
*Registro de nuevos perros y gatos.
*Modificación de mascotas existentes.
*Eliminación de mascotas.
*Consulta de mascotas mayores a una edad determinada.
*Consulta de mascotas filtradas por tipo.

**Tecnologías utilizadas**
C#
ASP.NET Core Web API
Swagger (documentación y pruebas de endpoints)