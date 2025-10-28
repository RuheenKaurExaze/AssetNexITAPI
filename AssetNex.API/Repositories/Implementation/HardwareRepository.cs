using AssetNex.API.Data;
using AssetNex.API.Repositories.Interface;
using AssetNex.API.Models.DomainModel;
using AssetNex.API.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace AssetNex.API.Repositories.Implementation
{
    public class HardwareRepository : IHardwareRepository
    {

        private readonly ApplicationDbContext dbContext;

        public HardwareRepository(ApplicationDbContext dbContext)

        {
            this.dbContext = dbContext;

        }

        public async Task<List<Hardware>> getAllHardware()

        {

            return await dbContext.Hardware.ToListAsync();

        }




        //getall

        public async Task AddHardwareAsync(Hardware hardware)
        {
            await dbContext.Hardware.AddAsync(hardware);
            await dbContext.SaveChangesAsync();


        }
        public async Task<Hardware?> GetHardwareByIdAsync(Guid id)

        {
            return await dbContext.Hardware

             .FirstOrDefaultAsync(a => a.Id == id);
        }


        public async Task<Hardware?> GetHardwareTypeByIdAsync(Guid id)

        {
            return await dbContext.Hardware.FirstOrDefaultAsync(t => t.Id == id);

        }//post


        public async Task<Hardware?> GetById(Guid id)
        {
            return await dbContext.Hardware.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Hardware?> UpdateAsync(Hardware hardware)
        {
            var existingAsset = await dbContext.Hardware.FirstOrDefaultAsync(x => x.Id == hardware.Id);

            if (existingAsset != null)
            {
                dbContext.Entry(existingAsset).CurrentValues.SetValues(hardware);
                await dbContext.SaveChangesAsync();
                return hardware;



            }

            return null;
        }//update-put


        public async Task<Hardware?> DeleteAsync(Guid id)
        {
            var existingAsset = await dbContext.Hardware.FirstOrDefaultAsync(x => x.Id == id);

            if (existingAsset != null)
            {
                return null;

            }

            dbContext.Hardware.Remove(existingAsset);
            await dbContext.SaveChangesAsync();
            return existingAsset;


        }


       

    }

};





    

