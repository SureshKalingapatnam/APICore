using ConsoleToWebAppCore.CustomBinder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleToWebAppCore.Controllers
{
    [ModelBinder(typeof(CustomCountryDetails))]
    public class CountryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public string Location { get; set; }
      
        public string Area { get; set; }

    }
}
