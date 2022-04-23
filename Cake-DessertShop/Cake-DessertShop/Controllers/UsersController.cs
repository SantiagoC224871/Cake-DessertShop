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
            AddUserViewModel model = new AddUserViewModel
            {
                Id = Guid.Empty.ToString(),
                States = await _combosHelper.GetComboStatesAsync(),
                Cities = await _combosHelper.GetComboCitiesAsync(0),
                Neighborhoods = await _combosHelper.GetComboNeighborhoodsAsync(0),
                UserType = UserType.Admin,
            };

            return View(model);
        }

    }

}
