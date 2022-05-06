using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models.DbTables
{
    public class Contact
    {
        public int Id { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public string Skype { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
