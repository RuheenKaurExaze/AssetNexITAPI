using AssetNex.API.Models.DomainModel;
using System.Threading.Tasks;

namespace AssetNex.API.Services
{
    public interface IAlertService
    {
        Task CheckAndBroadcastLowStockAsync(int assetId, int newStock);
        Task BroadcastAlertAsync(InventoryAlert alert);
   
    }
}
