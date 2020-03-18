using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }
        
        [Required(ErrorMessage = "Please enter")]
        public string Name { get; set; }
        
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter")]
        public string Description { get; set; }
        
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Enter positive price")]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "Please enter")]
        public string Category { get; set; }
        
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}