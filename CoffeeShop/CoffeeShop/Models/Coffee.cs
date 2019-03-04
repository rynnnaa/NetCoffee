using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public class Coffee
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string URL { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        
    }
}
