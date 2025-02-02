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


        public UserController()
        {
            this.userService = new UserService();
        }


        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            List<Usuario> users = new List<Usuario>();

            users = userService.Listar();

            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult findByDoc(string nroDoc)
        {
            Usuario user = new Usuario();
            user = userService.findByDoc(nroDoc);

            return Json(user);

        }

        [HttpDelete]
        public JsonResult Delete(string id)
        {
            //bool resultado = userService.Eliminar(id);
            return Json(new { success = "" });
        }

    }
}
