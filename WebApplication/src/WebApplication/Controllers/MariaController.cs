using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class MariaController
    {
        public string Index() => "Hello from MVC!";

        public string SomethingElse() => "Hello Maria from MVC!";
    }

    public class ScottIndexViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class ScottController : Controller
    {
        public IActionResult Index()
        {
            // get the model from the database or wherever
            var vm = new ScottIndexViewModel() { Age = 29, Name = "Scott" };
            // do some stuff
            return View(vm);
        }

        
    }
}
