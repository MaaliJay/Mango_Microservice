using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
    }
}
