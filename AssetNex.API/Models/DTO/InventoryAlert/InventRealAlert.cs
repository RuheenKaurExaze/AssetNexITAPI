namespace AssetNex.API.Models.DTO.InventoryAlert
{
    public class InventRealAlert
    {
        public int Id { get; set; }

        public int AssetId { get; set; } 

        public string AssetName { get; set; }
        public int StockQuantity { get; set; }

        public int Threshold { get; set; }


        public string Level { get; set; }
        public string Message { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
