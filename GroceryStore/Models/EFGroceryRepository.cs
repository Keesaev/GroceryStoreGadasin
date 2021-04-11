using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public class EFGroceryRepository : IGroceryRepository
    {
        private ApplicationDbContext context;
        public EFGroceryRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Product> Products => context.Products;

        public IQueryable<Order> Orders => context.Orders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.Id == 0)
                context.Orders.Add(order);
            context.SaveChanges();
        }
        public void SaveProduct(Product product)
        {
            if(product.Id == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products
                    .FirstOrDefault(p => p.Id == product.Id);
                if(dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            context.SaveChanges();
        }
        public Product DeleteProduct(int Id)
        {
            Product dbEntry = context.Products
                .FirstOrDefault(p => p.Id == Id);
            if(dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        IQueryable<User> IGroceryRepository.Users => context.Users;
        public void SaveUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
