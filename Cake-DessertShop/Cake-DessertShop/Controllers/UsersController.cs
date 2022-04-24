using CakeDessertShop.Data;
using CakeDessertShop.Data.Entities;
using CakeDessertShop.Enums;
using CakeDessertShop.Helpers;
using CakeDessertShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CakeDessertShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUserHelper _userHelper;
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;
        private readonly IBlobHelper _blobHelper;

        public UsersController(IUserHelper userHelper, DataContext context, ICombosHelper combosHelper, IBlobHelper blobHelper)
        {
            _userHelper = userHelper;
            _context = context;
            _combosHelper = combosHelper;
            _blobHelper = blobHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Users
                .Include(u => u.Neighborhood)
                .ThenInclude(n => n.City)
                .ThenInclude(c => c.State)
                .ToListAsync());
        }
        

        public async Task<IActionResult> Create()
        {
            AddUserViewModel model = new()
            {
                Id = Guid.Empty.ToString(),
                States = await _combosHelper.GetComboStatesAsync(),
                Cities = await _combosHelper.GetComboCitiesAsync(0),
                Neighborhoods = await _combosHelper.GetComboNeighborhoodsAsync(0),
                UserType = UserType.Admin,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                Guid imageId = Guid.Empty;

                if (model.ImageFile != null)
                {
                    imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "users");
                }

                model.ImageId = imageId;
                User user = await _userHelper.AddUserAsync(model);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Este correo ya está siendo usado.");
                    model.States = await _combosHelper.GetComboStatesAsync();
                    model.Cities = await _combosHelper.GetComboCitiesAsync(model.StateId);
                    model.Neighborhoods = await _combosHelper.GetComboNeighborhoodsAsync(model.CityId);
                    return View(model);
                }

               
                  return RedirectToAction("Index", "Home");
                
            }

            model.States = await _combosHelper.GetComboStatesAsync();
            model.Cities = await _combosHelper.GetComboCitiesAsync(model.StateId);
            model.Neighborhoods = await _combosHelper.GetComboNeighborhoodsAsync(model.CityId);
            return View(model);
        }

        public JsonResult GetCities(int stateId)
        {
            State state = _context.States
                .Include(s => s.Cities)
                .FirstOrDefault(s => s.Id == stateId);
            if (state == null)
            {
                return null;
            }

            return Json(state.Cities.OrderBy(d => d.Name));
        }

        public JsonResult GetNeighborhood(int cityId)
        {
            City city = _context.Cities
                .Include(c => c.Neighborhoods)
                .FirstOrDefault(n => n.Id == cityId);
            if (city == null)
            {
                return null;
            }

            return Json(city.Neighborhoods.OrderBy(c => c.Name));
        }

    }

}
