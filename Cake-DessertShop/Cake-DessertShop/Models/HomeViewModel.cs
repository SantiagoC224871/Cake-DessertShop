using CakeDessertShop.Data.Entities;

namespace CakeDessertShop.Models
{
    public class HomeViewModel
    {
        public ICollection<Product> Products { get; set; }

        public float Quantity { get; set; }


    }

}
