using BlazorSpanyol.Data;
using BlazorSpanyol.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization();
builder.Services.AddDbContext<SpanishDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SpanishDbConnectionString")));

builder.Services.AddDbContext<SpanishAuthDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SpanishAuthDbConnectionString")));



builder.Services.AddScoped<IWordsRepository, WordsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();