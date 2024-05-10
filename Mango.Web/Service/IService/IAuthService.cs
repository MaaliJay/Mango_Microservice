using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseCuponDTO?> LoginAsync(LoginRequestDTO loginRequestDTO);
        Task<ResponseCuponDTO?> RegisterAsync(RegistrationRequestDTO registrationRequestDTO);
        Task<ResponseCuponDTO?> AssignRoleAsync(RegistrationRequestDTO registrationRequestDTO);
    }
}
