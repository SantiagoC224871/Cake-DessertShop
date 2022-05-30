using System.ComponentModel.DataAnnotations;

namespace CakeDessertShop.Data.Entities
{
    public class State
    {
        public int Id { get; set; }

        [Display(Name="Departamento")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caractéres")]
        [Required(ErrorMessage = ("El campo {0} es obligatorio."))] 
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }

        [Display(Name = "Ciudades")]
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;

        [Display(Name = "Barrios")]
        public int NeighbodhoodsNumber => Cities == null ? 0 : Cities.Sum(c => c.NeighborhoodsNumber);

    }
}
