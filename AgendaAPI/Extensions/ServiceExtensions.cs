namespace AgendaAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<Interfaz.IGuardar, Bussnies.Guardar>();
            services.AddTransient<Interfaz.IActualizar, Bussnies.Actualizar>();
            services.AddTransient<Interfaz.IConsultar, Bussnies.Consultar>();

            return services;
        }

        public static IServiceCollection AddSecurityServices(this IServiceCollection services)
        {
            services.AddTransient<Interfaz.ISecurity, Security.SecurityToken>();

            return services;
        }
    }
}
