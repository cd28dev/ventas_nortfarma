using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Administrador.Controllers
{

    public class UserController : Controller
    {
        private IUserService userService;

        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            this.userService = new UserService();
            List<Usuario> users = new List<Usuario>();

            users = userService.Listar();

            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult findByDoc(string nroDoc)
        {
            this.userService = new UserService();

            Usuario user = new Usuario();
            user = userService.findByDoc(nroDoc);

            return Json(user);

        }

        [HttpDelete]
        public JsonResult Delete(string id)
        {
            this.userService = new UserService();
            Usuario usuario = new Usuario();
            string message = "Usuario no encontrado";
            bool response = false;

            if (userService.deleteById(id) == 1)
            {
                this.userService = new UserService();
                message = "Usuario eliminado correctamente";
                usuario = userService.findByDoc(id);
                response = true;
            }
            return Json(new { success = response, message = message, deletedUser = usuario });
        }

        [HttpPost]
        public JsonResult SaveUser(Usuario usuario) {

            this.userService = new UserService();

            return Json(user);
        }

    }
}
