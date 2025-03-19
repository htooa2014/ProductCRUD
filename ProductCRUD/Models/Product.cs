using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProductCRUD.Models
{
    public class Product
    {
        
        public int Id { get; set; }

        [Display(Name = "Product")]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}")]
        public DateTime Created { get; set; }

        public bool IsDeleted { get; set; }
    }
}
