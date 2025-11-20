using AssetNex.API.Data;
using AssetNex.API.Models.DomainModel;
using AssetNex.API.Models.DTO.LiveTracking;
using AssetNex.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace AssetNex.API.Repositories.Implementation
{
    public class LocationRepository : ILocationRepository
    {

        private readonly ApplicationDbContext dbContext;

        public LocationRepository(ApplicationDbContext dbContext)

        {
            this.dbContext = dbContext;
        }

        public async Task<List<LiveLocation>> getAllLocation()

        {
            return await dbContext.Location.ToListAsync();
        }

        public async Task AddLocationAsync(LiveLocation Location)
        {
            await dbContext.Location.AddAsync(Location);
            await dbContext.SaveChangesAsync();
        }
        public async Task<LiveLocation?> GetLocationByIdAsync(int Id)

        {
            return await dbContext.Location.FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<LiveLocation?> UpdateAsync(LiveLocation Location)
        {
            var existingAsset = await dbContext.Location.FirstOrDefaultAsync(x => x.Id == Location.Id);
            if (existingAsset != null)
            {
                dbContext.Entry(existingAsset).CurrentValues.SetValues(Location);
                await dbContext.SaveChangesAsync();
                return Location;
            }
            return null;
        }

        public async Task<LiveLocation?> DeleteAsync(int Id)
        {
            var existingAsset = await dbContext.Location.FirstOrDefaultAsync(x => x.Id == Id);

            if (existingAsset != null)
            {
                return null;
            }

            dbContext.Location.Remove(existingAsset);
            await dbContext.SaveChangesAsync();
            return existingAsset;
        }
        public async Task<LiveLocation?> UpdateTheLocationAsync(LiveLocation Location)
        {
            var existingAsset = await dbContext.Location.FirstOrDefaultAsync(x => x.Id == Location.Id);
            if (existingAsset != null)
            {
                dbContext.Entry(existingAsset).CurrentValues.SetValues(Location);
                await dbContext.SaveChangesAsync();
                return Location;

            }

            return null;

        }
        public async Task<List<AssetLocations>> getAssetLocation()
        {
            return await dbContext.AssetLocations.ToListAsync();
        }
        public async Task<IEnumerable<LiveLocation>> GetAllLocationAsync()
        {
            return await dbContext.Location.ToListAsync();

        }
        public Task AddAssetLocationAsync(AssetLocationDto location)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<AssetLocations>> ILocationRepository.GetAssetLocationAsync()
        {
            return await dbContext.AssetLocations.ToListAsync();
        }

        public async Task<AssetLocations?> GetByLocationId(int Id)
        {
            return await dbContext.AssetLocations.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<LiveLocation?> GetById(int Id)
        {
            return await dbContext.Location.FirstOrDefaultAsync(x => x.Id == Id);

        }
        public async Task AddAssetLocationAsync(AssetLocations location)
        {
            await dbContext.AssetLocations.AddAsync(location);
            await dbContext.SaveChangesAsync();
        }
    }

}

