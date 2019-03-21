using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Emails.Models;
using Emails.Servicos;

namespace Emails.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmail _email;
        public HomeController(IEmail email)
        {
            _email = email;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult EnviarEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EnviarEmail(EmailViewModel meuEmail)
        {
            if(ModelState.IsValid)
            {
                await _email.EnviarEmail(meuEmail.Email, meuEmail.Assunto, meuEmail.Mensagem);
                return View("EmailEnviado");
            }
            return View(meuEmail);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
