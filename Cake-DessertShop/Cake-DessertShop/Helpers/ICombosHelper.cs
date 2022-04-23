using Microsoft.AspNetCore.Mvc.Rendering;

namespace CakeDessertShop.Helpers
{
    public interface ICombosHelper
    {
        
        Task<IEnumerable<SelectListItem>> GetComboStatesAsync();

        Task<IEnumerable<SelectListItem>> GetComboCitiesAsync(int stateId);

        Task<IEnumerable<SelectListItem>> GetComboNeighborhoodsAsync(int cityId);

    }
}
