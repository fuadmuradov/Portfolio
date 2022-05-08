using Portfolio.Models.DbTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.ViewModel
{
    public class MainVM
    {
        public About About { get; set; }
        public List<Skill> Skills { get; set; }
        public Contact Contact { get; set; }
        public List<Testimonial> Testimonials { get; set; }
        public List<Project> Projects { get; set; }
    }
}
