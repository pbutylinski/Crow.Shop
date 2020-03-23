using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Crow.Shop.Models
{
    public class ProductOption
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [JsonIgnore]
        public Guid GroupId { get; set; }

        public int Order { get; set; }

        public decimal PriceDifference { get; set; }

        [JsonIgnore]
        public virtual ProductOptionGroup Group { get; set; }

        public virtual ICollection<ProductOptionTranslation> Translations { get; set; }
    }
}
