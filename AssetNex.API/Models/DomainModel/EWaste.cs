using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetNex.API.Models.DomainModel
{
    public class EWaste
    {
        [Key]
        public Guid Id { get; set; }

        // Foreign key to AssetType
        [Required]
        public Guid AssetTypeId { get; set; }

        public string AssetName { get; set; }

        [Required]
        public required string AssetType { get; set; }  // E.g., Laptop, Monitor

        [Required]
        public required string Reason { get; set; }     // Why it's being disposed

        [Required]
        public DateTime DisposedOn { get; set; }  // Disposal date

        [Required]
        public required string DisposedBy { get; set; }     //email

        [Required]
        public required string Condition { get; set; }     // Damaged, Obsolete, etc.

        [Required]
        public DateTime DateOfIssue { get; set; }

        [Required]
        public DateTime WarrantyDate { get; set; }

        public required string Status { get; set; }
    }
}
//Id Guid	Yes	Hidden (auto)
//AssetId	Guid (FK)	Yes	Select Asset
//UserName	string	Yes	Name
//EmployeeId	string	Yes	Employee ID
//Reason	string	Optional	Reason for disposal
//DateRequested	DateTime	Yes	Auto-filled
//Status	string	No	Pending / Approved / Rejected