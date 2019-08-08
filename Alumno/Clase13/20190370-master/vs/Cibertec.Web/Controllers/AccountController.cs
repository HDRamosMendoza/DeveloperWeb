using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Web.Models;
using Cibertec.Models;
using System.Security.Claims;

namespace Cibertec.Web.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(IUnitOfWork unit) : base(unit)
        {
        }

        // GET Account/Login
        public ActionResult Login(string returnUrl)
        {
            return View();
        }

        // POST Account/Login
        [HttpPost]
        public ActionResult Login(UserViewModel usuario)
        {
            // si el modelo no es válid, retornar la vista
            if (!ModelState.IsValid) return View(usuario);

            // @todo: ir a la BD y validar el usuario
            var usuarioValido = new User
            {
                Id = 1,
                Email = "correo@mail.com",
                Password = "Pass123$",
                FirstName = "Correo",
                LastName = "Mail",
                Roles = "Admin"
            };

            if (usuarioValido == null)
            {
                // significa que el usuario no existe
                // agregamos el error al ModelState
                ModelState.AddModelError("", "Contraseña o correo inválidos");
                return View(usuario);
            }

            // si el usuario existe
            // 1. Crear la identidad del usuario
            var identidad = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, usuarioValido.Email),
                new Claim(ClaimTypes.Name, $"{usuarioValido.FirstName} {usuarioValido.LastName}"),
                new Claim(ClaimTypes.Role,usuarioValido.Roles),
                new Claim(ClaimTypes.NameIdentifier, usuarioValido.Id.ToString())
            }, "ApplicationCookie");

            // 2. Obtener el contexto de owin
            var contextoOwin = Request.GetOwinContext();

            // 3. Obtener el administrador de autenticación del contexto
            var authManager = contextoOwin.Authentication;

            // 4. Le decimos al manager que inicie sesión con la identidad que acabamos de crear
            authManager.SignIn(identidad);

            // 5. Redireccionar al usuario a la página qu quería visualizar
            return RedireccionarAUrlLocal(usuario.ReturnUrl);

        }

        public ActionResult RedireccionarAUrlLocal(string url)
        {
            if (Url.IsLocalUrl(url))
            {
                // significa que es una url válida en nuestra app
                return Redirect(url);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Account/Logout
        [HttpPost]
        public ActionResult Logout()
        {
            var contexto = Request.GetOwinContext();
            var authManager = contexto.Authentication;

            // Cerrar sesion
            authManager.SignOut("ApplicationCookie");

            // Redireccionar al home
            return RedirectToAction("Index", "Home");
        }

        // GET: Account / Profile
        [Authorize]
        public ActionResult UserProfile()
        {
            return View();
        }
    }
}