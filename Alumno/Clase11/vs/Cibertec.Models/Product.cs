using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cibertec.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, ingresa el nombre del producto")]
        public string ProductName { get; set; }

        [Display(Name ="")]
        public int SupplierId { get; set; }
        public decimal? UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }
    }
}
