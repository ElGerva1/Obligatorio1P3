using ComiteLogicaNegocio.CasoUso.Usuarios;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorios;
using ComiteAccesoADatos.EF;
using ComiteLogicaAplicacion.CasoUso.Usuarios;

namespace ComiteApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // inyecto los repositorios
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

            // intetecto los caso de uso
            builder.Services.AddScoped<IAlta<Usuario>, AltaUsuario>();
            builder.Services.AddScoped<IObtenerTodos<Usuario>, ObtenerUsuarios>();

            // inyectando la Comite Contex
            builder.Services.AddDbContext<ComiteContext>();
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
                pattern: "{controller=Usuario}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
