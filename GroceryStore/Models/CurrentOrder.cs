using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public class CurrentOrder
    {
        [BindNever]
        public int OrderId { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите адрес")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите номер телефона")]
        public string Number { get; set; }
        [Required(ErrorMessage = "Пожалуйста, выберите способ оплаты")]
        public int Payment { get; set; }

    }
}
