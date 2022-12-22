using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShopProject.Models.Models
{
    public class Pie
    { 
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Pie Name is required.")]
        [RegularExpression("^((?!City)[a-zA-Z '])+$", ErrorMessage = "Pie Name can only contain characters.")]
        [StringLength(20)]
        public string Name { get; set; }

        
        public string Description { get; set; }
        [Required(ErrorMessage = "Pie Price is required.")]
        public double Price { get; set; }

        [ValidateNever]
        public string Image { get; set; }
    }
}
