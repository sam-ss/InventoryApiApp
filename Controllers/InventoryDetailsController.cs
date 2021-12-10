using InventoryApiApp.Interface;
using InventoryApiApp.Models;
using InventoryApiApp.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace InventoryApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryDetailsController : ControllerBase
    {
        private readonly InventoryService _inventoryService;

        private readonly IRepository<Inventory> _inventory;

        public InventoryDetailsController(IRepository<Inventory> Inventory, InventoryService InventoryService)
        {
            _inventoryService = InventoryService;
            _inventory = Inventory;

        }
        //Add Inventory
        [HttpPost("AddInventory")]
        public async Task<Object> AddInventory([FromBody] Inventory inventory)
        {
            try
            {
                await _inventoryService.AddInventory(inventory);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //Delete inventory
        [HttpDelete("DeleteInventory")]
        public bool DeleteInventory(string name)
        {
            try
            {
                _inventoryService.DeleteInventory(name);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Delete inventory
        [HttpPut("UpdateInventory")]
        public bool UpdateInventory(Inventory Object)
        {
            try
            {
                _inventoryService.UpdateInvetory(Object);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //GET All inventory by Name
        [HttpGet("GetAllinventoryByName")]
        public Object GetAllInventoryByName(string name)
        {
            var data = _inventoryService.GetInventoryByName(name);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        //GET All inventory
        [HttpGet("GetAllInventory")]
        public Object GetAllinventorys()
        {
            var data = _inventoryService.GetAllInventorys();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
    }
}