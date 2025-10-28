using AssetNex.API.Models.DomainModel;
using AssetNex.API.Repositories.Interface;
using AssetNex.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace AssetNex.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertsController : ControllerBase
    {
        private readonly IAlertsRepository alertsRepository;
        private readonly IAlertService alertService;

        public AlertsController(IAlertsRepository alertsRepository, IAlertService alertService)
        {
            this.alertsRepository = alertsRepository;
            this.alertService = alertService;
        }

        [HttpPost("updatestock/{assetId}")]
        public async Task<IActionResult> UpdateStock(int assetId, [FromBody] int newStock)
        {
            await alertService.CheckAndBroadcastLowStockAsync(assetId, newStock);
            return Ok("message");
        }

        [HttpGet("realalerts")]
        public async Task<IActionResult> GetRealAlerts()
        {
            var assets = await alertsRepository.getAllStock();

            var response = assets.Select(stock => new InventoryAlert
            {
                Id = stock.Id,
                AssetId = stock.AssetId,
                AssetName = stock.AssetName,
                Threshold = stock.Threshold,
                StockQuantity = stock.StockQuantity,
                Level = stock.Level,
                Message = stock.Message,
                CreatedAt = stock.CreatedAt,
            }).ToList();


            var responsee = assets.Select(stock => new InventoryAlert

            {
                Id = stock.Id,
                AssetId = stock.AssetId,
                AssetName = stock.AssetName,
                Threshold = stock.Threshold,
                StockQuantity = stock.StockQuantity,
                Level = stock.Level,
                Message = stock.Message,
                CreatedAt = stock.CreatedAt,

            }).ToList();


            return Ok(response);
        }

        [HttpDelete("deleterealalerts")]
        public async Task<IActionResult> DeleteRealAlerts([FromBody] int id)
        {
            var currentRealAlerts = await alertsRepository.GetByIdAsync(id);

            if (currentRealAlerts == null)
                return NotFound();

            await alertsRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
