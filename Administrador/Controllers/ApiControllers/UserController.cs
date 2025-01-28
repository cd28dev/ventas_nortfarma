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
            userService = new UserService();
            List<Usuario> users = new List<Usuario>();

            users = userService.Listar();

            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult findByDoc(string nroDoc)
        {
            userService = new UserService();
            Usuario user = new Usuario();
            user = userService.findByDoc(nroDoc);

            return Json(user);

        }

    }
}
