﻿using AplicacionComercial.Web.Data.Entities;
using AplicacionComercial.Web.Models;

using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionComercial.Web.Interfaces
{
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email);
        Task<IdentityResult> AddUserAsync(User user, string password);
        Task CheckRoleAsync(string roleName);
        Task AddUserToRoleAsync(User user, string roleName);
        Task<bool> IsUserInRoleAsync(User user, string roleName);
        Task<SignInResult> LoginAsync(LoginViewModel model);
        Task LogoutAsync();
    }

    
}
