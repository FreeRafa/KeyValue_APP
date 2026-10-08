using System;
using System.Collections.Generic;
using System.Text;

namespace KeyValue_APP.Entidades
{
    public class Configuracao
    {
        public int ConfiguracaoId { get; set; }
        public string? Chave { get; set; }
        public string? Valor { get; set; }
        public DateTime CriadaEm { get; set; }
        public DateTime? AtualizadaEm { get; set; }
        public string Descricao { get; set; }

    }
}
