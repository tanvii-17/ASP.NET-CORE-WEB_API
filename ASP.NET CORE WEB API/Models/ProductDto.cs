using System.ComponentModel.DataAnnotations;

namespace ASP.NET_CORE_WEB_API.Models
{
    public class ProductDto
    {
        [Required]
        public int? Id { get; set; } // Nullable to differentiate between create and update operations

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
