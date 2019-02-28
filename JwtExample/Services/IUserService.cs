using System.Collections.Generic;
using JwtExample.Entities;

namespace JwtExample.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);

        IEnumerable<User> GetAll();
    }
}