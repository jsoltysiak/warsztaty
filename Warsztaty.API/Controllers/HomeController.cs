using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Warsztaty.API.Controllers
{
   // [Produces("application/json")]
  //  [Route("api/Home")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get() => Content("Hellow World Warsztaty API");
    }
}