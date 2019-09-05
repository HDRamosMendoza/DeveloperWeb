using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cibertec.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Cibertec.Models;

namespace Cibertec.WebApi.Controllers
{
    [ApiController]
    public class ProductsController : BaseController
    {
        public ProductsController(IUnitOfWork unit) : base(unit)
        {
        }

        // GET /api/products
        public IActionResult Get()
        {
            try
            {
                return Ok(unitOfWork.Products.GetList());
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        // GET /api/products/{id}
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                // para obtener un registro por su ID
                var product = unitOfWork.Products.GetById(id);
                if (product == null)
                    return new NotFoundObjectResult("Producto no encontrado");

                // si se encontró el producto, devolver la info
                
                return Ok(product);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        // POST /api/products/
        [HttpPost]
        public IActionResult Post(Product newProduct)
        {
            // validar el modelo
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok(unitOfWork.Products.Insert(newProduct));
                }
                catch (Exception ex)
                {
                    return new StatusCodeResult(500);
                }
            }

            // si el modelo no es válido, retornar un bad request
            return BadRequest(newProduct);
        }

        // PUT /api/products
        [HttpPut]
        public IActionResult Put(Product updatedProduct)
        {
            if (ModelState.IsValid && unitOfWork.Products.Update(updatedProduct))
            {
                return Ok("El producto fue actualizado");
            }

            return BadRequest(updatedProduct);
        }

        // DELETE /api/products/{id}
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (unitOfWork.Products.Delete(new Product { Id = id }))
                return Ok("Se eliminó el producto");

            return BadRequest(new { Message = "data incorrecta" });
        }


        //[HttpPost]
        //[Route("savedata/{otro}")]
        //public IActionResult SaveData([FromBody]Product newProduct, string otro)
        //{
        //    return Ok(new { newProduct, otro });
        //}
    }
}