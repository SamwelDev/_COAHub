using COAHub.Domain.Application_Modes.Account_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COAHub.Domain.Application_Modes.Journal_Model
{
    public  class JournalEntityLine
    {
        [Key]
        public int  Id { get; set; }
        [ForeignKey(nameof(JournalEntry))]
        public int? JournalEntryId { get; set; }

        public int?  AccountId { get; set; }
       
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }

        //navigation-property
        public Account? Account { get; set; }
        public JournalEntryModel? JournalEntry { get; set; }


    }
}
