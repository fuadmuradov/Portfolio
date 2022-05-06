using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portfolio.Models;
using Portfolio.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly PortContext context;

        public HomeController(PortContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            MainVM mainVM = new MainVM()
            {
                About = context.Abouts.First(),
                Contact = context.Contacts.First(),
                Skills = context.Skills.ToList(),
                Testimonials = context.Testimonials.ToList()

            };

            return View(mainVM);
        }


        
    }
}
