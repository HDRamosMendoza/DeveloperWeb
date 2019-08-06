using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cibertec.UnitOfWork;

namespace Cibertec.Web.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(IUnitOfWork unit ): base(unit)
        {
        }        

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
    }
}