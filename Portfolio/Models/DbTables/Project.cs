using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models.DbTables
{
    public class Project
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public DateTime BuildDate { get; set; }
        public string ProjectURL { get; set; }
        public List<Picture> Pictures { get; set; }

    }
}
