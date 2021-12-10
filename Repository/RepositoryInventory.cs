using InventoryApiApp.Data;
using InventoryApiApp.Interface;
using InventoryApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApiApp.Repository
{
    public class RepositoryInventory : IRepository<Inventory>
    {
        ApplicationDbContext _dbContext;
        public RepositoryInventory(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Inventory> Create(Inventory _object)
        {
            var obj = await _dbContext.Inventorys.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Inventory _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Inventory> GetAll()
        {
            try
            {
                return _dbContext.Inventorys.Where(x => x.IsDeleted == false).ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public Inventory GetById(int Id)
        {
            return _dbContext.Inventorys.Where(x => x.IsDeleted == false && x.Id == Id).FirstOrDefault();
        }

        public void Update(Inventory _object)
        {
            _dbContext.Inventorys.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}
