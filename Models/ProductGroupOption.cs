using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Crow.Shop.Models
{
    public class ProductOptionGroup
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [JsonIgnore]
        public int ProductId { get; set; }

        public int Order { get; set; }

        [JsonIgnore]
        public virtual Product Product { get; set; }

        public virtual ICollection<ProductOptionGroupTranslation> Translations { get; set; }
        
        public virtual ICollection<ProductOption> Options { get; set; }
    }
}
