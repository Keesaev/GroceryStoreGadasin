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
        public IQueryable<Category> Categories => context.Categories;

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
    }
}
