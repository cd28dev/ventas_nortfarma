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
        private IRolesService rolesService;
        private ITipoDocService tipoDocService;

        [HttpGet]
        public JsonResult ListarUsuarios(string tipo)
        {
            this.userService = new UserService();
            List<Usuario> users = new List<Usuario>();

            users = userService.Listar(tipo);

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
            Usuario user = new Usuario();
            this.userService = new UserService();

            if (userService.saveUser(usuario)) {
                this.userService = new UserService();
                user = userService.lastUser();
            }

            return Json(new { success = true, userId = user.IdUsuario, message = "Usuario registrado exitosamente" });
        }

        [HttpPost]
        public JsonResult UpdateUser(Usuario usuario)
        {
            Usuario user = new Usuario();
            this.userService = new UserService();

            if (userService.updateUser(usuario))
            {
                user = usuario;
            }

            return Json(new { success = true, userId = user.IdUsuario, message = "Usuario actualizado exitosamente" });
        }


        [HttpGet]
        public JsonResult GetRoles()
        {
            rolesService = new RolesService();
            List<Rol> roles = new List<Rol>();

            roles = rolesService.listRoles();

            return Json(roles, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetTipDoc()
        {
            tipoDocService = new TipoDocService();
            List<TipoDocumento> documents = new List<TipoDocumento>();

            documents = tipoDocService.GetTipoDocuments();

            return Json(documents, JsonRequestBehavior.AllowGet);
        }
    }
}
