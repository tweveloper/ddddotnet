using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using AllregoSoft.WebManagementSystem.ApplicationCore.Entities.ValueObjects;
using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Services
{
    #region | 인터페이스 |
    public interface IJWTAuthService
    {
        /// <summary>
        /// 토큰 생성
        /// </summary>
        /// <param name="claims">인증 정보</param>
        /// <returns></returns>
        public string BuildToken(Claim[] claims);
        /// <summary>
        /// 토큰 재생성
        /// </summary>
        /// <returns></returns>
        public string BuildRefreshToken();
        /// <summary>
        /// 토큰 인증
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public ClaimsPrincipal GetPrincipalFromToken(string token);
        public TokenResult GetToken(tbl_Member member);
    }
    #endregion

    #region | 클래스 |
    public class JWTAuthService : IJWTAuthService
    {
        private readonly JwtTokenConfig _jwtTokenConfig;
        private readonly ILogger<JWTAuthService> _logger;
        private readonly IMemberTokenRepository _memberTokenRepository;

        public JWTAuthService(JwtTokenConfig jwtTokenConfig, ILogger<JWTAuthService> logger, IMemberTokenRepository memberTokenRepository)
        {
            _jwtTokenConfig = jwtTokenConfig;
            _logger = logger;
            _memberTokenRepository = memberTokenRepository;
        }

        public TokenResult GetToken(tbl_Member member)
        {
            bool isSuccess = false;
            string accessToken = string.Empty;
            string refreshToken = string.Empty;

            var memberToken = _memberTokenRepository.Entity.Where(x => x.MemberId == member.Id && x.ExpiresAt >= DateTime.Now).FirstOrDefault();

            if(memberToken == null)
            {
                accessToken = BuildToken(BuildClaims(member));
                _memberTokenRepository.UnitOfWork.Add(new tbl_MemberToken { MemberId = member.Id, Token = accessToken, IssuedAt = DateTime.Now, ExpiresAt = DateTime.Now.AddMinutes(_jwtTokenConfig.RefreshTokenExpiration) });
                _memberTokenRepository.UnitOfWork.SaveChanges();
            }
            else
            {
                accessToken = memberToken.Token;
            }

            refreshToken = BuildRefreshToken();
            
            if (member.UseYN.Equals("Y"))
            {
                isSuccess = true;
            }

            var result = new TokenResult(isSuccess, member, accessToken, refreshToken);

            return result;
        }

        public string BuildToken(Claim[] claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenConfig.Secret));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    issuer: _jwtTokenConfig.Issuer,
                    audience: _jwtTokenConfig.Audience,
                    notBefore: DateTime.Now,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(_jwtTokenConfig.AccessTokenExpiration),
                    signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string BuildRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            JwtSecurityTokenHandler tokenValidator = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenConfig.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var parameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateLifetime = false
            };

            try
            {
                var principal = tokenValidator.ValidateToken(token, parameters, out var securityToken);

                if (!(securityToken is JwtSecurityToken jwtSecurityToken) || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    _logger.LogError($"Token validation failed");
                    return null;
                }

                return principal;
            }
            catch (Exception e)
            {
                _logger.LogError($"Token validation failed: {e.Message}");
                return null;
            }
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
    #endregion
}
