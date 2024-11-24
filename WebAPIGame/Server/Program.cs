using Server;
using Server.Frameworks;
using Server.Repositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AppSettings.ConnectionKeys>(builder.Configuration.GetSection("ConnectionKeys"));

builder.Services.AddSingleton<DbConnectionFactory>();

builder.Services.AddScoped<AuthRepository>();

WebApplication app = builder.Build();

app.Run();