

namespace AssetNex.API.Models.DTO.Hardware
{
    public class CreateHardwareDto
    {
        public Guid Id { get; set; }    
        public required string ProblemDescription { get; set; } 

        public Guid AssetTypeId { get; set; }

        public required string SerialNumber { get; set; }
        public required string AssetName { get; set; } 
        public required string AssetType { get; set; } 
        public DateTime DateSubmitted { get; set; } = DateTime.UtcNow;

        public DateTime DateOfIssue { get; set; }

        public DateTime WarrantyDate { get; set; }


    }
}
