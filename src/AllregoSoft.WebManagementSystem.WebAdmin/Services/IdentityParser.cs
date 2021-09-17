﻿using AllregoSoft.WebManagementSystem.WebAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebAdmin.Services
{
    public class IdentityParser : IIdentityParser<ApplicationUser>
    {
        public ApplicationUser Parse(IPrincipal principal)
        {
            // Pattern matching 'is' expression
            // assigns "claims" if "principal" is a "ClaimsPrincipal"
            if (principal is ClaimsPrincipal claims)
            {
                return new ApplicationUser
                {
                    Account = claims.Claims.FirstOrDefault(x => x.Type == "account")?.Value ?? "",
                    Email = claims.Claims.FirstOrDefault(x => x.Type == "email")?.Value ?? "",
                    Id = claims.Claims.FirstOrDefault(x => x.Type == "sub")?.Value,
                    PhoneNumber = claims.Claims.FirstOrDefault(x => x.Type == "phone_number")?.Value ?? "",
                };
            }
            throw new ArgumentException(message: "The principal must be a ClaimsPrincipal", paramName: nameof(principal));
        }
    }
}
