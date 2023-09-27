using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public bool Featured { get; set; } = false;

        public List<ProductVariant> Variants { get; set; } = new List<ProductVariant>();


    }
}
