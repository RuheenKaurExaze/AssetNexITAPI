//using AssetNex.API.Data;
//using AssetNex.API.Models.DomainModel;
//using Microsoft.AspNetCore.SignalR;

//namespace AssetNex.API.Models.DomainModel
//{
//    public class Alerts
//    {
//        public int Id { get; set; }

//        public string Message { get; set; }

//        public int DaysLeft { get; set; }

//        public string text { get; set; }


//        public string Warning { get; set; }



//        public int AssetId { get; set; }
//        public string AssetName { get; set; }
//        public int CurrentStock { get; set; }
//        public int Threshold { get; set; }
//        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
//        public string Level { get; set; }

//    }
//}




//using Microsoft.AspNetCore.SignalR;
//using Microsoft.EntityFrameworkCore;

//public class InventoryAlertService : IInventoryAlertService
//{
//    private readonly IHubContext<AlertsHub> _hub;
//    private readonly ApplicationDbContext _db; // your EF db
//    private readonly ILogger<InventoryAlertService> _logger;

//    public InventoryAlertService(IHubContext<AlertsHub> hub, ApplicationDbContext db, ILogger<InventoryAlertService> logger)
//    {
//        _hub = hub;
//        _db = db;
//        _logger = logger;
//    }

//    // Example: scan DB for low stock and broadcast alerts
//    public async Task CheckAndBroadcastLowStockAsync()
//    {
//        var lowItems = await _db.Assets
//            .Where(a => a.StockQuantity <= a.ReorderThreshold)
//            .ToListAsync();

//        foreach (var item in lowItems)
//        {
//            var level = item.StockQuantity == 0 ? "critical" : "warning";
//            var alert = new InventoryAlert
//            {
//                AssetId = item.Id,
//                AssetName = item.Name,
//                CurrentStock = item.StockQuantity,
//                Threshold = item.ReorderThreshold,
//                Level = level,
//                Message = $"Low stock for {item.Name}: {item.StockQuantity} left"
//            };

//            // optionally persist to DB table Alerts
//            //_db.InventoryAlerts.Add(alert);
//            //await _db.SaveChangesAsync();
    
//            await BroadcastAlertAsync(alert);
//        }
//    }

//    public async Task BroadcastAlertAsync(InventoryAlert alert)
//    {
//        // Broadcast to all clients — refine to groups/users if needed
//        await _hub.Clients.All.SendAsync("ReceiveInventoryAlert", alert);
//        _logger.LogInformation("Broadcasted alert for asset {Id}", alert.AssetId);
//    }
//}
