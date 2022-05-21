using CakeDessertShop.Data;
using CakeDessertShop.Data.Entities;
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

        public async Task<IEnumerable<SelectListItem>> GetComboCategoriesAsync()
        {
            List<SelectListItem> list = await _context.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            })
                .OrderBy(c => c.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem { Text = "[Seleccione una categoría...", Value = "0" });
            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboCategoriesAsync(IEnumerable<Category> filter)
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            List<Category> categoriesFiltered = new();
            foreach (Category category in categories)
            {
                if (!filter.Any(c => c.Id == category.Id))
                {
                    categoriesFiltered.Add(category);
                }
            }

            List<SelectListItem> list = categoriesFiltered.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            })
                .OrderBy(c => c.Text)
                .ToList();

            list.Insert(0, new SelectListItem { Text = "[Seleccione una categoría...", Value = "0" });
            return list;
        }

    }
}
