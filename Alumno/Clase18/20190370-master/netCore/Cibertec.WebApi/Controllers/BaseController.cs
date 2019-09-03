using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cibertec.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Cibertec.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")] // todos los controladores que heredene de este, generarán sus respuestas en formato JSON por default
    public class BaseController : ControllerBase
    {
        protected readonly IUnitOfWork unitOfWork;

        public BaseController(IUnitOfWork unit)
        {
            unitOfWork = unit;
        }
    }
}
