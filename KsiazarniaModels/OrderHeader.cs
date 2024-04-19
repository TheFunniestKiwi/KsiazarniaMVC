using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace KsiazarniaModels
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }
        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        [ValidateNever]
        public AppUser AppUser { get; set; }
        [Required] public DateTime OrderDate { get; set; }
        public DateTime? ShippingDate { get; set; }
        public double OrderTotal { get; set; }
        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public string? TrackingNumber { get; set; }
        public string? Carrier { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public string? SessionId { get; set; }
        public string? PaymentIntentId { get; set; }
        [Required] public string PhoneNumber { get; set; }
        [Required] public string Street { get; set; }
        [Required] public string City { get; set; }
        [Required] public string Province { get; set; }
        [Required] public string PostalCode { get; set; }
        [Required] public string Name { get; set; } 

    }
}
