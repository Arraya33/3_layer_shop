using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Infrastructure;
using _3_layer_shop.BLL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _3_layer_shop.BLL.Services
{
    public class IdentityAccountService : IAccountService
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        public IdentityAccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task RegisterUser(RegisterDTO register)
        {
            if (register.Email == null)
                throw new ValidationException("введите логин.", "Email");
            if (register.Password == null)
                throw new ValidationException("введите пароль.", "Password");

            IdentityUser user = new IdentityUser { Email = register.Email, UserName = register.Email };

            IdentityResult result = await _userManager.CreateAsync(user, register.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
            }
            else
            {
                StringBuilder errorMessage = new StringBuilder();

                foreach (IdentityError error in result.Errors)
                {
                    errorMessage.Append(error.Description + " ");
                }

                throw new ValidationException(errorMessage.ToString(), "");
            }
        }

        public async Task Login(LoginDTO login)
        {
            if (login.Email == null)
                throw new ValidationException("введите логин.", "Email");
            if (login.Password == null)
                throw new ValidationException("введите пароль.", "Password");

            SignInResult result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, false);

            if (!result.Succeeded)
                throw new ValidationException("Неправильный логин и (или) пароль", "");
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
