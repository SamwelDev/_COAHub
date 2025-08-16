using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COAHub.Domain.Application_Modes.User_Model
{
    public  class UserModel:IdentityUser
    {
        public bool IsActvive { get; set; }
        public bool IsApproved { get; set; }

        public Person? Person { get; set; }
    }
}
