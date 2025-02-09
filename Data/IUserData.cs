using Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IUserData
    {
        List<Usuario> Listar(string tipo);

        Usuario findById(string id);

        int deleteById(string id);

        bool saveUser(Usuario usuario);

        Usuario lastUser();

        bool updateUser(Usuario usuario);
    }
}
