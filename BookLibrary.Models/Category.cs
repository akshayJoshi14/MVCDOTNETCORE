using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Dispaly order must be between 1 to 100 only!!")]
        // check more DataAnnotation with 
        // https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-6.0
        public int DisplayOrder { get; set; }

        // to assign curret date by default
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
