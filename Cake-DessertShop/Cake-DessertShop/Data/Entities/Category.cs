﻿using System.ComponentModel.DataAnnotations;

namespace CakeDessertShop.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Categoría")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caractéres")]
        [Required(ErrorMessage = ("El campo {0} es obligatorio."))]
        public string Name { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }

        [Display(Name = "Cantidad Productos")]
        public int ProductsNumber => ProductCategories == null ? 0 : ProductCategories.Count();

    }
}
