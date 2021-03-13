using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Models.ViewModels
{
    public class CurrentCartIndexViewModel
    {
        public CurrentCart CurrentCart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
