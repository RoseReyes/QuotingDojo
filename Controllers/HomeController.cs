using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quoting_dojo.Models;
using DbConnection;


namespace quoting_dojo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("quotes")]
        public IActionResult quotes(string inputname, string inputmessage)
        {
            DbConnector.Execute($"INSERT INTO post(name, quote, created_at, updated_at) VALUES ('{inputname}','{inputmessage}', NOW(), NOW());");

            var result = DbConnector.Query("SELECT * FROM post");
            ViewBag.display = result;
            return View("Quote");
        }
     }
}

