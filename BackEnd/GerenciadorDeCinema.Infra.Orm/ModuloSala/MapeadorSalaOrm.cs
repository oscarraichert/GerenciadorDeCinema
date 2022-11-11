using GerenciadorDeCinema.Dominio.ModuloSala;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Infra.Orm.ModuloSala
{
    public class MapeadorSalaOrm : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder.ToTable("TBSala");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.QuantidadeAssentos).IsRequired();
        }
    }
}
