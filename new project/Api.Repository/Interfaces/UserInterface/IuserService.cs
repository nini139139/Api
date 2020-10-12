using Api.Domain.Dto.UserModelsDto;
using Api.Domain.Entity.UserModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository.Interfaces.UserInterface
{
    public interface IuserService
    {
        Task<bool> UserExists(string userName);
        Task<User> GetUserByUSerName(string userName);
        bool PasswordCheck(User user, string loginPassword);
        Task<User> RegisterUser(RegisterUserDto registerUser);
        Task<List<User>> GetUsers();
        Task<User> GetUSerById(int id);

    }
}
