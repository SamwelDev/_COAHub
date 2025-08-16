using COAHub.Domain.Application_Modes.Company_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COAHub.Domain.Application_Modes.Account_Model
{
    public  class FiscalYear
    {
        [Key]
        public int  Id { get; set; }
        [ForeignKey(nameof(Company))]
        public int?  CompanyId { get; set; }
        public int Year { get; set; } // e.g., 2025
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsLocked { get; set; }

        //navigation-property
        public Company? Company { get; set; }
    }
}
