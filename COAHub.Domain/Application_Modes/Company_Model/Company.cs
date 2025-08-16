using COAHub.Domain.Application_Modes.Account_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COAHub.Domain.Application_Modes.Company_Model
{
    public  class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RegistratioNumber { get; set; } = string.Empty ;

        [ForeignKey(nameof(Currency))]
        public int? CurrencyId { get; set; }
        public string TimeZone { get; set; } = "UTC";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //navigation-property
        public Currency? Currency { get; set; }

        //collection-property
        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}
