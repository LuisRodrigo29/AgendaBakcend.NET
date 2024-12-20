using AgendaAPI.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
builder.Services.AddCors();

// Llamar al método de extensión para configurar la conexión y el JWT
builder.Services.ConfigureBusinessAndSecurity(configuration);
builder.Services.AddRazorPages();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddBusinessServices();
builder.Services.AddSecurityServices();
builder.Services.AddControllers();
builder.Services.AddSwaggerDocumentation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Configuración de CORS
app.UseCors(_cors =>
{
    _cors
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

// Seguridad y Redirección HTTPS
app.UseHttpsRedirection();
app.UseStaticFiles();

// Rutas
app.UseRouting();

// Autenticación y Autorización
app.UseAuthentication();
app.UseAuthorization();

// Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUIWithConfig();
}

app.MapRazorPages();
app.MapControllers();

app.Run();