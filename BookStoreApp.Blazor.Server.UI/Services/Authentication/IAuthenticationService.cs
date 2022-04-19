﻿using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services.Authentication
{
    public interface IAuthenticationService
    {
        // a wrapper around the api call
        Task<bool> AuthenticateAsync(LoginUserDto loginModel);

        public Task Logout();
    }
}
