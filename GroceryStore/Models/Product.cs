using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Image Image { get; set; }
        public int ImageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public bool Stock { get; set; }
    }
}
