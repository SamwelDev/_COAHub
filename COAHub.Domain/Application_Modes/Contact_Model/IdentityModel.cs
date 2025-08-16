using COAHub.Domain.Application_Modes.User_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COAHub.Domain.Application_Modes.Contact_Model
{
    public  class IdentityModel
    {
        [Key]
        public int Id { get; set; }

        public string? IdentityNumber { get; set; } // e.g. "123456789"

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        [ForeignKey(nameof(IdentityCardType))]
        public int? IdentityTypeCardId { get; set; }

        [ForeignKey(nameof(Person))]
        public int? PersonId { get; set; }
        public int? IdentityCardTypeId { get; set; }

        //navigation-property
        public Person? Person { get; set; }
        public IdentityCardType? IdentityCardType { get; set; }
    }
}
