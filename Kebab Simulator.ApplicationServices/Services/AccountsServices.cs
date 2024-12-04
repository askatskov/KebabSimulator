using Kebab_Simulator.Core.Domain;
using Kebab_Simulator.Core.Domain.Dto.AccountsDtos;
using Kebab_Simulator.Core.Domain.Serviceinterface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kebab_Simulator.ApplicationServices.Services
{
    public class AccountsServices : IAccountsServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountsServices
            (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ApplicationUser> Register(ApplicationUserDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                City = dto.City,
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            }
            return user;
        }

        public async Task<ApplicationUser> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                string errorMessage = $"User with id {userId} is not valid.";
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            return user;
        }
        public async Task<ApplicationUser> Login(LoginDto dto)
        {
            // !!extval
            var user = await _userManager.FindByEmailAsync(dto.Email);
            return user;
        }
    }
}