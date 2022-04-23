using CakeDessertShop.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CakeDessertShop.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<SelectListItem>> GetComboStatesAsync()
        {
            List<SelectListItem> list = await _context.States.Select(s => new SelectListItem
            {
                Text = s.Name,
                Value = s.Id.ToString(),
            })
                .OrderBy(s => s.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem { Text = "[Seleccione un estado/departamento...]", Value = "0" });

            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboCitiesAsync(int stateId)
        {
            List<SelectListItem> list = await _context.Cities
                .Where(c => c.State.Id == stateId)
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                })
                .OrderBy(c => c.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem { Text = "[Seleccione una ciudad...]", Value = "0" });

            return list;
        }


        public async Task<IEnumerable<SelectListItem>> GetComboNeighborhoodsAsync(int cityId)
        {
            List<SelectListItem> list = await _context.Neighborhoods
                .Where(n => n.City.Id == cityId)
                .Select(n => new SelectListItem
                {
                    Text = n.Name,
                    Value = n.Id.ToString(),
                })
                .OrderBy(n => n.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem { Text = "[Seleccione un barrio...]", Value = "0" });

            return list;
        }
       
    }
}
