using COAHub.Domain.Application_Modes.Company_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COAHub.Domain.Application_Modes.User_Model
{
    public  class UserCompanyRole
    {
        public int Id { get; set; }
        public string? UserId { get; set; }

        [ForeignKey(nameof(Company))]
        public int? CompanyId { get; set; }
        public string? RoleName { get; set; }
        //navigation property
        public Company? Company { get; set; }
        public UserModel? User { get; set; }
    }
}
