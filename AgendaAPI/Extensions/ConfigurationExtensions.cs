namespace AgendaAPI.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection ConfigureBusinessAndSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            var conexionBD = configuration["Settings:ConecctionDB"];
            var jwtKey = configuration["Jwt:Key"];
            var Issuer = configuration["Jwt:Issuer"];
            var Audience = configuration["Jwt:Audience"];

            if (conexionBD != null)
            {
                // Establecemos la instancia de la conexión en la clase Conexion
                var instanciaConexion = new Bussnies.instanciaConexion();
                instanciaConexion.IntanciaConexion(conexionBD);

                // Configuramos los valores de seguridad
                Security.SecurityToken.keyJwt = jwtKey;
                Security.SecurityToken.Issuer = Issuer;
                Security.SecurityToken.Ausience = Audience;
            }

            return services;
        }
    }
}
