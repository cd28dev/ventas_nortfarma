using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RolesService:IRolesService
    {
        private IRolesData rolesData;

        public RolesService()
        {
            rolesData = new RolesData();
        }

        public List<Rol> listRoles()
        {
            List<Rol> roles = new List<Rol>();

            roles = rolesData.listRoles();

            return roles;
        }
    }
}
