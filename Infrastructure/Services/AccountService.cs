using ApplicationCore.Contract.Repository;
using ApplicationCore.Contract.Services;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> RegisterUser(UserRegisterModel model)
        {
            //check if the user already exists in the database, by email
            var user= await _userRepository.GetUserByEmail(model.Email);
            if (user!=null)
            {
                throw new ConflictException("Email already exists, please try to log in");     
            }
            //if email does not exist, continue with registration
            //create a randon salt
            //hash the password with salt created above
            //create User object and save using EF(dbContext)
            var salt = GetRandomSalt();
            var hashedPassword= GetHashedPassword(model.Password, salt);

            var newUser = new User
            {
                Email = model.Email,
                HashedPassword = hashedPassword,
                Salt = salt,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
            };

            var savedUser= await _userRepository.Add(newUser);
            if (savedUser.Id > 0)
            {
                return true;
            }
            return false;

        }

        public async Task<bool> ValidateUser(UserLoginModel model)
        {
            //go to database and get the row by email
            var user = await _userRepository.GetUserByEmail(model.Email);
            if (user == null)
            {
                throw new Exception("Email does not exists");
                return false;
            }
            return true;
        }

        //install two package: keyDerivation, Cryptography.Cng in Infrustructure NuGet
        private string GetRandomSalt()
        {
            var randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string GetHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(password,
           Convert.FromBase64String(salt),
           KeyDerivationPrf.HMACSHA512,
           10000,
           256 / 8));
            return hashed;
        }



    }
}
