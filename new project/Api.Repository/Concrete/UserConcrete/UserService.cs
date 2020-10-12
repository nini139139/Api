using Api.Domain.Data;
using Api.Domain.Dto.UserModelsDto;
using Api.Domain.Entity.UserModels;
using Api.Repository.Interfaces.UserInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository.Concrete.UserConcrete
{
    public class UserService : IuserService
    {
        private readonly DataContxt _context;
        public UserService(DataContxt context)
        {
            _context = context;
        }

        public async Task<User> GetUSerById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<User> GetUserByUSerName(string userName)
        {
           var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == userName);

            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public bool PasswordCheck(User user, string loginPassword)
        {
            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginPassword));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return false;
            }
            return true;
        }

        public async Task<User> RegisterUser(RegisterUserDto registerUser)
        {
            using var hmac = new HMACSHA512();
            var user = new User
            {
                UserName = registerUser.UserName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerUser.Password)),
                PasswordSalt = hmac.Key
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExists(string userName)
        {
            return await _context.Users.AnyAsync(x => x.UserName == userName.ToLower());
        }

    }
}
