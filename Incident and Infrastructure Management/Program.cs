using AspNetCoreHero.ToastNotification;
using Incident_and_Infrastructure_Management.BusinessLayer;
using Incident_and_Infrastructure_Management.Models;
using Incident_and_Infrastructure_Management.Models.BusinessLayer;
using Incident_and_Infrastructure_Management.Models.Contract;
using Incident_and_Infrastructure_Management.Models.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

builder.Services.AddControllersWithViews();

builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 10;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;
});

builder.Services.AddScoped<IUnitofWork<Incident>, IncidentRepository>();

builder.Services.AddScoped<IUnitofWork<Supervisor>, SupervisorRepository>();

builder.Services.AddScoped<IUnitofWork<Department>, DepartmentRepository>();

builder.Services.AddAuthentication()
                .AddJwtBearer(option =>
                {
                    option.SaveToken = true;
                });

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
