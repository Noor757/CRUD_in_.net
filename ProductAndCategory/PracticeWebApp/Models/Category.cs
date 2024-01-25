using System.ComponentModel.DataAnnotations;

namespace PracticeWebApp.Models
{
    public class Category
    {
        [Range(1, 100, ErrorMessage = "Must be in range 1 to 100 only!!")]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> ProductIds { get; set; }
        public  int AddProductNO { get; set; }
        public int RemoveProductNO { get; set; }
        
        public Category(){}
    }
}
