using System.ComponentModel.DataAnnotations;

namespace KsiazarniaModels
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        [Display(Name ="Postal Code")]
        public string? PostalCode { get; set; }
        [Display(Name = "Phone Number")]
        [StringLength(9)]
        public string? PhoneNumber { get; set; }
    }
}
