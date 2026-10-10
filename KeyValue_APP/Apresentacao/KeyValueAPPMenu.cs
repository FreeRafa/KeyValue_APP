using KeyValue_APP.Servico;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeyValue_APP.Apresentacao
{
    public class KeyValueAPPMenu
    {
        private readonly KeyValueAppServico _keyValueAppServico;

        public KeyValueAPPMenu(KeyValueAppServico keyValueAppServico)
        {
            _keyValueAppServico = keyValueAppServico;
        }

        public async Task ExibirMenuAsync()
        {
            string? opcao;

            do
            {
                Console.WriteLine("=== Menu KeyValue_APP ===");
                Console.WriteLine("1. Adicionar Configuração");
                Console.WriteLine("2. Consultar Configuração por Chave");
                Console.WriteLine("3. Consultar Todas as Configurações");
                Console.WriteLine("4. Alterar Configuração");
                Console.WriteLine("5. Remover Configuração");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        await AdicionarConfiguracaoAsync();
                        break;
                    case "2":
                        await ConsultarConfiguracaoPorChaveAsync();
                        break;
                    case "3":
                        await ConsultarTodasConfiguracoesAsync();
                        break;
                    case "4":
                        //await AlterarConfiguracaoAsync();
                        break;
                    case "5":
                        //await RemoverConfiguracaoAsync();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            } while (opcao != "0");
        }

        private async Task AdicionarConfiguracaoAsync()
        {
            Console.Write("Digite a chave da configuração: ");
            string? chave = Console.ReadLine();

            Console.Write("Digite o valor da configuração: ");
            string? valor = Console.ReadLine();

            Console.Write("Digite a descrição da configuração: ");
            string? descricao = Console.ReadLine();

            var configuracao = new Entidades.Configuracao
            {
                Chave = chave,
                Valor = valor,
                Descricao = descricao,
                CriadaEm = DateTime.Now
            };
            await _keyValueAppServico.AdicionarConfiguracoesAsync(configuracao);
            Console.WriteLine("Configuração adicionada com sucesso!");
        }

        private async Task ConsultarConfiguracaoPorChaveAsync()
        {
            Console.WriteLine();
            Console.WriteLine("=== Lista de Chaves ===");
            var configuracoes = await _keyValueAppServico.ConsultarTodasConfiguracoesAsync();
            if (configuracoes.Count == 0)
            {
                Console.WriteLine("Nenhuma configuração encontrada.");
                return;
            }
            foreach (var config in configuracoes)
            {
                Console.WriteLine($"Chave: {config.Chave}, Valor: {config.Valor}, Descrição: {config.Descricao}");
            }

            Console.Write("Digite a chave da configuração: ");
            string? chave = Console.ReadLine();
            var configuracao = await _keyValueAppServico.ConsultarConfiguracaoPorChaveAsync(chave);
            if (configuracao != null)
            {
                Console.WriteLine($"Chave: {configuracao.Chave}, Valor: {configuracao.Valor}, Descrição: {configuracao.Descricao}");
            }
            else
            {
                Console.WriteLine("Configuração não encontrada.");
            }
        }

        private async Task ConsultarTodasConfiguracoesAsync()
        {
            var configuracoes = await _keyValueAppServico.ConsultarTodasConfiguracoesAsync();
            if (configuracoes.Count == 0)
            {
                Console.WriteLine("Nenhuma configuração encontrada.");
                return;
            }
            foreach (var configuracao in configuracoes)
            {
                Console.WriteLine($"Chave: {configuracao.Chave}, Valor: {configuracao.Valor}, Descrição: {configuracao.Descricao}");
            }
        }
    }
}
