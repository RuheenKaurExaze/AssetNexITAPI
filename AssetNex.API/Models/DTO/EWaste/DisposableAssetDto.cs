using System.ComponentModel.DataAnnotations.Schema;

namespace AssetNex.API.Models.DTO.EWaste    
{
    public class DisposableAssetDto
    {
        
        public required string AssetName { get; set; }
        public required string Reason { get; set; }
        public required string DisposedBy { get; set; } // optional: user/email
        public required string Condition { get; set; } // e.g. Damaged, Obsolete


        public  Guid AssetTypeId { get; set; }

        //public  DateTime DisposedOn { get; set; }

        public string AssetType { get; set; }
   
        public  DateTime DateOfIssue { get; set; }
        public  DateTime WarrantyDate { get; set; }

        public  string Status { get; set; }



    }
}

