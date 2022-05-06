using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models.DbTables
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Percent { get; set; }
    }
}
