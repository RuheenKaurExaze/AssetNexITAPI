using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AssetNex.API.Data;
using AssetNex.API.Models.DomainModel;
using AssetNex.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace AssetNex.API.Repositories.Implementation
{
    public class SupportRepository : ISupportRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SupportRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<NewSupport?> GetSupportTypeByIdAsync(Guid id)
        {

            return await dbContext.NewSupports
                //.Include(a => a.UserName)            
                //.Include(a => a.AssetType)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        //post
        public async Task<NewSupport?> CreateAsync(NewSupport newSupport)
        {
            await dbContext.NewSupports.AddAsync(newSupport);

            await dbContext.SaveChangesAsync();

            return newSupport;
        }

        //get
        public async Task<List<NewSupport>> getAllSupport()
        {
            return await dbContext.NewSupports

                        //.Include(a => a.AssetType)
                        .ToListAsync();

        }


        //getbyid
        public async Task<NewSupport?> GetSupportByIdAsync(Guid id)
        {
            return await dbContext.NewSupports.FirstOrDefaultAsync(t => t.Id == id);
        }

    

        
        //{
        //    var existingSupport= await dbContext.NewSupports.FirstOrDefaultAsync(a => a.Id == support.Id);

        //    if (existingSupport != null)
        //    {
        //        await dbContext.SaveChangesAsync();
        //        dbContext.Entry(existingSupport).CurrentValues.SetValues(support);
        //        return support;
        //    }
        //}
        
        public async Task<NewSupport?> UpdateAsync(NewSupport support)
        {

            {
                var existingSupport = await dbContext.NewSupports.FirstOrDefaultAsync(x => x.Id == support.Id);


                if (existingSupport != null)
                {
                    dbContext.Entry(existingSupport).CurrentValues.SetValues(support);
                    await dbContext.SaveChangesAsync();
                    return support;

                }

                return null;
            }
        }


        //for deleting

        public async Task<NewSupport?> GetById(Guid id)
        {
            return await dbContext.NewSupports.FirstOrDefaultAsync(x => x.Id == id);

        }

       


        //public async Task<NewSupport?> DeleteAsync(Guid id)
        //{
        //    var existingSupport = await dbContext.NewSupports.FirstOrDefaultAsync(x=> x.Id== id);


        //    if (existingSupport! = null)
        //    {
        //        return null;
        //    }

        //    dbContext.NewSupports.Remove(existingSupport);
        //    await dbContext.SaveChangesAsync();
        //    return existingSupport;

        //}

        public async Task<NewSupport?> DeleteAsync(Guid id)
        {
            var existingSupport = await dbContext.NewSupports.FirstOrDefaultAsync(x => x.Id == id);

            if (existingSupport != null)
            {
                return null;

            }

            dbContext.NewSupports.Remove(existingSupport);
            await dbContext.SaveChangesAsync();
            return existingSupport;

        }

       
}
}






