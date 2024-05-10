using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseCuponDTO?> LoginAsync(LoginRequestDTO loginRequestDTO);
        Task<ResponseCuponDTO?> RegisterAsync(LoginRequestDTO loginRequestDTO);
        Task<ResponseCuponDTO?> AssignRoleAsync(RegistrationRequestDTO registrationRequestDTO);
    }
}
