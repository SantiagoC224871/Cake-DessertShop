using CakeDessertShop.Common;
using CakeDessertShop.Models;

namespace CakeDessertShop.Helpers
{
    public interface IOrdersHelper
    {
        Task<Response> ProcessOrderAsync(ShowCartViewModel model);
    }

}
