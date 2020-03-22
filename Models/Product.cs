using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crow.Shop.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public decimal Price { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<ProductTranslation> Translations { get; set; }
    }
}
