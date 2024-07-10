# Pasos a seguir para crearlo desde 0 con algunos faltantes 
# Bitacora del 9 de Julio 2024

- [x] Crear conexión con la BD, desde el program.cs
- [x] Añadir cadena de conexión a la db, en el appsettingsdevelopment.json
- [x] Instalar Certificados https
- [x] Instalar herramienta de migraciones `dotnet tool install --global dotnet-ef --version 8.0.6`
- [x] Crear carpeta de Migrations y Seed Data
- [x] Se verifico que todas las entidades estuvieran bien establecidas, tanto las que se usaran como propias, como las que se usaran como foráneas
  - Las que son de 1 a 1, se les agrega la foránea ahí mismo como en products que se le pone el del brand y category
  - Las que son de 1 a muchos, se le agrega la foránea en este caso a la que es de muchos, por ejemplo, en la photo se le pone a la photo la foránea que hará referencia al producto, entonces a la photo se le pone productId
- [x] Crear carpeta de Config, dentro de data para configurar cómo queremos que se comporte nuestra entidad en la bd, esto se puede observar dentro de `ProductConfiguration`
- [x] Se modificó el db context, se agregó la configuración abajo, esta viene para pasarle la configuración que hicimos en el paso anterior
- [x] Crear la migración con `dotnet ef migrations add InitialCreate -p Infrastructure -s API -o Data/Migrations`
- [x] Modificamos hasta casi el final del Program cs, para poder agregar la configuracion que lo que nos permita ,es que cada que se ejecute el `Dotnet watch --no-hot-reload` se ejecuten los cambios en la migracion
- [x] Crear archivos de Seeding
- [x] Ejecutar el seeding
- [x] Dentro del `Program.cs` registrar el UnitOfWork y declarar el uso del automapper
- [x] Se configuro los perfiles de mapeo para ciertas entidades y Dtos
- [x] Probar los metodos de tu controlador
- [x] Terminar métodos de crear en controller/repositories de productos



# Comandos Importantes
- Para remover una migración `dotnet ef migrations remove -p Infrastructure -s API`

- Para agregar una migracion 
`dotnet ef migrations add InitialCreate -p Infrastructure -s API -o Data/Migrations`

# Para Crear un producto

1. Creamos 2 DTOs en Core
2. Creamos los perfiles de mapeo
3. Para poder retornar completo todo, seguimos metodo en Product Repository de Create ProductAsync
- Se obtuvo el producto ya transformado , es decir mapeado
- Se Agrego por completo
- Despues se recupero el id del ultimo
- Ese id sirve para buscar otra vez el prodcuto pero ya mapeado con el metodo anterior
- Se devuelve el Dto
4. Establecimos que iba a regresar cada uno en el repository y en la implementación
- En el controlador solo se manda a llamar el metodo dentro

# Por hacer hoy 10 de Julio
- [x] Crear metodo de edicion de producto
- [x] Checar que cuando se cree un producto no tenga el mismo nombre
- [x] Checar que cuando se cree un producto no tenga descuento mayor a 1 y menor que 0
- [x] Repasar e implementar la paginación
- [ ] Implementar metodo de filtrado junto con la paginación

# Para la paginación (se cambio todo a core)
- Se creo en helpers un PagedList.cs
- Se creo en helpers un PaginationHeader.cs
- Se creo una carpeta llamada Extension en API
- Se creo un archivo llamado HttpExtensions.cs dentro de la carpeta extensions , aquie cambie por append, por si no funciona regresarme y cambiarlo como estaba
- Se creo un archivo llamado ProductParams dentro de la carpeta de Helpers
- Se creo el metodo en las interfaz del producto para devolver los productos paginados  y se implemento en el respositorio
- Se creo un metodo en el controlador, de igual manera para traerme los articulos paginados.

# Para el filtering
- Se modifico el ProductParams, se agregaron los parametros por los cuales se filtraran, en este caso por "brand" o "category"
- Se modifico el ProductRepository , para aplicar los filtros de busqueda dentro de los if, las querys son los que ordenan y lo que estaba antes dentro del parametro del mapping , ahora esta en el return

# Para el ordering
- Se modificara el ProductsParams, se agregara parametro por el cual se ordenara, pero si aplicaremos un switch , se declara nadamas.
- En el repositorio se declara el switch


# Notas pendientes de metodos creados el 10 de Julio
- [ ] Modificar el metodo de update, para que automaticamente la actualizacion de productos.
- [ ] Crear metodo para poder actualizar las fotos.
- Se dejaron instrucciones de como podria ser en el metodo update mencionado anteriormente

# Por hacer días siguientes
- [ ] Implementar el front
- [ ] Crear cascaron pantalla de vista de productos
- [ ] Crear servicios para obtener productos
- [ ] Crear servicios para poder obtener los productos paginados
- [ ] Crear servicios para poder utilizar los filtros

