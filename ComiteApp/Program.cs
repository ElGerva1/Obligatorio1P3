using ComiteLogicaNegocio.CasoUso.Usuarios;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorios;
using ComiteAccesoADatos.EF;
using ComiteLogicaAplicacion.CasoUso.Usuarios;
using ComiteCompartido.Dtos.Usuarios;

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
            builder.Services.AddScoped<IAlta<UsuarioAltaDto>, AltaUsuario>();
            builder.Services.AddScoped<IObtenerTodos<UsuarioListadoDto>, ObtenerUsuarios>();
            builder.Services.AddScoped<IObtener<UsuarioAltaDto>, ObtenerUsuario>();

            // inyectando la Comite Contex
            builder.Services.AddDbContext<ComiteContext>();

            builder.Services.AddSession();


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

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
