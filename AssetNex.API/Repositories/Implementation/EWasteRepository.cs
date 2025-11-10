using AssetNex.API.Data;
using AssetNex.API.Models.DomainModel;
using AssetNex.API.Models.DTO.EWaste;
using AssetNex.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;


namespace AssetNex.API.Repositories.Implementation
{
    public class EWasteRepository : IEWasteRepository
    {
        private readonly ApplicationDbContext dbContext;

        public EWasteRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<DisposableAssetDto>> GetDisposableAssetsAsync()
        {

            return await dbContext.DisposableAssets
                .Select(a => new DisposableAssetDto
                {

                    AssetName = a.AssetName,
                    Reason = a.Reason,
                    DisposedBy = a.DisposedBy,
                    Condition = a.Condition
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<DisposedAssetDto>> GetDisposedAssetsAsync()
        {
            return await dbContext.DisposedAssets
                .Select(a => new DisposedAssetDto
                {
                    AssetTypeId = a.AssetTypeId,
                    AssetName = a.AssetName,
                    Reason = a.Reason,
                    DisposedOn = a.DisposedOn,
                    DisposedBy = a.DisposedBy,
                    DisposedAt = a.DisposedOn,
                    Condition = a.Condition,
                    DateOfIssue = a.DateOfIssue,
                    WarrantyDate = a.WarrantyDate
                })
                .ToListAsync();
        }

        public async Task DisposeAssetAsync(DisposeAssetRequestDto request)
        {
            var waste = new EWaste
            {
                Id = Guid.NewGuid(),
                AssetTypeId = request.AssetTypeId,
                AssetName = request.AssetType,
                Reason = request.Reason,
                DisposedBy = request.DisposedBy,
                DisposedOn = DateTime.UtcNow,
                AssetType = request.AssetType,
                Condition = request.Condition,
                DateOfIssue = request.DateOfIssue,
                WarrantyDate = request.WarrantyDate,
                Status = "Pending"
            };

            await dbContext.EWastes.AddAsync(waste);
            await dbContext.SaveChangesAsync();



            dbContext.DisposedAssets.Add(waste);

            var disposableAsset = await dbContext.DisposableAssets.FindAsync(request.AssetTypeId);
            if (disposableAsset != null)
            {
                dbContext.DisposableAssets.Remove(disposableAsset);
            }

            await dbContext.SaveChangesAsync();
        }



        public async Task DeleteDisposableAssetAsync(Guid assetId)
        {
            var asset = await dbContext.DisposableAssets.FindAsync(assetId);
            if (asset != null)
            {
                dbContext.DisposableAssets.Remove(asset);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<EWaste?> GetEWasteTypeByIdAsync(Guid assetTypeId)
        {
            return await dbContext.EWastes
                .FirstOrDefaultAsync(e => e.AssetTypeId == assetTypeId);
        }

        public async Task<EWaste?> UpdateDisposedAssetAsync(EWaste ewaste)
        {
            var existingAsset = await dbContext.EWastes.FirstOrDefaultAsync(x => x.Id == ewaste.Id);

            if (existingAsset != null)
            {
                dbContext.Entry(existingAsset).CurrentValues.SetValues(ewaste);
                await dbContext.SaveChangesAsync();
                return ewaste;
            }

            return null;
        }

        public async Task<List<EWaste>> GetDisposedAssets()
        {
            return await dbContext.EWastes.ToListAsync();
        }

        public async Task AddEWasteAsync(EWaste ewaste)
        {
            await dbContext.EWastes.AddAsync(ewaste);
            await dbContext.SaveChangesAsync();
        }


        public async Task<EWaste?> GetEWasteByIdAsync(Guid id)
        {
            return await dbContext.EWastes.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<EWaste?> GetById(Guid id)
        {

            return await dbContext.EWastes.FirstOrDefaultAsync(x => x.Id == id);
        }
    }


}

