using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Crow.Shop.Models
{
    public class ProductOptionTranslation
    {
        [JsonIgnore]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [JsonIgnore]
        public Guid ProductOptionId { get; set; }

        [Required]
        public string Culture { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ProductOption ProductOption { get; set; }
    }
}
