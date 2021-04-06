using BarkerAssignment10.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarkerAssignment10.Components
{
    public class BowlerContactInfoViewComponent :ViewComponent 
    {

        private BowlingLeagueContext context;
        public BowlerContactInfoViewComponent(BowlingLeagueContext ctx)
        {
            context = ctx;
        }
        public IViewComponentResult Invoke()
        {
            return View(context.Teams
                .Distinct()
                .OrderBy(x => x));
        }



    }
}
