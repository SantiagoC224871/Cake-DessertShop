﻿using System.ComponentModel.DataAnnotations;

namespace CakeDessertShop.Models
{
    public class RecoverPasswordViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debes ingresar un correo válido.")]
        public string Email { get; set; }
    }

}
