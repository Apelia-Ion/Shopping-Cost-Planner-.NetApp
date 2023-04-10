using Microsoft.Extensions.Logging;
using ShoppingCostPlanner.Application.Interfaces.Repository;
using ShoppingCostPlanner.Application.Interfaces.Service;
using ShoppingCostPlanner.Domain.Entities;
using ShoppingCostPlanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly List<User> _users;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ITokenService tokenService, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _users = _userRepository.GetAllUsers().Result.ToList();
            _logger = logger;

        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }


        public UserLoginResponse LoginUser(UserLoginRequest request)
        {
            var existingUser = _users.FirstOrDefault(x => x.Email == request.Email);

            if (existingUser == null)
            {
                return new UserLoginResponse
                {
                    Success = false
                };
            }

            if (existingUser.Password != request.Password)
            {
                return new UserLoginResponse
                {
                    Success = false
                };
            }

            var refreshToken = _tokenService.GenerateRefreshToken();
            var accessToken = _tokenService.GenerateToken(existingUser);
            existingUser.RefreshToken = refreshToken;

            return new UserLoginResponse(accessToken, refreshToken);
        }

        public UserLoginResponse Reauthorize(TokenRefreshRequest tokenRefreshRequest)
        {
            var payload = _tokenService.GetPrincipalFromExpiredToken(tokenRefreshRequest.ExpiredToken);

            var email = payload.FindFirst(ClaimTypes.Email)!.Value;
            var user = _users.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                return new UserLoginResponse
                {
                    Success = false
                };
            }

            if (user.RefreshToken != tokenRefreshRequest.RefreshToken)
            {
                return new UserLoginResponse
                {
                    Success = false
                };
            }

            var refreshToken = _tokenService.GenerateRefreshToken();
            var accessToken = _tokenService.GenerateToken(user);
            user.RefreshToken = refreshToken;

            return new UserLoginResponse(accessToken, refreshToken);
        }

        public async Task<User> GetUserById(int id)
        {
            _logger.LogInformation("Getting user by ID: {Id}", id);
            return await _userRepository.GetUserById(id);
        }

        public void CreateUser(UserCreateModel user)
        {
            try
            {
                var newUser = new User
                {
                     Id =user.Id,
                     Name = user.Name,     
                     Username = user.Username,
                     Password = user.Password,
                     Email = user.Email,
                     CreatedAt = DateTime.Now,
                    ShoppingLists =null,
                    RefreshToken = "123456"
                };
                    
                _userRepository.CreateUser(newUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating user");
                throw;
            }
        }

        public async Task DeleteUser(int id)
        {
            try
            {
                await _userRepository.DeleteUser(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting user with Id {id}", id);
                throw;
            }
        }




    }
}
