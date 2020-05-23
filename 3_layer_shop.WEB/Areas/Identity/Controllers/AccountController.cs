using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Infrastructure;
using _3_layer_shop.BLL.Interfaces;
using _3_layer_shop.WEB.Areas.Identity.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        private IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<RegisterViewModel, RegisterDTO>()).CreateMapper();
            RegisterDTO registerDTO = mapper.Map<RegisterDTO>(model);

            try
            {
                await _accountService.RegisterUser(registerDTO);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public IActionResult Login (string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(new LoginViewModel { ReturnUrl = returnUrl });
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<LoginViewModel, LoginDTO>()).CreateMapper();
            LoginDTO loginDTO = mapper.Map<LoginDTO>(model);

            try
            {
                await _accountService.Login(loginDTO);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();

            return RedirectToAction("Index", "Home");
        }
    }
}
