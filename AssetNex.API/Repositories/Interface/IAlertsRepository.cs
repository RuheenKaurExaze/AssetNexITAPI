
using AssetNex.API.Models.DomainModel;

namespace AssetNex.API.Repositories.Interface
{
    public interface IAlertsRepository
    {
        Task<InventoryAlert?> GetByAssetIdAsync(int assetId);
        Task<InventoryAlert> UpdateStockAsync(int assetId, int newStock);

        Task<List<InventoryAlert>> getAllStock();

        Task<InventoryAlert?> UpdateAsync(InventoryAlert realalert);

        Task<InventoryAlert?> GetByIdAsync(int id);


        Task<InventoryAlert?> DeleteAsync(int Id);




    }
}
