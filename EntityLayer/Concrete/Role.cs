using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}