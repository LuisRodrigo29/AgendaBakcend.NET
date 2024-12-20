using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AgendaAPI.Extensions
{
    public class AuthorizeCheckOperationFilter: IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Verificar si el controlador o método tiene el atributo [Authorize]
            var hasAuthorize = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                                 .OfType<AuthorizeAttribute>().Any() ||
                               context.MethodInfo.GetCustomAttributes(true)
                                 .OfType<AuthorizeAttribute>().Any();

            if (hasAuthorize)
            {
                // Añadir el esquema de seguridad si hay [Authorize]
                operation.Security = new List<OpenApiSecurityRequirement>
                {
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                    }
                };
            }
        }
    }
}
