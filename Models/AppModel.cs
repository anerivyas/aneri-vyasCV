using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aneri_vyas.Models
{
    public class MainModel
    {
        public List<User> User { get; set; }
        public List<Skills> Skills { get; set; }

    }


    public class User
    {
        public int UserID { get; set;}
        public string Name { get; set; }
        public string Title { get; set;}
    }

    public class Skills
    {
        public int SkillID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string YearsOfExperience { get; set; }
        public string Description { get; set; }
    }
}

