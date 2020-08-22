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

    }


    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

        public List<Areas> Areas {get;set;}
        
  
    }

   
    public class Areas
    {
        public int UserID { get; set; }
        public string SubSectionID { get; set; }
        public string SubSectionTitle { get; set; }
        public List<SubSection> SubSection { get; set; }
    }

    public class SubSection
    {
        public int UserID { get; set; }
        public string SubSectionID { get; set; }
        public string SubSectionTitle { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string Location { get; set; }
        public string Role { get; set; }
        public string Learning { get; set; }
        public string Year { get; set; }
        public string Link { get; set; }
        public string Owner { get; set; }
        public string Display { get; set; }
    }

