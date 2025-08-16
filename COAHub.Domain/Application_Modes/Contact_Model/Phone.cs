using COAHub.Domain.Application_Modes.User_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COAHub.Domain.Application_Modes.Contact_Model
{
    public  class Phone
    {
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsIdentity { get; set; } = false;
        public string? Description { get; set; }

        [ForeignKey(nameof(UserModel))]
        public int? UserId { get; set; }

        //*--Navigation property
        public UserModel? User { get; set; }
    }
}
