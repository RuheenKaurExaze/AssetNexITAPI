
using System.ComponentModel.DataAnnotations.Schema;
using AssetNex.API.Models.DTO.EWaste;



namespace AssetNex.API.Models.DTO.EWaste
{


    public class DisposeAssetRequestDto
    {
      
       
        public Guid AssetTypeId { get; set; }
        public required string AssetName { get; set; }
        public  required string Reason { get; set; }
        public required DateTime DisposedOn { get; set; }
        public required string DisposedBy { get; set; }
        public required string AssetType { get; set; }
        public required string Condition { get; set; }
        public required DateTime DateOfIssue { get; set; }
        public required DateTime WarrantyDate { get; set; }
        public  string Status { get; set; }
    }


}


