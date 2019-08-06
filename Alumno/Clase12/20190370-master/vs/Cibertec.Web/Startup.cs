using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(Cibertec.Web.Startup))]

namespace Cibertec.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Vamos el middleware de autenticacion con cookies
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = 'ApplicationCookie',
                LoginPath = new PathString("/Account/Login")
            });

        }
    }
}
