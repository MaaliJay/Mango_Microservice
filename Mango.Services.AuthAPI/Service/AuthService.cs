using Mango.Services.AuthAPI.Data;
using Mango.Services.AuthAPI.Models;
using Mango.Services.AuthAPI.Models.DTO;
using Mango.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;

namespace Mango.Services.AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(AppDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<LogingResponseDTO> Login(LoginRequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> Register(RegistrationRequestDTO registerDTO)
        {
            ApplicationUser user = new()
            {
                UserName = registerDTO.Email,
                Email = registerDTO.Email,
                NormalizedEmail = registerDTO.Email.ToUpper(),
                Name = registerDTO.Name,
                PhoneNumber = registerDTO.PhoneNumber
            };
            try
            {
                var result = await _userManager.CreateAsync(user,registerDTO.Password);
                if (result.Succeeded)
                {
                    var usertoReturn = _context.ApplicationUsers.First(x => x.UserName == registerDTO.Email);

                    UserDTO userDTO = new()
                    {
                        Email = usertoReturn.Email,
                        Name = usertoReturn.Name,
                        Id = usertoReturn.Id,
                        PhoneNumber = usertoReturn.PhoneNumber
                    };

                    return userDTO;
                }

            }catch(Exception ex)
            {

            }
            return new UserDTO();
        }
    }
}
