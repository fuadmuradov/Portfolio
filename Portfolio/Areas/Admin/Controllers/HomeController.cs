using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Models.DbTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly PortContext context;
        private readonly IWebHostEnvironment webHost;

        public HomeController(PortContext context, IWebHostEnvironment webHost)
        {
            this.context = context;
            this.webHost = webHost;
        }
        public IActionResult About()
        {
            About about = context.Abouts.First();
            return View(about);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> About(About about)
        {
            if (!ModelState.IsValid) return View(about);
            About existabout = context.Abouts.First();
            existabout.Age = about.Age;
            existabout.Website = about.Website;
            existabout.Birthday = about.Birthday;
            existabout.Phone = about.Phone;
            existabout.City = about.City;
            existabout.Degree = about.Degree;
            existabout.Email = about.Email;
            existabout.Frelance = about.Frelance;
            existabout.Description = about.Description;

            await context.SaveChangesAsync();


            return View();
        }

        public IActionResult Contact()
        {
            Contact contact = context.Contacts.First();
            if (contact == null) return View();

            return View(contact);
        }


        public async Task<IActionResult> Contact(Contact contact)
        {
            if (!ModelState.IsValid) return View(contact);
            Contact existcontact = context.Contacts.First();

            existcontact.Twitter = existcontact.Twitter;
            existcontact.Facebook = existcontact.Facebook;
            existcontact.Instagram = existcontact.Instagram;
            existcontact.Linkedin = existcontact.Linkedin;
            existcontact.Skype = existcontact.Skype;
            existcontact.Email = existcontact.Email;
            existcontact.Location = existcontact.Location;
            existcontact.Phone = existcontact.Phone;

            await context.SaveChangesAsync();


            return View();
        }



    }
}
