using Mango.Web.Models;
using Mango.Web.Service.IService;

namespace Mango.Web.Service
{
    public class CuponService : ICuponService
    {
        private readonly IBaseService _baseService;

        public CuponService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public Task<ResponseCuponDTO?> CreateCuponAsync(CuponDTO cuponDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseCuponDTO?> DeleteCuponAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseCuponDTO?> GetAllCuponAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseCuponDTO?> GetCuponAsync(string CuponCode)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseCuponDTO?> GetCuponByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseCuponDTO?> UpdateCuponAsync(CuponDTO cuponDTO)
        {
            throw new NotImplementedException();
        }
    }
}
