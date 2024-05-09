using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseCuponDTO?> SendAsync(RequestDTO requestDTO);
    }
}
