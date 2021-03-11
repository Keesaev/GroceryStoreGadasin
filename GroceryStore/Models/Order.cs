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
        [Key]
        public int Id { get; set; }
        public Cart Cart { get; set; }
        public int CartId { get; set; }
        public Delivery Delivery { get; set; }
        public int DeliveryId { get; set; }
        public double Price { get; set; }
        public int Payment { get; set; }
    }
}
