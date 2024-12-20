using Microsoft.OpenApi.Models;
using System.Reflection;

namespace AgendaAPI.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "AgendaAPI",
                    Version = "v1"
                });

                // Ruta del archivo XML generado para la documentación
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                // Definir el esquema de seguridad para autenticación con Bearer Token (JWT)
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                // Agregar el filtro para aplicar Bearer Token solo a los métodos con [Authorize]
                c.OperationFilter<AuthorizeCheckOperationFilter>();
            });

            return services;
        }
        public static IApplicationBuilder UseSwaggerUIWithConfig(this IApplicationBuilder app)
        {
            app.UseSwagger(); // Activa el middleware de Swagger
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AgendaAPI V1");
            });

            return app;
        }
    }
}
