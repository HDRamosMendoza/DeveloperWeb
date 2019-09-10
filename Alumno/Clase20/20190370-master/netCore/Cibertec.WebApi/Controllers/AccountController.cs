using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cibertec.WebApi.Models;
using Cibertec.WebApi.Services;
using Microsoft.AspNetCore.Authorization;

namespace Cibertec.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        protected IAuthenticationService authenticationService;

        public AccountController(IAuthenticationService authService)
        {
            authenticationService = authService;
        }

        [HttpPost]
        [Route("token")]
        [AllowAnonymous]
        public IActionResult Token(TokenRequest request)
        {
            if (ModelState.IsValid)
            {
                var token = string.Empty;
                var validatedUser = authenticationService.ValidateUser(request, out token);

                if (validatedUser != null && !string.IsNullOrEmpty(token))
                {
                    return Ok(token);
                }

                // el usuario no es válido (no existe en la BD)
                return new StatusCodeResult(401);
            }

            return BadRequest("Solicitud inválida");
        }
    }
}