using Api.DotNet.Domain.Entities;
using Api.DotNet.Domain.Repositories;
using Api.DotNet.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.DotNet.Infra.Data.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext _db;

        public PurchaseRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Purchase> CreateAsync(Purchase purchase)
        {
            _db.Add(purchase);
            await _db.SaveChangesAsync();
            return purchase;
        }

        public async Task DeleteAsync(Purchase purchase)
        {
            _db.Remove(purchase);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Purchase purchase)
        {
            _db.Update(purchase);
            await _db.SaveChangesAsync();
        }

        public async Task<Purchase> GetByIdAsync(int id)
        {
            return await _db.Purchases
                            .Include(x => x.Product)
                            .Include(x => x.Person)
                            .FirstOrDefaultAsync(x => x.Id == id);

             
        }

        public async Task<ICollection<Purchase>> GetByPersonIdAsync(int personId)
        {
            return await _db.Purchases
                            .Include(x => x.Product)
                            .Include(x => x.Person)
                            .Where(x => x.PersonId == personId).ToListAsync();

        }

        public async Task<ICollection<Purchase>> GetByProductIdAsync(int productId)
        {
            return await _db.Purchases
                            .Include(x => x.Product)
                            .Include(x => x.Person)
                            .Where(x => x.ProductId == productId).ToListAsync();


        }

        public async Task<ICollection<Purchase>> GetAllAsync()
        {
            return await _db.Purchases
                            .Include(x => x.Product)
                            .Include(x => x.Person)
                            .ToListAsync();
        }
    }
}


