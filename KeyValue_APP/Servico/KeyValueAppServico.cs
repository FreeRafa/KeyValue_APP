using KeyValue_APP.Entidades;
using KeyValue_APP.Infraestrutura.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeyValue_APP.Servico
{
    public class KeyValueAppServico
    {
        private readonly KeyValueAPPRepositorio KeyValueAPP_repositorio;

        public KeyValueAppServico(KeyValueAPPRepositorio KeyValueAPPrepositorio)
        {
            KeyValueAPP_repositorio = KeyValueAPPrepositorio;
        }

        public async Task<Configuracao> AdicionarConfiguracoesAsync(Configuracao configuracao)
        {
            return await KeyValueAPP_repositorio.AdicionarConfiguracoesAsync(configuracao);
        }

        public async Task<Configuracao> ConsultarConfiguracaoPorChaveAsync(string chave)
        {
            return await KeyValueAPP_repositorio.ConsultarConfiguracaoPorChaveAsync(chave);
        }

        public async Task<List<Configuracao>> ConsultarTodasConfiguracoesAsync()
        {
            return await KeyValueAPP_repositorio.ConsultarTodasConfiguracoesAsync();
        }

        public async Task<Configuracao> AlterarConfiguracaoAsync(string chave, string novoValor, string novaDescricao)
        {
            return await KeyValueAPP_repositorio.AlterarConfiguracaoAsync(chave, novoValor, novaDescricao);
        }

        public async Task<bool> RemoverConfiguracaoAsync(string chave)
        {
            return await KeyValueAPP_repositorio.RemoverConfiguracaoAsync(chave);
        }
    }
}
