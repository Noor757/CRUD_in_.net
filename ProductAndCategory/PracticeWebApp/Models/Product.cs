using System.ComponentModel.DataAnnotations;

namespace PracticeWebApp.Models
{
    public class Product
    {
        [Range(1, 100, ErrorMessage = "Must be in range 1 to 100 only!!")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public List<int> CategoryIds { get; set; }
        public int AddCategoryNO { get; set; }
        public int RemoveCategoryNO { get; set; }
        public Product() {}

    }
}
