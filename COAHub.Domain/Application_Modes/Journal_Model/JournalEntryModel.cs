using COAHub.Domain.Application_Modes.Company_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COAHub.Domain.Application_Modes.Journal_Model
{
    public  class JournalEntryModel
    {
        
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty;
        public string? Description { get; set; } 

        [ForeignKey(nameof(Company))]
        public int? CompanyId { get; set; }

        //navigation-prperty
        public Company? Company { get; set; }

        public List<JournalEntityLine> Lines { get; set; } = new List<JournalEntityLine>();
    }
}
