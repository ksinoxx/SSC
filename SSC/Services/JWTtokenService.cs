using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;


namespace SSC.Services
{
    public class JWTtokenService
    {

        const string SECRET = "hello_secret_key";
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new(Encoding.UTF8.GetBytes(SECRET));
        }

        public string CreateToken(List<Claim> claims)
        {
            return new JwtSecurityTokenHandler().WriteToken(
                new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),
                    signingCredentials: new(GetSymmetricSecurityKey(), "HS256"))
                );
        }
    }
}
