namespace AssetNex.API.Models.DomainModel
{
    public class InventoryAlert
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string AssetName { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
        public int Threshold { get; set; }
        public string Level { get; set; } = "info";
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
