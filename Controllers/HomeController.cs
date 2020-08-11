using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using aneri_vyas.Models;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace aneri_vyas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            MainModel MainModel = new MainModel();
            List<User> User = new List<User>();

            MainModel.User = User;

            dynamic UserData = JsonConvert.DeserializeObject<dynamic>(System.IO.File.ReadAllText("Database/User.json"));


            foreach (dynamic item in UserData)
            {
                User.Add(new User
                {
                    UserID = (int)item["UserID"],
                    Name = (string)item["Name"],
                    Title = (string)item["Title"]
                });


            }


            List<Skills> Skills = new List<Skills>();
            MainModel.Skills = Skills;

            dynamic SkillsData = JsonConvert.DeserializeObject<dynamic>(System.IO.File.ReadAllText("Database/Skills.json"));


            foreach (dynamic item in SkillsData)
            {
                Skills.Add(new Skills
                {
                    UserID = (int)item["UserID"],
                    Name = (string)item["Name"],
                    SkillID = (int)item["SkillID"],
                    Type = (string)item["Type"],
                    YearsOfExperience = (string)item["YearsOfExperience"],
                    Description = (string)item["Description"]
                }); 
            }
            


            return View(MainModel);
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
