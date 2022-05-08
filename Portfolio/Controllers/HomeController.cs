using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Portfolio.Models;
using Portfolio.Models.DbTables;
using Portfolio.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
                Testimonials = context.Testimonials.ToList(),
                Projects = context.Projects.Include(x => x.Pictures).ToList()
                
            };

            return View(mainVM);
        }

        public IActionResult Details(int id)
        {
            Project project = context.Projects.Include(x=>x.Pictures).FirstOrDefault(x => x.Id == id);
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMail(string name, string email, string subject, string message)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("hrmshrms2000@gmail.com", "Portfolio");
            mail.To.Add(new MailAddress("fuadmuradov570@gmail.com"));
            mail.Subject = subject;
            string body = name + ": " + email + ":\n " + message;

            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("hrmshrms2000@gmail.com", "hrms12345");
            smtp.Send(mail);

            return LocalRedirect("/Home/Index");
        }


    }
}
