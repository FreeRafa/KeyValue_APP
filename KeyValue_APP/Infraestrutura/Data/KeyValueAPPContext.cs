using KeyValue_APP.Entidades;
using Microsoft.EntityFrameworkCore;


namespace KeyValue_APP.Infraestrutura
{
    public class KeyValueAPPContext : DbContext
    {
        public DbSet<Configuracao> Configuracoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppConfig.GetConnectionString());
        }

        public KeyValueAPPContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Configuracao>(entity =>
            {
                entity.Property(c => c.Chave)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(c => c.Valor)
                      .HasMaxLength(250)
                      .IsRequired();

                entity.Property(c => c.Descricao)
                        .HasMaxLength(500);

                entity.Property(c => c.CriadaEm)
                      .HasDefaultValueSql("GETDATE()")
                      .IsRequired();
            });
        }
    }
}
