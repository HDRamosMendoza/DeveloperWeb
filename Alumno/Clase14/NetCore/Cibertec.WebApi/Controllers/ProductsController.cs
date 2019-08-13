using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cibertec.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Cibertec.WebApi.Controllers
{
    [ApiController]
    public class ProductsController : BaseController
    {
        public ProductsController(IUnitOfWork unit) : base(unit)
        {
        }

        
        // GET/api/products
        public IActionResult Get()
        {
            try
            {
                // El Ok te devuelve el estado en 200 que todo este en bien
                return Ok(unitOfWork.Products.GetList());
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}