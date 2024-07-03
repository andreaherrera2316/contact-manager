# Contact Management

Este proyecto implementa una aplicación de gestión de contactos utilizando archivos JSON para persistencia. La arquitectura está diseñada con flexibilidad y facilidad de extensión en mente.

## Características

- **Flexibilidad**: Utiliza Clean Architecture para separar lógica de negocio de detalles de implementación.
- **Persistencia**: Almacena contactos en archivos JSON para fácil manejo y portabilidad.
- **Extensibilidad**: Interfaces y patrones permiten agregar nuevas funcionalidades fácilmente.
- **Validaciones**: Implementa validaciones personalizadas para asegurar datos correctos.
- **Manejo de Errores**: Manejo robusto de errores para asegurar la estabilidad de la aplicación.

## Menú de Contactos:

1. Agregar contacto: Permite ingresar y validar un nuevo contacto para ser añadido al sistema.
2. Buscar contacto: Permite buscar un contacto por nombre o número de teléfono en los registros existentes.
3. Listar contactos: Muestra todos los contactos actualmente almacenados en el sistema.
4. Eliminar contacto: Permite eliminar un contacto existente de los registros, ofreciendo opciones de reversión.
5. Guardar contactos: Persiste todos los contactos agregados o modificados en archivos JSON en el sistema de archivos.
6. Cargar contactos: Carga todos los contactos almacenados previamente desde los archivos JSON en el sistema de archivos.
7. Revertir Contactos: Permite deshacer cambios no guardados, restaurando los contactos a su estado previo a la última operación de guardado.
8. Cambios No Guardados: Muestra los cambios realizados desde la última operación de guardado, permitiendo revisar y confirmar la reversión o guardado.
9. Salir: Finaliza la aplicación.

Estas funcionalidades interactúan para permitir la gestión completa de contactos, desde la creación hasta la persistencia y la reversión de cambios.

## Extensión

El proyecto está diseñado para ser fácilmente extendible:

- **Nuevas Funcionalidades**: Agregue nuevas características implementando interfaces existentes.
- **Persistencia Personalizada**: Cambie el repositorio de contactos a una base de datos u otro medio con mínimos cambios.
- **Interfaz de Usuario**: Añada nuevas opciones al menú o mejore la interacción con el usuario.

## Requisitos

- .NET 8
- IDE compatible con C#
