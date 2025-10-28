using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AssetNex.API.Models.DomainModel
{
    public class AssetInfo
    {
  
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string SerialNumber { get; set; }
        public required string Department {  get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime WarrantyDate { get; set; }
        public Guid UserId { get; set; }
        public  string User { get; set; }
        public required string Status { get; set; }

        //FOREIGNKEY
        public Guid AssetTypeId { get; set; }

        [ForeignKey ("AssetTypeId")]
        public  AssetType AssetType { get; set; }


    }
}
