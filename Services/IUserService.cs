
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        List<Usuario> Listar();
        Usuario findByDoc(string nroDoc);

        int deleteById(string nroDoc);

        bool saveUser(Usuario usuario);

        Usuario lastUser();
    }
}
