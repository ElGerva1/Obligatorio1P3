
using ComiteAccesoADatos.EF;
using ComiteCompartido.Dtos.Atletas;
using ComiteCompartido.Dtos.Disciplinas;
using ComiteCompartido.Dtos.Eventos;
using ComiteCompartido.Dtos.Usuarios;
using ComiteLogicaAplicacion.CasoUso.CasoUsoAtleta;
using ComiteLogicaAplicacion.CasoUso.CasoUsoEvento;
using ComiteLogicaAplicacion.CasoUso.Disciplinas;
using ComiteLogicaAplicacion.CasoUso.Usuarios;
using ComiteLogicaNegocio.CasoUso.Disciplinas;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteLogicaNegocio.InterfacesRepositorio;
using ComiteLogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IRepositorioDisciplina, RepositorioDisciplina>();
            builder.Services.AddScoped<IRepositorioAtleta, RepositorioAtleta>();
            builder.Services.AddScoped<IRepositorioEvento, RepositorioEvento>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioLog, RepositorioLog>();

            builder.Services.AddScoped<IAltaLogs<DisciplinasAltaDto>, AltaDisciplina>();
            builder.Services.AddScoped<IObtenerTodos<DisciplinasListadoDto>, ObtenerDisciplinas>();
            builder.Services.AddScoped<IObtenerEventosFiltro<EventoConAtletaListadoDto>, ObtenerEventosFiltro>();

            builder.Services.AddScoped<IObtener<DisciplinasAltaDto>, ObtenerDisciplina>();
            builder.Services.AddScoped<IEliminarLogs<DisciplinasAltaDto>, EliminarDisciplina>();
            builder.Services.AddScoped<IEditarLogs<DisciplinasAltaDto>, EditarDisciplina>();

            builder.Services.AddScoped<IObtenerTodosPorDisciplina<AtletaListadoDto>, ObtenerAtletasPorDisciplina>();

            // inyecto los caos de uso de autores
            builder.Services.AddScoped<IObtenerLogin<UsuarioAltaDto>, ObtenerLogin>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // inyectando la Comite Contex
            builder.Services.AddDbContext<ComiteContext>();

            var claveSecreta = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";
            builder.Services.AddAuthentication(aut =>
            {
                aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(aut =>
            {
                aut.RequireHttpsMetadata = false;
                aut.SaveToken = true;
                aut.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(claveSecreta)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
