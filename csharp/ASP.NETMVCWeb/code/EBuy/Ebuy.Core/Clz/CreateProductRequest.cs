using Ebuy.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebuy.Core.Clz
{
    public class CreateProductRequest
    {
        [Required]
        public IEnumerable<CurrencyRequest> UnitPrice { get; set; }
    }
}
