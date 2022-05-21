using System.ComponentModel.DataAnnotations;

namespace CakeDessertShop.Data.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        //TODO: Pending to change to the correct path
        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:7070/images/noimage.png"
            : $"https://shoppingscm.blob.core.windows.net/products/{ImageId}";
    }

}
