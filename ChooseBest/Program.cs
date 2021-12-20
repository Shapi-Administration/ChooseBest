using ChooseBest.Areas.Identity.Data;
using ChooseBest.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var connectionString2 = builder.Configuration.GetConnectionString("UserConnection");
builder.Services.AddDbContext<UserContext>(options =>
    options.UseSqlite(connectionString2)); builder.Services.AddIdentity<User, IdentityRole>(options =>
     {
         options.SignIn.RequireConfirmedAccount = false;
         options.SignIn.RequireConfirmedEmail = false;
         options.SignIn.RequireConfirmedPhoneNumber = false;
         options.Password.RequireUppercase = false;
         options.Password.RequireNonAlphanumeric = false;
     }).AddDefaultUI().AddEntityFrameworkStores<UserContext>();
builder.Services.AddDbContext<VoteDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddLocalization();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddAuthentication();
builder.Services.AddMvc();
builder.Services.AddAuthorization();
//builder.Services.AddRequestLocalization(options =>
//{
//    options.
//})
builder.Services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
    });
var app = builder.Build();
//builder.Services.AddRequestLocalization(options =>
//{
//    options.DefaultRequestCulture("ru-RU");
//});
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

var supportedCultures = new[] { "en-US", };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture("ru-RU")
    .AddSupportedCultures("ru-RU")
    .AddSupportedUICultures("ru-RU");

app.UseRequestLocalization();

app.Run();
