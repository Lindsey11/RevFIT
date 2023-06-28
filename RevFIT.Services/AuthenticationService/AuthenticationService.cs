using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RevFIT.Context.Models;
using RevFIT.DataAccess.UserRepo;
using RevFIT.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RevFIT.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _config;

        public AuthenticationService(IUserRepository userRepository, IConfiguration configuration) 
        {
            _userRepo = userRepository;
            _config = configuration;
        }
        public async Task<ServiceResponseModel<bool>> ChangePassword(int userId, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task<APIUserViewModel> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public string GetUserEmail()
        {
            throw new NotImplementedException();
        }

        public int GetUserId()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponseModel<string>> Login(string email, string password)
        {
            try
            {
                var response = new ServiceResponseModel<string>();
                var user = await _userRepo.GetUserByEmail(email.ToLower());

                if (user == null)
                {
                    response.IsSuccess = false;
                    response.Message = "User not found.";
                }
                else if (!VerifyPasswordHash(password, user.PassworkEcyp, user.SaltEcyp))
                {
                    response.IsSuccess = false;
                    response.Message = "Wrong password.";
                }
                else
                {
                    response.Data = CreateToken(user);
                    response.IsSuccess = true;
                    response.Message = "Login Success";
                    var jwt = new JwtSecurityTokenHandler().ReadJwtToken(response.Data);
                    Console.WriteLine(jwt.Claims.FirstOrDefault().Value);
                }

                return response;
            }
            catch (Exception error)
            {

              return new() { IsSuccess = false , Message = error.Message };
            }
            
        }

        public async Task<ServiceResponseModel<int>> Register(APIRegisterViewModel user)
        {
            var checkUserResult = await _userRepo.GetUserByEmail(user.Email);

            if (checkUserResult is not null)
            {
                return new ServiceResponseModel<int>
                {
                    IsSuccess = false,
                    Message = "User already exists."
                };
            }

            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newUser = new User()
            {
                Email = user.Email,
                PassworkEcyp = passwordHash,
                SaltEcyp = passwordSalt,
                DateCreated = DateTime.Now
            };

            var result = await _userRepo.AddUserAsync(newUser);

            if (result == 0)
            {
                return new ServiceResponseModel<int> { Message = "Registration could not be completed", IsSuccess = false };
            }


            return new ServiceResponseModel<int> { Data = result, Message = "Registration successful!", IsSuccess = true };
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash =
                    hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                var completed = computedHash.SequenceEqual(passwordHash);
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, "User")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }

     
}
