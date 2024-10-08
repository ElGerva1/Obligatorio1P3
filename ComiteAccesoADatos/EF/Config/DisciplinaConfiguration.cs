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
    public class DisciplinaConfiguration : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder.HasIndex(a => a.Nombre).IsUnique();
        }
    }
}
