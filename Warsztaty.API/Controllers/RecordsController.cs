using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Warsztaty.Messages.Commands;

namespace Warsztaty.API.Controllers
{
    [Route("[controller]")]
    public class RecordsController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRecord command)
        {
            return Accepted();
        }
    }
}