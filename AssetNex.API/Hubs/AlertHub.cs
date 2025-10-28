

using Microsoft.AspNetCore.SignalR;
using AssetNex.API.Models.DomainModel;

namespace AssetNex.API.Hubs
{
    public class AlertHub : Hub
    {
        public async Task SendAlert(InventoryAlert alert)
        {
            await Clients.All.SendAsync("ReceiveAlert", alert);
        }
    }
}
