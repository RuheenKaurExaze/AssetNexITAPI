namespace AssetNex.API.Models.DTO.Asset
{
    public class UpdateAssetRequestDto
    {
         
        public required string Name { get; set; }

        public required string SerialNumber { get; set; }

        public required string Department { get; set; }

        public DateTime DateOfIssue { get; set; }

        public DateTime WarrantyDate { get; set; }

        public Guid AssetTypeId { get; set; }

        public required string Status { get; set; }

        public Guid UserId { get; set; }



}
}
