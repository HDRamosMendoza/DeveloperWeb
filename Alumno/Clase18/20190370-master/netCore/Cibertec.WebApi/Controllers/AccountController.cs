using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cibertec.WebApi.Services;
using Cibertec.WebApi.Models;

namespace Cibertec.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        protected IAuthenticationService authenticationService;

        public AccountController(IAuthenticationService authService)
        {
            authenticationService = authService;
        }

        [HttpPost]
        [Route("token")]
        public IActionResult Token(TokenRequest request)
        {
            if (ModelState.IsValid)
            {
                var token = string.Empty;
                var validatedUser = authenticationService.ValidateUser(request, out token);

                //return Ok("ramdom:string");
                if (validatedUser != null && !string.IsNullOrEmpty(token))
                {
                    return Ok(token);
                }

                // el ususario no es valido
                return new StatusCodeResult(401);
            }
            return BadRequest("Solicitud invalida");            
        }
    }
}