﻿using System.ComponentModel.DataAnnotations;

namespace CakeDessertShop.Data.Entities
{
    public class Neighborhood
    {
        public int Id { get; set; }

        [Display(Name = "Barrio")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caractéres")]
        [Required(ErrorMessage = ("El campo {0} es obligatorio."))]
        public string Name { get; set; }

        public City City { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
