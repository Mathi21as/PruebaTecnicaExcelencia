using Microsoft.EntityFrameworkCore;
using PacientesCRUD.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRouting(routing => routing.LowercaseUrls = true);
builder.Services.AddDbContext<PatientDatabaseContext>(builder =>
{
    builder.UseMySql($"server=localhost;port=3306;database=patientsdb;uid=root;password=root1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));
});

var app = builder.Build();

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
    pattern: "{controller=Patients}/{action=GetAll}");

app.Run();
