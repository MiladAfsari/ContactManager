using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.UI.Controllers
{
    public class SocialMediaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
