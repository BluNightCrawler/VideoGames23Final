﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VideoGames23.Models
{
    public class Product
    {
        public long ProductID { get; set; }
        [Required(ErrorMessage ="Please enter a Title")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Please enter a Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a Price")]
        [Column(TypeName="decimal(8,2")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please enter a Genre")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please enter a System")]
        public string System { get; set; }
        public bool Active { get; set; }
    }
}
