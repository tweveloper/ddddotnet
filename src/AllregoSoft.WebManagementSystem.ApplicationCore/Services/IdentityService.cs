﻿using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Services
{
    public class IdentityService : IIdentityService
    {
        private IHttpContextAccessor _context;
        public IdentityService(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public long GetMemberId()
        {
            return long.Parse(_context.HttpContext == null ? "0" : _context.HttpContext.User.FindFirst("mem")?.Value ?? "0");
        }

        public string GetIdentityId()
        {
            return _context.HttpContext.User.FindFirst("sub").Value;
        }

        public string GetUserName()
        {
            return _context.HttpContext.User.Identity.Name;
        }

        public ClaimsPrincipal GetClaimsPrincipal()
        {
            return _context.HttpContext.User;
        }
        public long GetRoleId()
        {
            return long.Parse(_context.HttpContext.User.FindFirst("rol")?.Value ?? "0");
        }
    }
}
