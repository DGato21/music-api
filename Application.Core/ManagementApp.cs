﻿using Application.Core.Interfaces;
using Domain.Core.Interfaces;

namespace Application.Core
{
    public class ManagementApp : IManagementApp
    {
        private readonly IManagement management;

        public ManagementApp(IManagement management)
        { 
            this.management = management;
        }

        public Task<string> LoginSpotify()
        {
            return this.management.LoginSpotify();
        }

        public Task<string> AuthenticateSpotifyAccessToken(string code, string state)
        {
            return this.management.AuthenticateSpotifyAccessToken(code, state);
        }
    }
}
