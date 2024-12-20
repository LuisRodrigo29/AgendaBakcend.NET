using Interfaz;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Security
{
    public class SecurityToken : ISecurity

    {
        public static string keyJwt;
        public static string Issuer;
        public static string Ausience;

        public string GetToken(DataTable tblResult, string usuario, string contrasena)
        {
            Data.Consultar _consultar = new Data.Consultar();
            string token = string.Empty;

            // prcedimiento para obtener la informacion para las llaves del token
            DataTable tblSinToken = _consultar.ObtenerDatosUsuario(usuario, contrasena);
            if (tblSinToken.Rows.Count > 0)
            {
                string nombre = string.Empty, cedula = string.Empty, _usuario = string.Empty;
                foreach (DataRow dt in tblSinToken.Rows)
                {
                    nombre = dt["nombre"].ToString();
                    cedula = dt["cedula"].ToString();
                    _usuario = dt["usuario"].ToString();

                }
                token = Authenticate(nombre, cedula, _usuario);
            }

            return token;
        }

        private string Authenticate(string nombre, string cedula, string usuario)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyJwt));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Crear claims o reclamaciones
            var claims = new[]
            {
                new Claim(ClaimTypes.GivenName, nombre),
                new Claim(ClaimTypes.Dns, cedula),
                new Claim(ClaimTypes.Actor, usuario)

            };

            // Creamos el token
            var token = new JwtSecurityToken(
                    Issuer,
                    Ausience,
                    claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
