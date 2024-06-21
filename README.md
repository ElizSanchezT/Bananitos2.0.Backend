# Calzaditos Backend (.NET Core 8)

Este proyecto contiene el código para el Backend de Calzaditos

## Prerrequisitos

Crear una base de datos nueva en SQL Server, luego agregar la cadena de conexión a su archivo secrets.json con esta estructura
>"ConnectionStrings": {
  "CalzaditosDB": "AQUÍ TU CADENA DE CONEXIÓN"
}

**Nota:** No agregar la cadena de conexión al appsettings porque cada quién maneja un servidor de base de datos diferente y porque no es buena práctica guardar información sensible en control de código fuente.

## Flujo de trabajo del código
1. Crear una rama basada en **main** antes de empezar a trabajar
2.  Si se desean hacer cambios en base de datos, se agregará un nuevo script siguiendo la numeración (001.sql, 002.sql, 003.sql... etc.), estos scripts deben estar configurados como "Recurso embebido" o "Embedded Resource", copiando y pegando el script anterior y renombrándolo y editando su contenido es suficiente para que se copie esa propiedad también. Los scripts se ejecutan de manera secuencial al correr la aplicación, solo se ejecutan una vez, por lo que solo se ejecutarán los nuevos scripts añadidos. No se deben editar los scripts que ya pasaron a **main** para garantizar la integridad de la base de datos y que todos tengamos la misma estructura.  Si en su rama local se desea editar un script porque faltó algo o se debe corregir algo, y ya fue ejecutado, debe editarse manualmente la tabla SchemaVersions, para eliminar la entrada que marca el script como ejecutado y se debe revertir los cambios manualmente.
3. Agregar los modelos, repositorios y controladores según la estructura establecida.
4. Una vez terminado el trabajo, hacer un commit con un mensaje descriptivo de sus cambios y luego hacer push su código y crear un Pull Request (PR) hacia **main**.
5. Se recomienda que por lo menos una persona revise el PR antes de hacerle merge a **main**.
6. En caso de conflictos, cada quién es responsable de resolverlo en su rama.

## Pendientes (infraestructura)

1. Agregar Swagger
2. Agregar Autenticación
3. Agregar Logging simple (a archivo de texto)