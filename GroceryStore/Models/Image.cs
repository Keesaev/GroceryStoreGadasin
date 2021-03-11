using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string ThumbnailImage { get; set; }
        public string FullImage { get; set; }
    }
}
