using AssetNex.API.Models.DomainModel;
using System.ComponentModel.DataAnnotations;

namespace AssetNex.API.Models.DTO.EWaste
{
    public class UpdateEDisposeAssetRequestDto
    {

      
        public Guid Id { get; internal set; }
        public  string AssetTypeId { get; set; }

        public required string AssetName { get; set; }

        [Required]
        public  required string AssetType { get; set; }
       
    
        public required string Reason { get; set; }
        
        public  DateTime DisposedOn { get; set; }

        public required string DisposedBy { get; set; }

        public required string Condition { get; set; }


        public  DateTime DateOfIssue { get; set; }
 
        public  DateTime WarrantyDate { get; set; }

        public required string Status { get; set; }
    }
}


      




