using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public interface IGroceryRepository
    {
        IQueryable<Product> Products { get; }
        IQueryable<Category> Categories { get; }
    }
}
