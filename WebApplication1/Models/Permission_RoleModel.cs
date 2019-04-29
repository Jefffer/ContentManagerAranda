using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMvc.Models
{
    public class Permission_RoleModel
    {
        public int idRole { get; set; }
        public int idPermission { get; set; }
        public Nullable<System.DateTime> modificationDate { get; set; }

        public virtual PermissionModel Permission { get; set; }
        public virtual RoleModel Role { get; set; }
    }
}