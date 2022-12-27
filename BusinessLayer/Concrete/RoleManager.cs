using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class RoleManager:IRoleService
    {
        private IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public Role GetRoleById(int id)
        {
            return _roleDal.Get(x=>x.RoleId==id);
        }

        public List<Role> GetList()
        {
            return _roleDal.List();
        }

        public Role GetRoleByRoleName(string roleName)
        {
            return _roleDal.Get(x => x.RoleName == roleName);
        }
    }
}