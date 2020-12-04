using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloAspNet.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ContentResult Action1()
        {
            return new ContentResult
            {
                Content = "Action 1 call"
            };

        }
        public ContentResult ParameterizedAction(string p1, int p2)
        {
            return new ContentResult
            {
                Content = $"Parameterized Action {p1}, {p2}"
            };
        }
    }
}
