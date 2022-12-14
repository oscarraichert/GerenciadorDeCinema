using GerenciadorDeCinema.Dominio.ModuloSessao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Infra.Orm.ModuloSessao
{
    public class MapeadorSessaoOrm : IEntityTypeConfiguration<Sessao>
    {
        public void Configure(EntityTypeBuilder<Sessao> builder)
        {
            builder.ToTable("TBSessao");
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.HorarioInicio).IsRequired();
            builder.Property(x => x.HorarioFim).IsRequired();
            builder.Property(x => x.ValorIngresso).IsRequired();
            builder.Property(x => x.TipoAnimacao).IsRequired();
            builder.Property(x => x.TipoAudio).IsRequired();
            builder.Property(x => x.FilmeId).IsRequired();
            builder.Property(x => x.SalaId).IsRequired();
            builder.HasOne(x => x.Filme).WithMany(x => x.Sessoes).HasForeignKey(x => x.FilmeId);
            builder.HasOne(x => x.Sala).WithMany(x => x.Sessoes).HasForeignKey(x => x.SalaId);
        }
    }
}
