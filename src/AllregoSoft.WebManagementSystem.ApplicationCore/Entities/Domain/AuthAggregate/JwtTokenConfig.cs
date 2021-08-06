﻿using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Entities
{
    public class JwtTokenConfig : IValueObject
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
    }
}
