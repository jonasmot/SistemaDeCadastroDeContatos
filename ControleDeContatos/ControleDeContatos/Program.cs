using Microsoft.EntityFrameworkCore;
using ControleDeContatos.Data;
using ControleDeContatos.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BancoContext>
    (options => options.UseMySql("server=localhost;initial catalog=controle_de_contatos;uid=root;pwd=fvckd4t", ServerVersion.Parse("8.0.32-mysql")));

builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>(); // quando a interface for invocada, injeção de dependecia usa o contatoRepositorio;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
