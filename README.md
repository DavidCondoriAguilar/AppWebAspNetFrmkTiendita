Documentación del CRUD - Categoría y Producto
Introducción
Este documento detalla las operaciones CRUD (Create, Read, Update, Delete) implementadas para las entidades Categoría y Producto en la aplicación MarketPeru utilizando el patrón de diseño MVC (Model-View-Controller). Las operaciones CRUD permiten la gestión eficiente de datos relacionados con categorías de productos en la plataforma.

Tecnologías Utilizadas
Backend:

C# (.NET Framework)
Entity Framework
ASP.NET  MVC
Frontend:

Razor Views (MVC Views)
Bootstrap (para estilos)
Estructura del Proyecto
El proyecto está organizado de la siguiente manera:

Backend (MVC):
Controllers:

CategoriaController.cs: Gestiona las operaciones CRUD para la entidad Categoría.
ProductoController.cs: Gestiona las operaciones CRUD para la entidad Producto.
Models:

Categoria.cs: Define la estructura de la entidad Categoría.
Producto.cs: Define la estructura de la entidad Producto.
Views:

Categoría:

Index.cshtml: Lista de categorías.
Create.cshtml: Formulario para crear una nueva categoría.
Edit.cshtml: Formulario para editar una categoría existente.
Details.cshtml: Detalles de una categoría específica.
Delete.cshtml: Confirmación de eliminación de una categoría.
Producto:

Index.cshtml: Lista de productos.
Create.cshtml: Formulario para crear un nuevo producto.
Edit.cshtml: Formulario para editar un producto existente.
Details.cshtml: Detalles de un producto específico.
Delete.cshtml: Confirmación de eliminación de un producto.
Operaciones CRUD
Categoría
Crear Categoría

Vista: Create.cshtml
Método HTTP: POST
Funcionalidad: Permite al usuario ingresar los detalles de una nueva categoría y enviar el formulario para crearla.
Listar Categorías

Vista: Index.cshtml
Método HTTP: GET
Funcionalidad: Muestra todas las categorías existentes con opciones para editar, ver detalles o eliminar cada una.
Editar Categoría

Vista: Edit.cshtml
Método HTTP: POST
Funcionalidad: Permite al usuario modificar los detalles de una categoría existente y guardar los cambios.
Ver Detalles de Categoría

Vista: Details.cshtml
Método HTTP: GET
Funcionalidad: Muestra información detallada de una categoría específica sin posibilidad de edición.
Eliminar Categoría

Vista: Delete.cshtml
Método HTTP: POST
Funcionalidad: Permite al usuario confirmar la eliminación de una categoría específica.
Producto
Crear Producto

Vista: Create.cshtml
Método HTTP: POST
Funcionalidad: Permite al usuario ingresar los detalles de un nuevo producto y enviar el formulario para crearlo.
Listar Productos

Vista: Index.cshtml
Método HTTP: GET
Funcionalidad: Muestra todos los productos existentes con opciones para editar, ver detalles o eliminar cada uno.
Editar Producto

Vista: Edit.cshtml
Método HTTP: POST
Funcionalidad: Permite al usuario modificar los detalles de un producto existente y guardar los cambios.
Ver Detalles de Producto

Vista: Details.cshtml
Método HTTP: GET
Funcionalidad: Muestra información detallada de un producto específico sin posibilidad de edición.
Eliminar Producto

Vista: Delete.cshtml
Método HTTP: POST
Funcionalidad: Permite al usuario confirmar la eliminación de un producto específico.
Consideraciones Adicionales
Se utiliza Razor Views para la generación automática de vistas MVC, lo que simplifica el desarrollo frontend al vincular las operaciones CRUD directamente con las acciones del controlador.
La validación de datos se realiza tanto en el frontend (Razor Views) como en el backend (ASP.NET Core) para garantizar la integridad de los datos y la seguridad de la aplicación.
Se recomienda implementar autenticación y autorización para controlar el acceso a las operaciones CRUD según el rol del usuario.
Conclusiones
Este documento ha proporcionado una visión general de las operaciones CRUD implementadas para las entidades Categoría y Producto en la aplicación MarketPeru utilizando el patrón de diseño MVC. Estas operaciones permiten una gestión eficiente y segura de los datos relacionados con categorías de productos, facilitando así una experiencia robusta y escalable para los usuarios finales.

![3](https://github.com/DavidCondoriAguilar/AppWebAspNetFrmkTiendita/assets/103283145/28e6de17-5aca-4784-8d23-02bdceca2041)
![2](https://github.com/DavidCondoriAguilar/AppWebAspNetFrmkTiendita/assets/103283145/2aa346b1-2673-4aa5-a376-fb2431b050d1)
![1](https://github.com/DavidCondoriAguilar/AppWebAspNetFrmkTiendita/assets/103283145/cd847c89-cf72-4381-9864-181d7ae3b4d4)
![5](https://github.com/DavidCondoriAguilar/AppWebAspNetFrmkTiendita/assets/103283145/c60c7190-797a-491a-ba87-697ed3f9ae14)
![4](https://github.com/DavidCondoriAguilar/AppWebAspNetFrmkTiendita/assets/103283145/92192f49-b1e4-4198-96c7-4f93839ca425)
