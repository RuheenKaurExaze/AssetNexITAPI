using AssetNex.API.Data;
using AssetNex.API.Hubs;
using AssetNex.API.Models.DomainModel;
using AssetNex.API.Models.DTO.EWaste;
using AssetNex.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;


namespace AssetNex.API.Repositories.Implementation
{
    public class AlertsRepository : IAlertsRepository
    {
        private readonly ApplicationDbContext dbContext;

        public AlertsRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

     

        public async Task<InventoryAlert?> DeleteAsync(int Id)
        {
            var existingAsset = await dbContext.InventoryAlert.FirstOrDefaultAsync(x => x.Id == Id);

            if (existingAsset != null)
            {
                return null;

            }

            dbContext.InventoryAlert.Remove(existingAsset);
            await dbContext.SaveChangesAsync();
            return existingAsset;
        }

        public async Task<List<InventoryAlert>> getAllStock()
        {

         
            return await dbContext.InventoryAlert
           .Select(a => new InventoryAlert
           {
               CreatedAt = a.CreatedAt,
               StockQuantity = a.StockQuantity,
               AssetId = a.AssetId,
               Id = a.Id,
               Threshold = a.Threshold,
               AssetName = a.AssetName,
               Level = a.Level,
               Message = a.Message,
           }).ToListAsync();


        }

        public async Task<InventoryAlert?> GetByAssetIdAsync(int assetId)
        {
            return await dbContext.InventoryAlert.FirstOrDefaultAsync(a => a.AssetId == assetId);
        }

        public async Task<InventoryAlert?> GetByIdAsync(int id)
        {
            return await dbContext.InventoryAlert.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<InventoryAlert?> UpdateAsync(InventoryAlert realalert)
        {
            var alert = await dbContext.InventoryAlert.FirstOrDefaultAsync(x => x.Id == realalert.Id);

            if (alert != null)
            {
                dbContext.Entry(alert).CurrentValues.SetValues(realalert);
                await dbContext.SaveChangesAsync();
                return realalert;

            }

            return null;
        }

        public async Task<InventoryAlert> UpdateStockAsync(int assetId, int newStock)
        {

         


                var alert = await dbContext.InventoryAlert.FirstOrDefaultAsync(a => a.AssetId == assetId);
            if (alert == null) throw new Exception("Asset not found");

            alert.StockQuantity = newStock;

            // Decide level
            if (newStock <= alert.Threshold)
                alert.Level = newStock == 0 ? "critical" : "warning";
            else
                alert.Level = "info";

            alert.Message = $"Stock for {alert.AssetName} is now {newStock}";

            await dbContext.SaveChangesAsync();
            return alert;


        }
    }

}


//}
//Role: Business logic +broadcasting(orchestration).

//IAlertService(interface)

//Defines the contract for higher-level alert operations (e.g., CheckAndBroadcastLowStockAsync, BroadcastAlertAsync).

//AlertService (implementation)

//Uses both the repository (for data) and SignalR hub (for broadcasting).

//Example:

//Gets asset from repo.

//Checks if stock is below threshold.

//Creates alert object.

//Saves it via repo.

//Broadcasts it via SignalR hub.

//Think of this layer as: “apply rules, then decide when to broadcast.”