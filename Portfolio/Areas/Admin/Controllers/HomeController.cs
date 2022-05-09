using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class HomeController : Controller
    {
        private readonly PortContext context;

        public HomeController(PortContext context)
        {
            this.context = context;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
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


        public IActionResult Skill()
        {
            List<Skill> skills = context.Skills.ToList();
            return View(skills);
        }
        public IActionResult SkillDelete(int id)
        {
            Skill skill = context.Skills.FirstOrDefault(x => x.Id == id);
            if (skill == null) return NotFound();
            context.Skills.Remove(skill);
            context.SaveChanges();

            return LocalRedirect("/admin/Home/Skill/");
        }
        
        public IActionResult SkillCreate()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SkillCreate(Skill skill)
        {
            if (!ModelState.IsValid) return View();
            context.Skills.Add(skill);
            await context.SaveChangesAsync();
            return LocalRedirect("/admin/Home/Skill/");
        }

        public IActionResult SkillUpdate(int id)
        {
            Skill skill = context.Skills.FirstOrDefault(x => x.Id == id);

            return View(skill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SkillUpdate(Skill skill)
        {
            if (!ModelState.IsValid) return View();
            Skill existskill = context.Skills.FirstOrDefault(x => x.Id == skill.Id);
            existskill.Name = skill.Name;
            existskill.Percent = skill.Percent;
            await context.SaveChangesAsync();
            return LocalRedirect("/admin/Home/Skill/");
        }


      




    }
}
