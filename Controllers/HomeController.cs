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
using System.Web;

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


            var URL = Request.HttpContext.Request.Host;

            var UserID = "0";

            MainModel MainModel = new MainModel();
            List<User> User = new List<User>();

            MainModel.User = User;

            dynamic UserData = JsonConvert.DeserializeObject<dynamic>(System.IO.File.ReadAllText("Database/User.json"));

            foreach(dynamic item in UserData)
                        {
                            if(item["URLString"] == URL)
                            {
                                UserID = item["UserID"];
                            }
                
                        }

            User user = new User();

            //var UserID = 1;

            foreach (dynamic item in UserData)
            {
                if (item["UserID"] == UserID)
                {
                   var SubSectionTitleList = (string)item["SubSectionTitle"];
                   var SubSectionTitleSplit = SubSectionTitleList.Split(',').ToList();

                   var SubSectionIDList = (string)item["SubSectionID"];
                   var SubSectionIDSplit = SubSectionIDList.Split(',').ToList();

                   var SubSectionJson = SubSectionIDSplit.Zip(SubSectionTitleSplit, (SubSectionIDSplit, SubSectionTitleSplit) => new { SubSectionIDSplit = SubSectionIDSplit, SubSectionTitleSplit = SubSectionTitleSplit });

                    List<Areas> Area = new List<Areas>();
                    user.Areas = Area;

                    Areas area = new Areas();

                    foreach (var subsectiontitle in SubSectionJson)
                    {

                        
                            List<SubSection> SubSection = new List<SubSection>();
                            area.SubSection = SubSection;

                            dynamic SubSectionData = JsonConvert.DeserializeObject<dynamic>(System.IO.File.ReadAllText("Database/SubSections.json"));

                            var sSTitle = subsectiontitle.SubSectionTitleSplit;


                            foreach (var s in SubSectionData)
                            {

                                if (s["UserID"] == UserID)
                                {

                                    if (s["SubSectionTitle"] == sSTitle)
                                    {
                                        SubSection.Add(new SubSection
                                        {
                                            UserID = s["UserID"],
                                            SubSectionID = s["SubSectionID"],
                                            SubSectionTitle = s["SubSectionTitle"],
                                            ID = s["ID"],
                                            Name = s["Name"],
                                            Type = s["Type"],
                                            Duration = s["Duration"],
                                            Description = s["Description"],
                                            Details = s["Details"],
                                            Location = s["Location"],
                                            Role = s["Role"],
                                            Learning = s["Learning"],
                                            Year = s["Year"],
                                            Link = s["Link"],
                                            Owner = s["Owner"],
                                            Display = s["Display"]
                                        });

                                    }
                                }
                            }

                            Area.Add(new Areas
                            {
                                SubSectionTitle = subsectiontitle.SubSectionTitleSplit,
                                SubSectionID = subsectiontitle.SubSectionIDSplit,
                                SubSection = SubSection
                            });
                        
                    }


                    User.Add(new User
                    {
                        UserID = (int)item["UserID"],
                        Name = (string)item["Name"],
                        Title = (string)item["Title"],
                        Areas = Area
                    });
                }

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
