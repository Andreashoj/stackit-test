using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StackitApi.Models;

namespace StackitApi.Services
{
    public class UserService : IUserService
    {
        private readonly StackitContext _context;
        private readonly AppSettings _appSettings;


        public UserService(StackitContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }


        // Authenticate a user with username and password. Password will be compared
        // against hash in Db and a JWT will be created if login is successful.
        public async Task<User> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = await _context.Users
                .Include(u => u.UserType)
                .SingleOrDefaultAsync(x => x.Username == username);

            if (user == null)
                return null;
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            CreateToken(user);
            return user;
        }


        // Get a list of all users.
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }


        // Get a single user by Id.
        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }


        // Get a list of users with a given UserTypeId.
        public async Task<IEnumerable<User>> GetByUserTypeId(int id)
        {
            return await _context.Users
                .Where(u => u.UserTypeId == id)
                .ToListAsync();
        }


        // Get a list of users with a given CompanyId.
        public async Task<IEnumerable<User>> GetByCompanyId(int id)
        {
            return await _context.Users
                .Where(u => u.CompanyId == id)
                .ToListAsync();
        }


        // Create a new user if one with the same username does not already exist.
        // If successful, the password will be hashed before being saved to the database.
        public async Task<User> Create(User user)
        {
            if (_context.Users.Any(x => x.Username == user.Username))
                throw new AppException($"Username '{user.Username}' is already in use");

            if (_context.Users.Any(x => x.Email == user.Email))
                throw new AppException($"Email address '{user.Email}' is already in use");

            if (!_context.UserTypes.Any(x => x.Id == user.UserTypeId))
                throw new AppException($"User Type '{user.UserTypeId}' doesn't exist");

            if (!_context.Companies.Any(x => x.Id == user.CompanyId))
                throw new AppException($"Company '{user.CompanyId}' doesn't exist");

            CreatePasswordHash(user.Password, out var passwordHash, out var passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }


        // Update user.
        public async Task<User> Update(User newUser)
        {
            var oldUser = await _context.Users.FindAsync(newUser.Id);

            if (oldUser == null)
                throw new AppException("User not found");

            if (!string.IsNullOrWhiteSpace(newUser.Username) && newUser.Username != oldUser.Username)
            {
                if (_context.Users.Any(x => x.Username == newUser.Username))
                    throw new AppException($"Username '{newUser.Username}' is already in use");
                oldUser.Username = newUser.Username;
            }

            if (!string.IsNullOrWhiteSpace(newUser.Email) && newUser.Email != oldUser.Email)
            {
                if (_context.Users.Any(x => x.Email == newUser.Email))
                    throw new AppException($"Email address '{newUser.Email}' is already in use");
                oldUser.Email = newUser.Email;
            }

            if (newUser.UserTypeId != oldUser.UserTypeId)
            {
                if (!_context.UserTypes.Any(x => x.Id == newUser.UserTypeId))
                    throw new AppException($"User Type '{newUser.UserTypeId}' doesn't exist");
                oldUser.UserTypeId = newUser.UserTypeId;
            }

            if (newUser.CompanyId != oldUser.CompanyId)
            {
                 if (!_context.Companies.Any(x => x.Id == newUser.CompanyId))
                    throw new AppException($"Company '{newUser.CompanyId}' doesn't exist");
               oldUser.CompanyId = newUser.CompanyId;
            }

            if (!string.IsNullOrWhiteSpace(newUser.FirstName))
                oldUser.FirstName = newUser.FirstName;

            if (!string.IsNullOrWhiteSpace(newUser.LastName))
                oldUser.LastName = newUser.LastName;

            if (!string.IsNullOrWhiteSpace(newUser.Password))
            {
                CreatePasswordHash(newUser.Password, out var passwordHash, out var passwordSalt);
                oldUser.PasswordHash = passwordHash;
                oldUser.PasswordSalt = passwordSalt;
            }

            _context.Users.Update(oldUser);
            await _context.SaveChangesAsync();
            return oldUser;
        }


        // Delete a user with the given Id.
        // Returns the deleted user or null if none was found.
        public async Task<User> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }

            return user;
        }


        // Create a hash value from password entered by user.
        // This will be saved in the Db instead of a plain text password.
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null)
                throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


        // Verify password entered by user by encrypting and comparing with hash in database.
        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null)
                throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64)
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128)
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }


        // Create and assign a JWT token to a user after a successful login.
        private void CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.UserType.Name)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
        }


        // Check if a user exists with a given Id.
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
