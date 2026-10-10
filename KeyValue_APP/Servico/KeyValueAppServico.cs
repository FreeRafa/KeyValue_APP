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
    }
}
