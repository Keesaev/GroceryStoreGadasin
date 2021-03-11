using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public class Delivery
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public bool Delivered { get; set; }
    }
}
