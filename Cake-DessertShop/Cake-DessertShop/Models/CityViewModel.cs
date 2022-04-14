using System.ComponentModel.DataAnnotations;

namespace CakeDessertShop.Models
{
    public class CityViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Departamento")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caractéres")]
        [Required(ErrorMessage = ("El campo {0} es obligatorio."))]
        public string Name { get; set; }

        public int StateId { get; set; }
    }
}
