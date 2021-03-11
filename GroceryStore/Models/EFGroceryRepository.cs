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
    }
}
