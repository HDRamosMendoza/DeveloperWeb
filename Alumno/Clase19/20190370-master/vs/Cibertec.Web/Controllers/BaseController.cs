using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cibertec.UnitOfWork;

namespace Cibertec.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IUnitOfWork unitOfWork;

        public BaseController(IUnitOfWork unit)
        {
            unitOfWork = unit;
        }
    }
}