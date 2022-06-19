using IgwOutgoingStatus.Data;
using IgwOutgoingStatus.Extensions;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.WebHost.ConfigureLogging((hostBuilderContext, logging) =>
{
    logging.AddRoundTheCodeFileLogger(options =>
    {
        hostBuilderContext.Configuration.GetSection("Logging").GetSection("RoundTheCodeFile").GetSection("Options").Bind(options);
    });
});

IConfigurationSection configurationSection = builder.Configuration.GetSection("Miscellaneous");
string? MaxConnections = configurationSection.GetValue<string>("MaxConnections");
string? MaxRequestBodySize = configurationSection.GetValue<string>("MaxRequestBodySize");
string HostedServerLink = configurationSection.GetValue<string>("HostedServerLink");

#if !DEBUG
builder.WebHost.UseHttpSys(options =>
{
    options.AllowSynchronousIO = true;
    options.Authentication.Schemes = AuthenticationSchemes.None;
    options.Authentication.AllowAnonymous = true;
    options.MaxConnections = Convert.ToInt32(MaxConnections);
    options.MaxRequestBodySize = Convert.ToInt32(MaxRequestBodySize);
    options.UrlPrefixes.Add(HostedServerLink);
});
#endif

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{startdate?}");

app.Run();
