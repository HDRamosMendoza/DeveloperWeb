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
    public class DIConfig
    {
        public static void ConfigureInjector()
        {
            // crear el contenedor de dependencias
            var container = new Container();

            // configurar el estilo de vida del contenedor
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // registrar las dependencias
            container.Register<IUnitOfWork>(() => new NorthwindUnitOfWork(ConfigurationManager.ConnectionStrings["NorthwindLite"].ConnectionString));

            // registrar las dependencias en todos los controladores de este ensamblado (dll)
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            // le decimos a mvc que utilice el contendor que hemos configurado
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}