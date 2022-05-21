using CakeDessertShop.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CakeDessertShop.Helpers
{
    public interface ICombosHelper
    {
        
        Task<IEnumerable<SelectListItem>> GetComboStatesAsync();

        Task<IEnumerable<SelectListItem>> GetComboCategoriesAsync(IEnumerable<Category> filter);
        Task<IEnumerable<SelectListItem>> GetComboCitiesAsync(int stateId);

        Task<IEnumerable<SelectListItem>> GetComboNeighborhoodsAsync(int cityId);
        Task<IEnumerable<SelectListItem>> GetComboCategoriesAsync();
    }
}
