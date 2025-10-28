using AssetNex.API.Models.DomainModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetNex.API.Models.DTO.Asset
{
    public class CreateInventoryDto
    {
        public Guid Id { get; set; }
        public required string SerialNumber { get; set; }

        public required AssetType AssetType { get; set; }

        public Guid AssetTypeId { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime WarrantyDate { get; set; }

        [ForeignKey("AssetTypeId")]
       
        public Guid UserId { get; set; }

        public required string User { get; set; }

        public required string Status { get; set; }
  
        //public List<CreateInventoryDto> Assets { get; set; } = new List<CreateInventoryDto>();


    }
}
