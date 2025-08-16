using COAHub.Domain.Application_Modes.Company_Model;
using COAHub.Domain.Application_Modes.Journal_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COAHub.Domain.Application_Modes.Account_Model
{
    public  class Account: Audit
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsSsytemAccount { get; set; } //retained_account
        public int? ParentAccountId { get; set; }

        [ForeignKey(nameof(AccountType))]
        public int? AccountTypeId { get; set; }

        [ForeignKey(nameof(Company))]
        public int? CompanyId { get; set; }

        //navigation property
        public AccountType? AccountType { get; set; }
        public Account? ParentAccount { get; set; }
        public Company? Company { get; set; }

        //collection
        public List<Account> SubAccounts { get; set; } = new List<Account>();

    }
}
