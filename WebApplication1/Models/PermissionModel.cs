using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMvc.Models
{
    public class PermissionModel
    {
        public int idPermission { get; set; }
        public string permissionName { get; set; }
        public string PermissionDescription { get; set; }
        public System.DateTime modificationDate { get; set; }
        public virtual ICollection<Permission_RoleModel> Permission_Role { get; set; }

    }
}