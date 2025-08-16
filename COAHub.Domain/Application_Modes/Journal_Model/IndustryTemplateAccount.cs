using COAHub.Domain.Application_Modes.Account_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COAHub.Domain.Application_Modes.Journal_Model
{
    public  class IndustryTemplateAccount
    {
        public int  Id { get; set; }
        public string? Code { get; set; }
        public string Name { get; set; } = "";
        public int? AccountTypeId { get; set; }
        public int? ParentTemplateAccountId { get; set; }
        public int? IndustryTemplateId { get; set; }
        //navigation-property
        public IndustsryTemplate? IndustryTemplate { get; set; }
        public AccountType? AccountType { get; set; }
    }
}
