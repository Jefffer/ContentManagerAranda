using System.Collections.Generic;

namespace WebMvc.Models
{
    public class RoleModel
    {
        public RoleModel()
        {
            this.Permission_Role = new HashSet<Permission_RoleModel>();
            this.User = new HashSet<UserModel>();
        }
        public int idRole { get; set; }
        public string roleName { get; set; }
        public System.DateTime modificationDate { get; set; }
        public virtual ICollection<Permission_RoleModel> Permission_Role { get; set; }
        public virtual ICollection<UserModel> User { get; set; }

    }
}