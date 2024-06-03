using Microsoft.AspNetCore.Mvc;
using ABM_Usuario.Datos;
using ABM_Usuario.Models;


namespace ABM_Usuario.Controllers
{
    public class MantenedorController : Controller
    {

        UsuarioDatos _UsuarioDatos = new UsuarioDatos();

        public IActionResult Listar()
        {
            //LA VISTA MOSTRARA UNA LISTA DE CONTACTOS
            var oLista = _UsuarioDatos.Listar();

            return View(oLista);
        }
        public IActionResult Guardar()
        {
            //METODO SOLO DEVUELVE LA VISTA
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(UsuarioModel oUsuario)
        {
            //METODO RECIBE EL OBJETO PARA GUARDARLO EN LA BD
            if(!ModelState.IsValid)
                return View();

            var respuesta = _UsuarioDatos.Guardar(oUsuario);

            if (respuesta)
                return RedirectToAction("Listar");
            else 
                return View();

        }

        public IActionResult Editar(int IdUsuario)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ousuario = _UsuarioDatos.Obtener(IdUsuario);
            return View(ousuario);
        }

        [HttpPost]
        public IActionResult Editar(UsuarioModel oUsuario)
        {
            //METODO RECIBE EL OBJETO PARA EDITARLO DE LA BD
            if (!ModelState.IsValid)
                return View();

            var respuesta = _UsuarioDatos.Editar(oUsuario);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdUsuario)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ousuario = _UsuarioDatos.Obtener(IdUsuario);
            return View(ousuario);
        }

        [HttpPost]
        public IActionResult Eliminar(UsuarioModel oUsuario)
        {
            //METODO RECIBE EL OBJETO PARA ELIMINARLO DE LA BD

            var respuesta = _UsuarioDatos.Eliminar(oUsuario.IdUsuario);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
