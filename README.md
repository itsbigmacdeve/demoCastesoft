# Pasos a seguir para crearlo desde 0, con algunos faltantes

- [ ] Crear conexión con la BD, desde el program.cs
- [ ] Añadir cadena de conexión a la db, en el appsettingsdevelopment.json
- [ ] Instalar Certificados https
- [ ] Instalar herramienta de migraciones `dotnet tool install --global dotnet-ef --version 8.0.6`
- [ ] Crear carpeta de Migrations y Seed Data
- [ ] Se verifico que todas las entidades estuvieran bien establecidas, tanto las que se usaran como propias, como las que se usaran como foráneas
  - Las que son de 1 a 1, se les agrega la foránea ahí mismo como en products que se le pone el del brand y category
  - Las que son de 1 a muchos, se le agrega la foránea en este caso a la que es de muchos, por ejemplo, en la photo se le pone a la photo la foránea que hará referencia al producto, entonces a la photo se le pone productId
- [ ] Crear carpeta de Config, dentro de data para configurar cómo queremos que se comporte nuestra entidad en la bd, esto se puede observar dentro de `ProductConfiguration`
- [ ] Se modificó el db context, se agregó la configuración abajo, esta viene para pasarle la configuración que hicimos en el paso anterior
- [ ] Crear la migración con `dotnet ef migrations add InitialCreate -p Infrastructure -s API -o Data/Migrations`
- [ ] Modificamos hasta casi el final del Program cs, para poder agregar la configuracion que lo que nos permita ,es que cada que se ejecute el `Dotnet watch --no-hot-reload` se ejecuten los cambios en la migracion
- [ ] Crear archivos de Seeding
- [ ] Ejecutar el seeding
- [ ] Dentro del `Program.cs` registrar el UnitOfWork y declarar el uso del automapper
- [ ] Configurar los profiles del automapper
- [ ] Probar los metodos de tu controlador
- [ ] Terminar métodos en controller/repositories de productos


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

