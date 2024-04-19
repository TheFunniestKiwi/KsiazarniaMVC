using System.ComponentModel.DataAnnotations;

namespace KsiazarniaModels
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Cover Type")]
        [Required]
        public string Name { get; set; }
    }
}
