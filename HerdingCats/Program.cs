using HerdingCats.Components;
using HerdingCats.Data;
using HerdingCats.Data.Model;
using HerdingCats.Data.Repositories;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContextFactory<KittyDbContext>(options => options.UseSqlite("DataSource=app.db"));
builder.Services.AddScoped<IRepository<Cat, int>, CatRepository>();
builder.Services.AddScoped<IClientInfo, ClientInfo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

using var context = app.Services.GetRequiredService<IDbContextFactory<KittyDbContext>>().CreateDbContext();
context.Database.EnsureCreated();

app.Run();