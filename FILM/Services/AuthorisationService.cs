using FILM.Interfaces;
using FILM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FILM.Services
{
    public class AuthorisationService : IAuthorisationService
    {
        public bool IsCorrectPassword(IDbUserService userService, User user)
        {
            var dbUser = userService.Get(user.Login);
            return dbUser.Password == user.Password;
        }

        public bool IsRegistered(IDbUserService userService, string user)
        {
            return userService.Get(user) is not null;
        }
    }
}
