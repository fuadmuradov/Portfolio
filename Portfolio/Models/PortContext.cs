using Microsoft.EntityFrameworkCore;
using Portfolio.Models.DbTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class PortContext:DbContext
    {
        public PortContext(DbContextOptions<PortContext> options):base(options) {}

        public DbSet<Skill> Skills { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<About> Abouts { get; set; }
    }
}
