using ComiteLogicaNegocio.CasoUso.Usuarios;

using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorios;
using ComiteAccesoADatos.EF;
using ComiteLogicaAplicacion.CasoUso.Usuarios;
using ComiteCompartido.Dtos.Usuarios;
using ComiteCompartido.Dtos.Disciplinas;
using ComiteLogicaAplicacion.CasoUso.Disciplinas;
using ComiteLogicaNegocio.CasoUso.Disciplinas;
using ComiteLogicaNegocio.InterfacesRepositorio;
using ComiteCompartido.Dtos.Atletas;
using ComiteLogicaAplicacion.CasoUso.CasoUsoAtleta;
using ComiteCompartido.Dtos.Eventos;
using ComiteLogicaAplicacion.CasoUso.CasoUsoEvento;
using Microsoft.EntityFrameworkCore;
namespace ComiteApp
{
    public class Program
    {
        public static void SeedData(ComiteContext _context)
        {
            // TO-DO: Refactor de las relaciones en EF para poder insertar en la tabla intermedia y no tener que hacer esto
            if (_context.atletas.Any())
            {
                foreach (var atleta in _context.atletas.ToList())
                {
                    if (atleta.Disciplinas == null)
                    {
                        atleta.Disciplinas = new List<Disciplina> { };

                        foreach (var disciplinaId in atleta.DisciplinasIds)
                        {
                            var disciplina = _context.disciplinas.Find(disciplinaId);
                            if (disciplina != null)
                            {
                                try
                                {
                                    atleta.Disciplinas.Add(disciplina);
                                    _context.SaveChanges();
                                }
                                catch (Exception)
                                {
                                    continue;
                                }
                                
                            }
                        }
                    }

                }


            }
        }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // inyecto los repositorios
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioDisciplina, RepositorioDisciplina>();
            builder.Services.AddScoped<IRepositorioAtleta, RepositorioAtleta>();
            builder.Services.AddScoped<IRepositorioPais, RepositorioPais>();
            builder.Services.AddScoped<IRepositorioEvento, RepositorioEvento>();

            // intetecto los caso de uso
            builder.Services.AddScoped<IAlta<UsuarioAltaDto>, AltaUsuario>();
            builder.Services.AddScoped<IObtenerTodos<UsuarioListadoDto>, ObtenerUsuarios>();
            builder.Services.AddScoped<IObtener<UsuarioAltaDto>, ObtenerUsuario>();
            builder.Services.AddScoped<IEliminar<UsuarioAltaDto>, EliminarUsuario>();
            builder.Services.AddScoped<IEditar<UsuarioAltaDto>, EditarUsuario>();

            builder.Services.AddScoped<IAltaLogs<DisciplinasAltaDto>, AltaDisciplina>();
            builder.Services.AddScoped<IObtenerTodos<DisciplinasListadoDto>, ObtenerDisciplinas>();
            builder.Services.AddScoped<IObtener<DisciplinasAltaDto>, ObtenerDisciplina>();
            builder.Services.AddScoped<IEliminarLogs<DisciplinasAltaDto>, EliminarDisciplina>();

            builder.Services.AddScoped<IObtenerTodos<AtletaListadoDto>, ObtenerAtletas>();
            builder.Services.AddScoped<IObtener<AtletaAltaDto>, ObtenerAtleta>();
            builder.Services.AddScoped<IEditar<AtletaAltaDto>, EditarAtleta>();

            builder.Services.AddScoped<IObtenerTodos<EventoListadoDto>, ObtenerEventos>();
            builder.Services.AddScoped<IObtener<EventoAltaDto>, ObtenerEvento>();
            builder.Services.AddScoped<IAlta<EventoAltaDto>, AltaEvento>();


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

            // Seed data
            using (var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<ComiteContext>())
            {
                context.Database.Migrate(); // Ensure the database is up to date
                SeedData(context); // Call your method to seed data
            }

            app.Run();
        }
       
    }
}
