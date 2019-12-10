using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace webshop_induvidueel.Models
{
    public class ProductViewModel
    {
        [StringLength(12, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Name { get; set; }

        [Range(0, 999.99)]
        public decimal Price { get; set; }

        [StringLength(511, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 1)]
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int Stock { get; set; }
        public string VariationType { get; set; }
        public string VariationValue { get; set; }
    }
}
