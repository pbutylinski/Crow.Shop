using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Crow.Shop.Models
{
    public class ProductImage
    {
        [JsonIgnore]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int ProductId { get; set; }

        public int Order { get; set; }

        [Required]
        public string FileName { get; set; }

        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}
