using ComiteAccesoDatos.EF.Config;
using ComiteLogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ComiteAccesoADatos.EF
{
    public class ComiteContext : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }

        public DbSet<Admin> admins { get; set; }

        public DbSet<Digitador> digitadores { get; set; }

        public DbSet<Disciplina> disciplinas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"
                        Data Source = (localdb)\MSSQLLocalDB; 
                        Initial Catalog = comite; 
                        Integrated Security = True;"
            );
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }


    }
}
