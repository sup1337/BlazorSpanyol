using BlazorSpanyol.Data;
using BlazorSpanyol.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization();
builder.Services.AddDbContext<SpanishDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SpanishDbConnectionString")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<SpanishAuthDbContext>();

builder.Services.AddDbContext<SpanishAuthDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SpanishAuthDbConnectionString")));

builder.Services.AddScoped<IWordsRepository, WordsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();