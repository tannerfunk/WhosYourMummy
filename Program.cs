using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WhosYourMummy.Data;
using WhosYourMummy.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var authConnectString = builder.Configuration["ConnectionStrings:AuthLink"];
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(authConnectString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var connectionString2 = builder.Configuration.GetConnectionString("MummyConnection");
builder.Services.AddDbContext<MummiesDbContext>(options =>
    options.UseNpgsql(connectionString2));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IMummyRepository, EFMummyRepository>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 15;
    options.Password.RequiredUniqueChars = 1;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
