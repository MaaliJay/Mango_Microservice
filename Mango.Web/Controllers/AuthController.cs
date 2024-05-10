using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDTO loginRequestDTO = new();
            return View(loginRequestDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDTO obj)
        {
            ResponseCuponDTO response = await _authService.LoginAsync(obj);

            if (response != null && response.IsSuccess)
            {
                LogingResponseDTO logingResponseDTO = JsonConvert.DeserializeObject<LogingResponseDTO>(Convert.ToString(response.Result));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomError", response.Message);
                return View(obj);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = StaticDetails.RoleAdmin,
                    Value = StaticDetails.RoleAdmin,
                },
                new SelectListItem
                {
                    Text = StaticDetails.RoleCustomer,
                    Value = StaticDetails.RoleCustomer,
                }
            };
            ViewBag.RoleList = roleList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDTO obj)
        {
            ResponseCuponDTO result = await _authService.RegisterAsync(obj);
            ResponseCuponDTO assignRole;

            if(result != null && result.IsSuccess)
            {
                if (string.IsNullOrEmpty(obj.Role))
                {
                    obj.Role = StaticDetails.RoleCustomer;
                }
                assignRole = await _authService.AssignRoleAsync(obj);
                if (assignRole != null && assignRole.IsSuccess)
                {
                    TempData["success"] = "Resgistration Successfull..!";
                    return RedirectToAction(nameof(Login));
                }
            }

            var roleList = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = StaticDetails.RoleAdmin,
                    Value = StaticDetails.RoleAdmin,
                },
                new SelectListItem
                {
                    Text = StaticDetails.RoleCustomer,
                    Value = StaticDetails.RoleCustomer,
                }
            };

            ViewBag.RoleList = roleList;
            return View(obj);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
