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

    public class ScottController
    {
        public string Index()
        {
            return "Hey it's Scott";
        }
    }
}
