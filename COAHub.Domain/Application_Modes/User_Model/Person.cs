using COAHub.Domain.Application_Modes.Contact_Model;
using COAHub.Domain.Application_Modes.Other_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COAHub.Domain.Application_Modes.User_Model
{
    public  class Person
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName {  get; set; }
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string? PayRollNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string? UserId { get; set; }

        [ForeignKey(nameof(Gender))]
        public int? GenderId { get; set; }

        //navigation-property
        public Gender? Gender { get; set; }
        public UserModel? User { get; set; }

        //collection
        public List<Phone> Phones { get; set; } = new List<Phone>();
        public List<Email> Emails { get; set; } = new List<Email>();
    }
}
