using Asp.Versioning.Conventions;
using PrimeraAPI.Data;
using PrimeraAPI.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<ProductoService>();

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
    options.ReportApiVersions = true;
}).AddMvc(options =>
{
    options.Conventions.Add(new VersionByNamespaceConvention());
}).AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'V";
        options.SubstituteApiVersionInUrl = true;
    }
);

var app = builder.Build();


//app.MapGet("/saludo", () => "Hola esta es mi primera API");

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
