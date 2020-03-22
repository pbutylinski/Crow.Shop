using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crow.Shop.Models
{
    public class ProductTranslation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int ProductId { get; set; }

        public string Culture { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual Product Product { get; set; }
    }
}
