using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService:IUserService 
    {
        private IUserData userData;

        public UserService() { 
            userData = new UserData();
        }

        public int deleteById(string nroDoc)
        {
            int row=userData.deleteById(nroDoc);
            return row;
        }

        public Usuario findByDoc(string nroDoc)
        {
            Usuario user = new Usuario();
            user = userData.findById(nroDoc);


            if (user.Estado.Equals("0"))
            {
                user.Estado = "No";
            }
            else if (user.Estado.Equals("1"))
            {
                user.Estado = "Si";
            }           
            return user;
        }

        public List<Usuario> Listar(string tipo)
        {
            List<Usuario> users= new List<Usuario>();
            users = userData.Listar(tipo);

            foreach (Usuario usuario in users)
            {
                if (usuario.Estado.Equals("0")){
                    usuario.Estado = "No";
                }else if (usuario.Estado.Equals("1"))
                {
                    usuario.Estado = "Si";
                }
            }

            return users;
        }

        public bool saveUser(Usuario usuario)
        {
            bool isSendEmail, isSaved=false;
            string pass = Helper.genPassword();
            string asunto = "Creación de cuenta Nortfarma";
            string msg = "<h3>Su cuenta fue creada con exito.</h3></br><p>Su contraseña para acceder es:!pass!</p>";
            msg = msg.Replace("!pass!", pass);

            if (usuario.Estado == "Si")
            {
                usuario.Estado = "1";
            }
            else if (usuario.Estado == "No")
            {
                usuario.Estado = "0";
            }
            isSendEmail = Helper.SendEmail(usuario.Email, asunto, msg);
            if (isSendEmail){
                usuario.Password = pass;
                isSaved = userData.saveUser(usuario);
            }

            return isSaved;
        }

        public Usuario lastUser()
        {
            return userData.lastUser();
        }

        public bool updateUser(Usuario usuario)
        {
            if (usuario.Estado == "Si")
            {
                usuario.Estado = "1";
            }
            else if (usuario.Estado == "No")
            {
                usuario.Estado = "0";
            }
            bool isUpdated = userData.updateUser(usuario);
            return isUpdated;
        }
    }
}
