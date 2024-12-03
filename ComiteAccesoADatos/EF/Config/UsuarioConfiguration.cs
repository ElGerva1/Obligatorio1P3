using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.Vo.Generic;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection.Emit;

namespace ComiteAccesoDatos.EF.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            // indico a EF que nombre es un VO de 1 (UN) solo atributo
            // configura el vo de nombre en este caso con hasconversion porque luego
            // vamos a crear un indice unico
            var emailConvert = new ValueConverter<Email, string>(
            v => v.Value,
                v => new Email(v)
             );
            builder.Property(a => a.Email).HasConversion(emailConvert);
            builder.HasIndex(a => a.Email).IsUnique();

            // indico a EF que nombre es un VO de 1 (UN) solo atributo
            // configura el vo de nombre en este caso con hasconversion porque luego
            // vamos a crear un indice unico
            var passwordConvert = new ValueConverter<Password, string>(
            v => v.Value,
                v => new Password(v)
             );
            builder.Property(a => a.Password).HasConversion(passwordConvert);
            builder.HasIndex(a => a.Password).IsUnique();
        }
    }
}
