using System.ComponentModel.DataAnnotations.Schema;

namespace AssetNex.API.Models.DomainModel
{
    public class Hardware
    {
        public Guid Id { get; set; }
        public string ProblemDescription { get; set; } 

        [ForeignKey("AssetType")]
        public Guid AssetTypeId { get; set; } 

        public required string SerialNumber { get; set; }
        public required string AssetName { get; set; }   
        public required string AssetType { get; set; } 
        public required DateTime DateSubmitted { get; set; } = DateTime.UtcNow;

        public required DateTime DateOfIssue { get; set; }

        public required DateTime WarrantyDate { get; set; }

    }
}
