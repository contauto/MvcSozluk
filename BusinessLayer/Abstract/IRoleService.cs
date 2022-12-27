using System.Collections.Generic;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IRoleService
    {
        Role GetRoleById(int id);
        List<Role> GetList();
        Role GetRoleByRoleName(string roleName);
    }
}