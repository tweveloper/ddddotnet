﻿using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebApi.Services
{
    public class IdentityService : IIdentityService
    {
        private IHttpContextAccessor _context;
        public IdentityService(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public string GetUserIdentity()
        {
            return _context.HttpContext.User.FindFirst("sub").Value;
        }

        public string GetUserName()
        {
            return _context.HttpContext.User.Identity.Name;
        }
    }
}