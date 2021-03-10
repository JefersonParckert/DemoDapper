using Bogus;
using Bogus.Extensions.Brazil;
using DemoDapper.Modelo;
using DemoDapper.Repositorio;
using System;
using System.Linq;

namespace DemoDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            ClienteRepositorio repo = new ClienteRepositorio();

            ListarClientes(repo, "DADOS INICIAIS DA BASE DE DADOS");

            InserirCliente(repo);

            ListarClientes(repo, "CLIENTES CADASTRADOS NA BASE");

            RemoverCliente(repo);

            ListarClientes(repo, "CLIENTES CADASTRADOS NA BASE");

            Console.WriteLine("Pressione qualquer tecla para finalizar");
            Console.ReadKey();

        }

        static void RemoverCliente(ClienteRepositorio repo)
        {
            Console.WriteLine("Removendo Cliente");
            var clientes = repo.SelectClientes();
            var cliente = clientes.First();

            if (repo.RemoverCliente(cliente) > 0)
            {
                Console.WriteLine($"Cliente: {cliente.Nome} Removido com sucesso!");
            }

            Console.WriteLine();
        }

        static void InserirCliente(ClienteRepositorio repo)         
        {
            Console.WriteLine("Inserindo novo Cliente");
            var faker = new Faker("pt_BR");
            var cliente = new Cliente {
                Id = Guid.NewGuid(),
                Nome = faker.Name.FirstName(),
                DataNascimento = faker.Date.Between(DateTime.Now.AddYears(-70), DateTime.Now),
                CPF = faker.Person.Cpf()
            };

            if (repo.InserirCliente(cliente) > 0)
            {
                Console.WriteLine($"Cliente: {cliente.Nome} inserido com sucesso!");
            }

            Console.WriteLine();
        }

        static void ListarClientes(ClienteRepositorio repo, string mensagem)
        {
            Console.WriteLine(mensagem);
            var clientes = repo.SelectClientes();
            foreach (var cliente in clientes)
                Console.WriteLine(cliente.ToString());

            Console.WriteLine();
        }
    }
}
