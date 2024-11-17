using FandomWiki.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
var host = Host.CreateDefaultBuilder().Build();
var config = host.Services.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<DatabaseContext>(options => 
    options.UseNpgsql(config.GetConnectionString("FandomWiki")));
builder.Services.AddScoped<CommunityRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
