using KeyValue_APP.Apresentacao;
using KeyValue_APP.Infraestrutura.Data;
using KeyValue_APP.Infraestrutura.Repositorio;
using KeyValue_APP.Servico;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

string connectionString = config.GetConnectionString("KeyValueDB")
    ?? throw new InvalidOperationException("Connection string 'KeyValueDB' não encontrada.");

var service = new ServiceCollection();

service.AddDbContext<KeyValueAPPContext>(options =>
    options.UseSqlServer(connectionString));


service.AddScoped<KeyValueAPPRepositorio>();
service.AddScoped<KeyValueAppServico>();
service.AddScoped<KeyValueAPPMenu>();

using var serviceProvider = service.BuildServiceProvider();
using var scope = serviceProvider.CreateScope();

var keyValue_APPMenu = scope.ServiceProvider.GetRequiredService<KeyValueAPPMenu>();
await keyValue_APPMenu.ExibirMenuAsync();








//SOMENTE PARA TESTE DE BANCO DE DADOS, NÃO É NECESSÁRIO PARA O FUNCIONAMENTO DO PROGRAMA

//using KeyValue_APP.Infraestrutura.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;

//var config = new ConfigurationBuilder()
//    .SetBasePath(Directory.GetCurrentDirectory())
//    .AddJsonFile("appsettings.json")
//    .Build();

//string connectionString = config.GetConnectionString("KeyValueDB")
//    ?? throw new InvalidOperationException("Connection string 'KeyValueDB' não encontrada.");

//var options = new DbContextOptionsBuilder<KeyValueAPPContext>()
//    .UseSqlServer(connectionString)
//    .Options;

//using (KeyValueAPPContext context = new KeyValueAPPContext(options))
//{
//    //.EsureDelete-> exclui o banco de dados se ele existir, usando apenas em desenvolvimento nunca em produçao
//    context.Database.EnsureDeleted();
//    Console.WriteLine("Criando o banco de dados... \n");
//    //.EnsureCreated-> cria o banco de dados se ele existir
//    context.Database.EnsureCreated();
//    Console.WriteLine("Operaçao realizada com sucesso... \n");
//}

//Console.ReadKey();