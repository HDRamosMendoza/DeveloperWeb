using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cibertec.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        [HttpPost]
        [Route("token")]
        public IActionResult Index()
        {
            if (ModelState.IsValid)
            {
                return Ok("ramdom:string");
            }

            return BadRequest("Solicitud invalida");
            
        }
    }
}