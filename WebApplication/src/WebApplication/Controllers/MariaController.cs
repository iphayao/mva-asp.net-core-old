﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class MariaController
    {
        [HttpGet("/")]
        public string Index() => "Hello from MVC!";

        [HttpGet("/Maria")]
        public string SomethingElse() => "Hello Maria from MVC!";
    }
}
