using Mango.Services.AuthAPI.Data;
using Mango.Services.AuthAPI.Models;
using Mango.Services.AuthAPI.Models.DTO;
using Mango.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtToken;

        public AuthService(AppDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtToken)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtToken = jwtToken;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                if(!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }
                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            return false;
        }

        public async Task<LogingResponseDTO> Login(LoginRequestDTO requestDTO)
        {
            var user = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.UserName.ToLower()==requestDTO.UserName.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(user,requestDTO.Password);
            if (user == null || isValid == false)
            {
                return new LogingResponseDTO() 
                { 
                    User = null, 
                    Token = ""
                };
            }

            //If user found, generate JWT token
            var token = _jwtToken.GenerateToken(user);

            UserDTO userDTO = new()
            {
                Email = user.Email,
                Name = user.Name,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber
            };

            LogingResponseDTO responseDTO = new LogingResponseDTO()
            {
                User = userDTO,
                Token = token
            };
            return responseDTO;
        }

        public async Task<string> Register(RegistrationRequestDTO registerDTO)
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

                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }

            }catch(Exception ex)
            {

            }
            return "Error Encountered";
        }
    }
}
