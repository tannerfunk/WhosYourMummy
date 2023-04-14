using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WhosYourMummy.Data;
using WhosYourMummy.Models;
using Microsoft.ML.OnnxRuntime;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment;

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
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

//____________________________________________________________________
//These are all of the aditions we needed for the API to work

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors();
//builder.Services.AddSingleton<InferenceSession>(
//    new InferenceSession("Models/model.onnx")
//);
builder.Services.AddSingleton(new InferenceSession(Path.Combine(env.ContentRootPath,
    "wwwroot", "model.onnx")));

//_____________________________________________________________________
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

//This is for the API to work
app.UseCors(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
