using InventoryApiApp.Interface;
using InventoryApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApiApp.Service
{
    public class InventoryService
    {
        private readonly IRepository<Inventory> _inventory;

        public InventoryService(IRepository<Inventory> inventory)
        {
            _inventory = inventory;
        }
        //Get inventory Details By Id
        public IEnumerable<Inventory> GetInventoryById(int UId)
        {
            return _inventory.GetAll().Where(x => x.Id == UId).ToList();
        }
        //GET All invetory Details 
        public IEnumerable<Inventory> GetAllInventorys()
        {
            try
            {
                return _inventory.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Get inventory by inventory Name
        public Inventory GetInventoryByName(string Name)
        {
            return _inventory.GetAll().Where(x => x.Name == Name).FirstOrDefault();
        }
        //Add inventory
        public async Task<Inventory> AddInventory(Inventory inventory)
        {
            return await _inventory.Create(inventory);
        }
        //Delete Inventory 
        public bool DeleteInventory(string name)
        {

            try
            {
                var DataList = _inventory.GetAll().Where(x => x.Name == name).ToList();
                foreach (var item in DataList)
                {
                    _inventory.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }
        //Update inventory Details
        public bool UpdateInvetory(Inventory inventory)
        {
            try
            {
                var DataList = _inventory.GetAll().Where(x => x.IsDeleted != true).ToList();
                foreach (var item in DataList)
                {
                    _inventory.Update(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}