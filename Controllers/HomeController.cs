using BarkerAssignment10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BarkerAssignment10.Models.ViewModels;

namespace BarkerAssignment10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly BowlingLeagueContext context; <--We want to get in and change this, so we do NOT want readonly
        private BowlingLeagueContext context { get; set; }

        //Bring in dbContext here in the constructor
        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx )
        {
            _logger = logger;
            //Add context and autogenerate it as a variable
            context = ctx;
        }

        //For routing to different views and filters:
        [HttpGet]



        public IActionResult Index(long? bowlercontactinfoid, int pageNum = 0)
        {
            int pageSize = 5;

            //Test to see if the context works for the db
            return View(new IndexViewModels
            {
                Bowlers = context.Bowlers
                .Where(m => m.TeamId == bowlercontactinfoid || bowlercontactinfoid == null)
                .OrderBy(m => m.BowlerLastName)
                .Skip((pageNum - 1) * pageSize)
                .ToList(),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    //If no team selected, then get the full count. Otherwise, only count the
                    //number from the team that has been selected
                    TotalNumItems = (bowlercontactinfoid == null ? context.Bowlers.Count() :
                        context.Bowlers.Where(x => x.TeamId == bowlercontactinfoid).Count())
                }

            });
                
                
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
