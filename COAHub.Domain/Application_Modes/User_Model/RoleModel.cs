using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COAHub.Domain.Application_Modes.User_Model
{
    public  class RoleModel: IdentityRole
    {
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public bool IsSystemRole { get; set; } //i.e so as later to prrevent accidental deletion or edit

        public string? Category { get; set; }

        //*--Navigation property
        public List<UserModel> Users { get; set; } = new List<UserModel>();
    }
}
