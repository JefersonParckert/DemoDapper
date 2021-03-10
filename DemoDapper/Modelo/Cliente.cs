using System;

namespace DemoDapper.Modelo
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }

        public override string ToString()
        {
            return $"Nome:{Nome}, Data Nascimento: {DataNascimento:d}, CPF: {CPF}";
        }
    }
}
