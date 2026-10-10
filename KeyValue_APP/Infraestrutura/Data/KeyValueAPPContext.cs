using KeyValue_APP.Entidades;
using Microsoft.EntityFrameworkCore;

namespace KeyValue_APP.Infraestrutura.Data
{
    public class KeyValueAPPContext : DbContext
    {
        public KeyValueAPPContext(DbContextOptions<KeyValueAPPContext> options)
            : base(options)
        {
        }

        public DbSet<Configuracao> Configuracoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Configuracao>(entity =>
            {
                entity.Property(c => c.Chave)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.HasIndex(c => c.Chave)
                      .IsUnique();

                entity.Property(c => c.Valor)
                      .HasMaxLength(250)
                      .IsRequired();

                entity.Property(c => c.Descricao)
                      .HasMaxLength(500);

                entity.Property(c => c.CriadaEm)
                      .HasDefaultValueSql("GETDATE()")
                      .IsRequired();

                entity.HasData(
                    new Configuracao { ConfiguracaoId = 1, Chave = "App.IdiomaInterface", Valor = "pt-PT", CriadaEm = new DateTime(2026, 10, 10), Descricao = "Idioma da interface da aplicação" },
                    new Configuracao { ConfiguracaoId = 2, Chave = "App.Tema", Valor = "escuro", CriadaEm = new DateTime(2026, 10, 10), Descricao = "Tema visual da aplicação" },
                    new Configuracao { ConfiguracaoId = 3, Chave = "App.FusoHorario", Valor = "Europe/Lisbon", CriadaEm = new DateTime(2026, 10, 10), Descricao = "Fuso horário usado nas datas apresentadas" },
                    new Configuracao { ConfiguracaoId = 4, Chave = "App.ItensPorPagina", Valor = "20", CriadaEm = new DateTime(2026, 10, 10), Descricao = "Número de itens mostrados por página nas listagens" },
                    new Configuracao { ConfiguracaoId = 5, Chave = "Email.Remetente", Valor = "demo@exemplo.com", CriadaEm = new DateTime(2026, 10, 10), Descricao = "Endereço de remetente de demonstração" },
                    new Configuracao { ConfiguracaoId = 6, Chave = "Email.Porta", Valor = "587", CriadaEm = new DateTime(2026, 10, 10), Descricao = "Porta de envio de demonstração" },
                    new Configuracao { ConfiguracaoId = 7, Chave = "Email.UsarSsl", Valor = "true", CriadaEm = new DateTime(2026, 10, 10), Descricao = "Indica se o envio usa ligação segura" },
                    new Configuracao { ConfiguracaoId = 8, Chave = "Relatorio.FormatoData", Valor = "dd/MM/yyyy", CriadaEm = new DateTime(2026, 10, 10), Descricao = "Formato de data nos relatórios" },
                    new Configuracao { ConfiguracaoId = 9, Chave = "Relatorio.Moeda", Valor = "EUR", CriadaEm = new DateTime(2026, 10, 10), Descricao = "Moeda usada nos relatórios" },
                    new Configuracao { ConfiguracaoId = 10, Chave = "Log.Nivel", Valor = "Information", CriadaEm = new DateTime(2026, 10, 10), Descricao = "Nível mínimo de registo de mensagens" }
                );
            });
        }
    }
}