using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models.DbTables
{
    public class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }


    }
}
