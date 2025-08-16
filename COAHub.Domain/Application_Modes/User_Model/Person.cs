using COAHub.Domain.Application_Modes.Contact_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COAHub.Domain.Application_Modes.User_Model
{
    public  class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName {  get; set; }
        public string LastName { get; set; } = string.Empty;

        //collection
        public List<Phone> Phones { get; set; } = new List<Phone>();
        public List<Email> Emails { get; set; } = new List<Email>();
    }
}
