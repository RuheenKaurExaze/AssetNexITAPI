
using System.ComponentModel.DataAnnotations;

namespace AssetNex.API.Models.DomainModel
{
    public class EWaste
    {
        [Key]
        public Guid Id { get; set; }


        [Required]
        public Guid AssetTypeId { get; set; }

        public string AssetName { get; set; }

        [Required]
        public required string AssetType { get; set; }

        [Required]
        public required string Reason { get; set; }

        [Required]
        public DateTime DisposedOn { get; set; }

        [Required]
        public required string DisposedBy { get; set; }

        [Required]
        public required string Condition { get; set; }

        [Required]
        public DateTime DateOfIssue { get; set; }

        [Required]
        public DateTime WarrantyDate { get; set; }

        public required string Status { get; set; }
    }
}
