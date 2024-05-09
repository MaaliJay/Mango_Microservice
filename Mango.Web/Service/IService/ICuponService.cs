using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface ICuponService
    {
        Task<ResponseCuponDTO?> GetCuponAsync(string CuponCode);
        Task<ResponseCuponDTO?> GetAllCuponAsync();
        Task<ResponseCuponDTO?> GetCuponByIdAsync(int id);
        Task<ResponseCuponDTO?> CreateCuponAsync(CuponDTO cuponDTO);
        Task<ResponseCuponDTO?> UpdateCuponAsync(CuponDTO cuponDTO);
        Task<ResponseCuponDTO?> DeleteCuponAsync(int id);

    }
}
