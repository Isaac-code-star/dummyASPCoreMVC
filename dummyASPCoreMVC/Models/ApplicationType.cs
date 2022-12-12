using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace dummyASPCoreMVC.Models
{
    public class ApplicationType
    {
        [Key]
        public int TableID { get; set; }
        [Required]
        [DisplayName("Application Type Name")]
        public string? TableName { get; set; }
    }
}
