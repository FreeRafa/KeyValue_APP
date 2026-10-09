
using KeyValue_APP.Infraestrutura;

using (KeyValueAPPContext context = new KeyValueAPPContext())
{
    //.EsureDelete-> exclui o banco de dados se ele existir, usando apenas em desenvolvimento nunca em produçao
    context.Database.EnsureDeleted();
    Console.WriteLine("Criando o banco de dados... \n");
    //.EnsureCreated-> cria o banco de dados se ele existir
    context.Database.EnsureCreated();
    Console.WriteLine("Operaçao realizada com sucesso... \n");

}

Console.ReadKey();