using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models.DbTables
{
    public class About
    {
        public int Id { get; set; }
        public DateTime Birthday { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public string Degree { get; set; }
        public string Email { get; set; }
        public string Frelance { get; set; }
        public string Description { get; set; }

    }
}
