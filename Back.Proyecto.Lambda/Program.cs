using Microsoft.OpenApi.Models;
using Back.Proyecto.Lambda.Data;
using Microsoft.EntityFrameworkCore;
using Back.Proyecto.Buscador;
using Back.Proyecto.Buscador.MSQL;
using System.Data;
using MySql.Data.MySqlClient;
using Back.Proyecto.InsertDatos;
using Back.Proyecto.InsertDatos.MSQL;
using Back.Proyecto.BuscarEspecifica;
using Back.Proyecto.BuscarEspecifica.MSQL;


var builder = WebApplication.CreateBuilder(args);

// 🔹 Configurar Swagger con OpenAPI correctamente
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Proyecto",
        Version = "v1",
        Description = "Documentación de la API con Swagger",
        Contact = new OpenApiContact
        {
            Name = "Soporte API",
            Email = "soporte@proyecto.com",
            Url = new Uri("https://proyecto.com")
        }
    });

    // 🔹 Para Swagger 8, especificar OpenAPI 3.x
    c.UseAllOfToExtendReferenceSchemas();
});
builder.Services.AddScoped<IBuscadorService, BuscadorService>();
builder.Services.AddScoped<IBuscadorDatosReader, BuscadorDatosReader>();
builder.Services.AddScoped<IInsertService, InsertEspService>();
builder.Services.AddScoped<IInsertDatosReader, InsertReader>();
builder.Services.AddScoped<IBuscadorEspService, BuscadorEspService>();
builder.Services.AddScoped<IBuscadorDatosEspReader, BuscadorEspReader>();


// 🔹 Registro explícito para Dapper (esto faltaba)
builder.Services.AddTransient<IDbConnection>(sp =>
    new MySql.Data.MySqlClient.MySqlConnection(
        builder.Configuration.GetConnectionString("DefaultConnection")));
// 🔹 Configuración de la base de datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

builder.Services.AddControllers();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);

var app = builder.Build();
app.UseDeveloperExceptionPage(); 
// 🔹 Habilitar Swagger SIEMPRE
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Proyecto v1");
    c.RoutePrefix = string.Empty;
    
});

// 🔹 Middleware estándar
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

