using Mango.Web.Models;
using Mango.Web.Service.IService;
using static Mango.Web.Utility.StaticDetails;

namespace Mango.Web.Service
{
    public class CuponService : ICuponService
    {
        private readonly IBaseService _baseService;

        public CuponService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseCuponDTO?> CreateCuponAsync(CuponDTO cuponDTO)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = ApiType.POST,
                Data = cuponDTO,
                Url = CuponAPIBase + "/api/cupon"
            });
        }

        public async Task<ResponseCuponDTO?> DeleteCuponAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = ApiType.DELETE,
                Url = CuponAPIBase + "/api/cupon/" + id
            });
        }

        public async Task<ResponseCuponDTO?> GetAllCuponAsync()
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = ApiType.GET,
                Url = CuponAPIBase + "/api/cupon"
            });
        }

        public async Task<ResponseCuponDTO?> GetCuponAsync(string CuponCode)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = ApiType.GET,
                Url = CuponAPIBase + "/api/cupon/GetByCode/" + CuponCode
            });
        }

        public async Task<ResponseCuponDTO?> GetCuponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = ApiType.GET,
                Url = CuponAPIBase + "/api/cupon/" + id
            });
        }

        public async Task<ResponseCuponDTO?> UpdateCuponAsync(CuponDTO cuponDTO)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = ApiType.PUT,
                Data = cuponDTO,
                Url = CuponAPIBase + "/api/cupon"
            });
        }
    }
}
