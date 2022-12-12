using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dummyASPCoreMVC.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Name")]
        public string? CategoryName { get; set; }

        [Required]
        [Range (1, int.MaxValue,ErrorMessage ="Display Order must be greater than 0")]
        [DisplayName("Display Order")]
        public int CategoryDisplayOrder { get; set; }
    }
}
