using AplicacionComercial.Common.Enum;
using AplicacionComercial.Web.Interfaces;
using AplicacionComercial.Web.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionComercial.Web.Controllers
{
    //vista login, el login tiene que ir a la derecha
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper;
        private readonly ITipoDocumento _tipoDocumento;
        public AccountController(IUserHelper userHelper,ITipoDocumento tipoDocumento)
        {
            _userHelper = userHelper;
            _tipoDocumento = tipoDocumento;
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new LoginViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await
                _userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Email o contraseña incorrecta.");
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {

            await _userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            string[] list = Enum.GetNames(typeof(UserType));

            ViewData["UserType"] = new SelectList(list, list[0]);
            ViewData["IdtipoDocumento"] = new SelectList(_tipoDocumento.GetAll(), "Id", "Descripcion");
            return View();
        }
    }
}
