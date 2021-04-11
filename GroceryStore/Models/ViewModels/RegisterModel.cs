using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Models.ViewModels
{
    public class RegisterModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
