using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStore.Models;

namespace GroceryStore.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product{ Name = "Burger", Price = 25},
            new Product{ Name = "Pizza", Price = 25},
            new Product{ Name = "Meatball", Price = 25}
        }.AsQueryable<Product>();
    }
}
