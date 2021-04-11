using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public interface IGroceryRepository
    {
        IQueryable<Product> Products { get; }
        IQueryable<Order> Orders { get; }
        IQueryable<User> Users { get; }
        void SaveOrder(Order order);
        void SaveProduct(Product product);
        void SaveUser(User user);
        Product DeleteProduct(int Id);
    }
}
