using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.route.Controllers
{
    public class PostController : Controller
    {
        [Route("/post/draft-setting")]
        public IActionResult DraftSetting()
        {
            return View();
        }
    }
}