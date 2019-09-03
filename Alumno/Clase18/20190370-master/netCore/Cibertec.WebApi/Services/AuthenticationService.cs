using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cibertec.Models;
using Cibertec.UnitOfWork;
using Cibertec.WebApi.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace Cibertec.WebApi.Services
{
    public interface IAuthenticationService
    {
        User ValidateUser(TokenRequest request, out string token);


    }

    public class AuthenticationService: IAuthenticationService
    {
        protected IUnitOfWork unitOfWork;
        protected TokenManagement tokenManagement;

        public AuthenticationService(IUnitOfWork unit, IOptions<TokenManagement> tokenOptions)
        {

            unitOfWork = unit;

            // Para obtener los valores del appsettings
            tokenManagement = tokenOptions.Value;
        }


        public User ValidateUser(TokenRequest request, out string token)
        {
            var validatedUser = unitOfWork.Users.ValidaterUser(request.Username, request.Password);

            // si validatedUser es nulo, entonces no es un usuario válido
            if (validatedUser == null)
            {
                token = string.Empty;
                return null;
            }


            // si pasó la validación, creamos la identidad
            var identidad = new[]
            {
                new Claim(ClaimTypes.Name, $"{validatedUser.FirstName} {validatedUser.LastName}"),
                new Claim(ClaimTypes.Email, validatedUser.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenManagement.Secret));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // generamos el token
            var jwtToken = new JwtSecurityToken(tokenManagement.Issuer, tokenManagement.Audience, identidad, expires: DateTime.Now.AddDays(tokenManagement.AccessExpiration), signingCredentials: credenciales);

            // obtener el texto del token
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return validatedUser;
        }
    }
}
