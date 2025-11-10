

namespace AssetNex.API.Models.DTO.EWaste
{
    public class DisposedAssetDto
    {


        public Guid AssetTypeId { get; set; }
        public required string Reason { get; set; }
        public required string AssetName { get; set; }
        public DateTime DisposedOn { get; set; }
        public required string DisposedBy { get; set; }
        public DateTime DisposedAt { get; set; }
        public required string Condition { get; set; }

        public DateTime DateOfIssue { get; set; }

        public DateTime WarrantyDate { get; set; }

        public  Guid Id { get; set; }
        
        public  string Status { get; set; }


    }
    
}



