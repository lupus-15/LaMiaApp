﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaMiaApp.Controllers
{
    public class AppuntamentoController : Controller
    {
        // GET: Calendar
        public ActionResult Index()
        {
            return View("Calendar");
        }
    }
}