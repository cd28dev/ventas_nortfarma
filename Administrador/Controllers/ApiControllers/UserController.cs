using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;

namespace Administrador.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;

        [System.Web.Mvc.HttpGet]
        public JsonResult ListarUsuarios()
        {
            userService = new UserService();
            List<Usuario> users = new List<Usuario>();

            users = userService.Listar();

            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult findByDoc([FromBody] string nroDoc)
        {
            userService = new UserService();
            Usuario user = new Usuario();
            user = userService.findByDoc(nroDoc);

            return Json(user);

        }

    }
}
