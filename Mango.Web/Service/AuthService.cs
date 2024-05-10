using Mango.Web.Models;
using Mango.Web.Service.IService;
using static Mango.Web.Utility.StaticDetails;

namespace Mango.Web.Service
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;

        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseCuponDTO?> AssignRoleAsync(RegistrationRequestDTO registrationRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiType.POST,
                Data = registrationRequestDTO,
                Url = AuthAPIBase + "/api/auth/assignRole"
            });
        }

        public async Task<ResponseCuponDTO?> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiType.POST,
                Data = loginRequestDTO,
                Url = AuthAPIBase + "/api/auth/login"
            });
        }

        public async Task<ResponseCuponDTO?> RegisterAsync(RegistrationRequestDTO registrationRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiType.POST,
                Data = registrationRequestDTO,
                Url = AuthAPIBase + "/api/auth/register"
            });
        }
    }
}
