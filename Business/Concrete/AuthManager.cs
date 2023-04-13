using Azure.Core;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        public AuthManager()
        {
            _userService = new UserManager();
        }
        public IDataResult<string> CreateAccessToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserId.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_top_secret_key"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return new SuccessDataResult<string>(jwt, Messages.AccessTokenCreated); 
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userExist = _userService.GetByMail(userForLoginDto.UserEmail);
            if (userExist == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotExists);
            }
            if (!BCrypt.Net.BCrypt.Verify(userForLoginDto.UserPassword, userExist.PasswordHash)) { 
                return new ErrorDataResult<User>(Messages.WrongData);
            }
            return new SuccessDataResult<User>(userExist, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            var newUser = new User
            {
                UserName = userForRegisterDto.UserName,
                PasswordHash = passwordHash,
                UserEmail = userForRegisterDto.UserEmail
            };
            _userService.Add(newUser);
            return new SuccessDataResult<User>(newUser, Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
