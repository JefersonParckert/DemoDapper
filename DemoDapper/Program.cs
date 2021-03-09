using Bogus;
using DemoDapper.Repositorio;
using System;

namespace DemoDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            ClienteRepositorio repo = new ClienteRepositorio();

            Console.WriteLine("DADOS INICIAIS DA BASE DE DADOS");
            var clientes = repo.SelectClientes();
            foreach (var cliente in clientes)
                Console.WriteLine(cliente.ToString());


            var faker = new Faker("pt_BR");
            Console.WriteLine(faker.Name.FirstName());
            Console.WriteLine((DateTime.Now - DateTime.Now.AddYears(-5)).TotalSeconds);


            Console.WriteLine("Pressione qualquer tecla para finalizar");
            Console.ReadKey();

        }
    }
}
