using KeyValue_APP.Entidades;
using KeyValue_APP.Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;

namespace KeyValue_APP.Infraestrutura.Repositorio
{
    public class KeyValueAPPRepositorio
    {
        private readonly KeyValueAPPContext _context;

        public KeyValueAPPRepositorio(KeyValueAPPContext context)
        {
            _context = context;
        }

        public async Task<Configuracao> AdicionarConfiguracoesAsync(Configuracao configuracao)
        {
            _context.Configuracoes.Add(configuracao);
            await _context.SaveChangesAsync();
            return configuracao;
        }

        public async Task<Configuracao> ConsultarConfiguracaoPorChaveAsync(string chave)
        {
            return await _context.Configuracoes.FirstOrDefaultAsync(c => c.Chave == chave);
        }

        public async Task<List<Configuracao>> ConsultarTodasConfiguracoesAsync()
        {
            return await _context.Configuracoes.ToListAsync();
        }

        public async Task<Configuracao> AlterarConfiguracaoAsync(Configuracao configuracao)
        {
            _context.Configuracoes.Update(configuracao);
            await _context.SaveChangesAsync();
            return configuracao;
        }

        public async Task<bool> RemoverConfiguracaoAsync(Configuracao configuracao)
        {
            _context.Configuracoes.Remove(configuracao);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
