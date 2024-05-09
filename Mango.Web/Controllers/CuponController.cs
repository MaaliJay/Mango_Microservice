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
            else
            {
                TempData["error"] = response?.Message;
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
                    TempData["success"] = "Cupon created successfully..!";
                    return RedirectToAction(nameof(CuponIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
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
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
		public async Task<IActionResult> CuponDelete(CuponDTO cuponDTO)
		{
			ResponseCuponDTO? response = await _cuponService.DeleteCuponAsync(cuponDTO.CuponId);

			if (response != null && response.IsSuccess)
			{
                TempData["success"] = "Cupon deleted successfully..!";
                return RedirectToAction(nameof(CuponIndex));
			}
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(cuponDTO);
		}
	}
}
