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