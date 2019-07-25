using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Repositories.Dapper.Northwind;
using System.Configuration;
using Cibertec.Web.Controllers;
using System.Reflection;
using System.Web.Mvc;

namespace Cibertec.Web
{
    /*DI - Dependency Injection */
    public class DIConfig
    {
        public static void ConfigureInjector()
        {
            // Crear el contenedor de dependencias
            var container = new Container();

            // Configurar el estilo de vida del contenedor.
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Registrar las dependencias
            container.Register<IUnitOfWork>(() => new NorthwindUnitOfWork(ConfigurationManager.ConnectionStrings["NorthwindLite"].ConnectionString));

            // Tenemos que decirle que esta dependencias va a ser usadas con por los controladores. Esto no viene por defecto. En NetCORE ya viene implementado.

            // Registrar las dependencias en todos los controladores de este ensamblado(dll).
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            // Le decimos a MVC que utilice el contenedor que hemos configurado.
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));



        }
    }
}