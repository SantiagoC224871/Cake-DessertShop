using CakeDessertShop.Data;
using CakeDessertShop.Data.Entities;
using CakeDessertShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CakeDessertShop.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _UserManager;
        private readonly DataContext _context;
        private readonly RoleManager<IdentityRole> _RoleManager;
        private readonly SignInManager<User> _SignInManager;



        public UserHelper(DataContext context, UserManager<User> UserManager,
            RoleManager<IdentityRole> RoleManager, SignInManager<User> SignInManager)
        {
            _context = context;
            _UserManager = UserManager;
            _RoleManager = RoleManager;
            _SignInManager = SignInManager;
        }


        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _UserManager.CreateAsync(user, password);
        }

        public async Task<User> AddUserAsync(AddUserViewModel model)
        {
            User user = new User
            {
                Address = model.Address,
                Document = model.Document,
                Email = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ImageId = model.ImageId,
                PhoneNumber = model.PhoneNumber,
                Neighborhood = await _context.Neighborhoods.FindAsync(model.NeighborhoodId),
                UserName = model.Username,
                UserType = model.UserType
            };

            IdentityResult result = await _UserManager.CreateAsync(user, model.Password);
            if (result != IdentityResult.Success)
            {
                return null;
            }
            User newUser = await GetUserAsync(model.Username);
            await AddUserToRoleAsync(newUser, user.UserType.ToString());
            return newUser;

        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await _UserManager.AddToRoleAsync(user, roleName);
        }

        public async Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword)
        {
            return await _UserManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExists = await _RoleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _RoleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }


        public async Task<User> GetUserAsync(string email)
        {
            return await _context.Users
                .Include(u => u.Neighborhood)
                .ThenInclude(n => n.City)
                .ThenInclude(c => c.State)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserAsync(Guid userId)
        {
            return await _context.Users
               .Include(u => u.Neighborhood)
               .ThenInclude(n => n.City)
               .ThenInclude(c => c.State)
               .FirstOrDefaultAsync(u => u.Id == userId.ToString());
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _UserManager.IsInRoleAsync(user, roleName);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _SignInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                false);
        }

        public async Task LogoutAsync()
        {
            await _SignInManager.SignOutAsync();
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            return await _UserManager.UpdateAsync(user);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(User user)
        {
            return await _UserManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IdentityResult> ResetPasswordAsync(User user, string token, string password)
        {
            return await _UserManager.ResetPasswordAsync(user, token, password);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(User user, string token)
        {
            return await _UserManager.ConfirmEmailAsync(user, token);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            return await _UserManager.GenerateEmailConfirmationTokenAsync(user);
        }

    }
}
