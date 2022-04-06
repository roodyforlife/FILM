using FILM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FILM.Interfaces
{
    public interface IAuthorisationService
    {
        public bool IsRegistered(IDbUserService userService, string user);
        public bool IsCorrectPassword(IDbUserService userService, User user);
    }
}
