using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mango.Web.Controllers
{
    public class CuponController : Controller
    {
        private readonly ICuponService _cuponService;

        public CuponController(ICuponService cuponService)
        {
            _cuponService = cuponService;
        }
        public async Task<IActionResult> CuponIndex()
        {
            List<CuponDTO> list = new();

            ResponseCuponDTO? response = await _cuponService.GetAllCuponAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CuponDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        public async Task<IActionResult> CuponCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CuponCreate(CuponDTO model)
        {
            if (ModelState.IsValid)
            {
                ResponseCuponDTO? response = await _cuponService.CreateCuponAsync(model);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(CuponIndex));
                }
            }

            return View(model);
        }

        public async Task<IActionResult> CuponDelete(int id)
        {
            ResponseCuponDTO? response = await _cuponService.GetCuponByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                CuponDTO? model = JsonConvert.DeserializeObject<CuponDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
    }
}
