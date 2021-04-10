using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите имя")]
        [BindNever]
        public bool Shipped { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите адрес")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Пожалуйста, выберите способ оплаты")]
        public int Payment { get; set; }
    }
}
