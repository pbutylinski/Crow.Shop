using System.Collections.Generic;

namespace Crow.Shop.Models
{
    public class ProductItem
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public List<ProductTranslation> Translations { get; set; }

        public ProductImage Image { get; set; }
    }
}
