using Microsoft.EntityFrameworkCore;
using Picasso.Models;
using Picasso.Models.SeedData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ExhibitionManagementDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("ExhibitionManagementDbContext"))
);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(3600);
});

var app = builder.Build();

// Add SeedData.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    AdministratorSeedData.Initialize(services);
    MembersSeedData.Initialize(services);
    SpacesSeedData.Initialize(services);
    ExhibitionsSeedData.Initialize(services);
    ExhibitionApplySeedData.Initialize(services);
}

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Exhibition}/{action=Index}/{id?}");

app.Run();
