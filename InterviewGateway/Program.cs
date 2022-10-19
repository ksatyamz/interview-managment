using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("ZensarCorsPolicy", p =>
    {
        p.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:50000");
    });
});

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("Ocelot.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();
builder.Services.AddOcelot(builder.Configuration);


var app = builder.Build();

app.UseCors("ZensarCorsPolicy");
app.UseOcelot();



app.Run();
