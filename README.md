Utilizar MVC ASP.NetCore version 6

Para conectarse a la Base de Datos ir al archivo "appsettings.json", cambiar (local) de "Data Source=" por el nombre del Servidor que tenga, y DBUsuario se mantiene si utiliza la Query que esta en el repositorio.

  "ConnectionStrings": {
    "CadenaSQL" : "Data Source=(local); Initial Catalog=DBUsuario;Integrated Security=true"
  }
