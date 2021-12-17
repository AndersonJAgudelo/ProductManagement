using System.ComponentModel.DataAnnotations;

namespace ProductsManagement.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Title { get; set; }
        [Display(Name = "Product Number")]
        public int ProductNumber { get; set; }
        public int Price { get; set; }
    }
}