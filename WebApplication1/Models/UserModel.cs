using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMvc.Models
{
    public class UserModel
    {
        public int idUser { get; set; }

        [Required(ErrorMessage ="Este Campo es obligatorio")]
        public string userNickname { get; set; }

        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public string userPassword { get; set; }

        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public string userFullName { get; set; }

        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public string userAddress { get; set; }

        public string userPhone { get; set; }

        public string userMail { get; set; }

        public Nullable<int> userAge { get; set; }

        public int fl_userRole { get; set; }

        public virtual RoleModel Role { get; set; }
    }
}