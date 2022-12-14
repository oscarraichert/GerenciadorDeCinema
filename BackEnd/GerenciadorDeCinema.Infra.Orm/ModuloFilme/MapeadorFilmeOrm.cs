using GerenciadorDeCinema.Dominio.Filmes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Infra.Orm.ModuloFilme
{
    public class MapeadorFilmeOrm : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("TBFilme");
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Imagem).IsRequired();
            builder.Property(x => x.Titulo).IsRequired();
            builder.Property(x => x.Descricao).IsRequired();
            builder.Property(x => x.Duracao).IsRequired();
        }
    }
}
