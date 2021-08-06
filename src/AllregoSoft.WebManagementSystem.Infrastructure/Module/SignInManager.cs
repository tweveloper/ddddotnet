using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using AllregoSoft.WebManagementSystem.ApplicationCore.Services;
using AllregoSoft.WebManagementSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Module
{
    public class SignInManager
    {
        private readonly ILogger<SignInManager> _logger;
        private readonly AWMSContext _context;
        private readonly IJWTAuthService _JwtAuthService;
        private readonly JwtTokenConfig _jwtTokenConfig;

        public SignInManager(ILogger<SignInManager> logger,
                             IJWTAuthService JWTAuthService,
                             JwtTokenConfig jwtTokenConfig,
                             AWMSContext context)
        {
            _logger = logger;
            _context = context;
            _JwtAuthService = JWTAuthService;
            _jwtTokenConfig = jwtTokenConfig;
        }

        public async Task<SignInResult> SignIn(string account, string password)
        {
            _logger.LogInformation($"Validating account [{account}]", account);

            SignInResult result = new SignInResult();

            if (string.IsNullOrWhiteSpace(account)) return result;
            if (string.IsNullOrWhiteSpace(password)) return result;

            var user = await _context.tbl_Member.Where(f => f.Account == account && f.Password == password).FirstOrDefaultAsync();
            if (user != null)
            {

                var claims = BuildClaims(user);
                result.tbl_Member = user;
                result.AccessToken = _JwtAuthService.BuildToken(claims);
                result.RefreshToken = _JwtAuthService.BuildRefreshToken();

                _context.tbl_MemberToken.Add(new tbl_MemberToken { MemberId = user.Id, Token = result.RefreshToken, IssuedAt = DateTime.Now, ExpiresAt = DateTime.Now.AddMinutes(_jwtTokenConfig.RefreshTokenExpiration) });
                _context.SaveChanges();

                result.Success = true;
            };

            return result;
        }

        public async Task<SignInResult> tbl_MemberToken(string AccessToken, string tbl_MemberToken)
        {

            ClaimsPrincipal claimsPrincipal = _JwtAuthService.GetPrincipalFromToken(AccessToken);
            SignInResult result = new SignInResult();

            if (claimsPrincipal == null) return result;

            string id = claimsPrincipal.Claims.First(c => c.Type == "id").Value;
            var user = await _context.tbl_Member.FindAsync(Convert.ToInt32(id));

            if (user == null) return result;

            var token = await _context.tbl_MemberToken
                    .Where(f => f.MemberId == user.Id
                            && f.Token == tbl_MemberToken
                            && f.ExpiresAt >= DateTime.Now)
                    .FirstOrDefaultAsync();

            if (token == null) return result;

            var claims = BuildClaims(user);

            result.tbl_Member = user;
            result.AccessToken = _JwtAuthService.BuildToken(claims);
            result.RefreshToken = _JwtAuthService.BuildRefreshToken();

            _context.tbl_MemberToken.Remove(token);
            _context.tbl_MemberToken.Add(new tbl_MemberToken { MemberId = user.Id, Token = result.RefreshToken, IssuedAt = DateTime.Now, ExpiresAt = DateTime.Now.AddMinutes(_jwtTokenConfig.RefreshTokenExpiration) });
            _context.SaveChanges();

            result.Success = true;

            return result;
        }

        private Claim[] BuildClaims(tbl_Member user)
        {
            //User is Valid
            var claims = new[]
            {
                new Claim("id",user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Account)
 
                //Add Custom Claims here
            };

            return claims;
        }

    }

    public class SignInResult
    {
        public bool Success { get; set; }
        public tbl_Member tbl_Member { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public SignInResult()
        {
            Success = false;
        }
    }
}
