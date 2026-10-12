KeyValueApp

Aplicação de consola desenvolvida em C# para guardar e gerir configurações em pares de chave e valor, utilizando SQL Server.
O projeto foi inspirado no desafio Key-Value App.
Funcionalidades

- Adicionar uma configuração
- Consultar uma configuração pela chave
- Listar todas as configurações
- Alterar o valor de uma configuração
- Remover uma configuração
- Pesquisar configurações pelo prefixo da chave
- 
Tecnologias
- C#
- .NET 10
- Entity Framework Core
- SQL Server
- LINQ
- 
Executar o projeto

Requisitos
- .NET 10 SDK
- SQL Server ou SQL Server LocalDB
- 
Passos
Clona o repositório e entra na pasta do projeto:

git clone https://github.com/FreeRafa/KeyValue_APP.git
cd KeyValue_APP
Configura a ligação à base de dados no projeto e aplica as migrations:
dotnet ef database update
Inicia a aplicação:
dotnet run
Segurança
Este projeto destina-se a guardar configurações de demonstração. Não guardes passwords, tokens ou outros dados sensíveis.
Autor
Rafael — GitHub
