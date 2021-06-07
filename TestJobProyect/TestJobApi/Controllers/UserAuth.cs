using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TestJobApi.DataModels;
using TestJobApi.Repositories.Interface;
using System.IdentityModel.Tokens.Jwt;
using Claim = System.Security.Claims.Claim;
using SymmetricSecurityKey = Microsoft.IdentityModel.Tokens.SymmetricSecurityKey;
using ActionNameAttribute = Microsoft.AspNetCore.Mvc.ActionNameAttribute;
using AllowAnonymousAttribute = Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace TestJobApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuth : ControllerBase
    {

        private readonly IUserRepository userRepository;
        public UserAuth(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }


        [AllowAnonymous]
        [HttpPost]
        [ActionName("Login")]
        public IHttpActionResult Login([FromBody] UserApp login)
        {
            IHttpActionResult response = (IHttpActionResult)Unauthorized();
            var user = userRepository.GetUser(login.Username, login.Password);
            if (user.Id == 0)
                return response;

            string unicoIdentificador = Guid.NewGuid().ToString();
            int expire = 8;
            DateTime time = DateTime.Now;
            DateTime expireTime = time.AddDays(Convert.ToInt32(expire));
            var tokenString = GenerateTokenJwt(user, unicoIdentificador, time, expireTime);
            response = (IHttpActionResult)Ok(new
            {
                access_token = tokenString,
                expire_token = "11520000",
                type_token = "Bearer",
                refresh_token = unicoIdentificador,
                user = user.Username,
                rol = user.Rol,
                id = user.Id,
            });

            return response;
        }

        private string GenerateTokenJwt(UserApp user, string unicoIdentificador, DateTime time, DateTime expireTime)
        {

            string key = "KeySecret"; 
            var issuer = "http://testingjob3000-001-site1.ftempurl.com";
            var audience = "http://testingjob3000-001-site1.ftempurl.com"; 

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
 
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim(ClaimTypes.Name, user.Username));
            permClaims.Add(new Claim(ClaimTypes.DateOfBirth, user.CreatedDate.ToString()));
            permClaims.Add(new Claim("HoraToken", DateTime.UtcNow.ToString()));
            permClaims.Add(new Claim(ClaimTypes.Anonymous, unicoIdentificador));

            var token = new JwtSecurityToken(audience,
                            issuer,   
                            permClaims,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt_token;
        }
    }
}
