using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    internal class Teste
    {
        

        static List<IConta> listaContas = new List<IConta>();

        public void Processar()
        {
            Cliente cliente = new Cliente();
            cliente.Nome = "jose";
            cliente.CPF = "56+5+65";

            IConta conta = new Poupanca();

            conta.cliente = cliente;

            conta.numero = "3232130";
            conta.Depositar(500);
            conta.Sacar(50);


         
            listaContas.Add(conta);

            cliente = new Cliente();
            cliente.Nome = "maria";
            cliente.CPF = "52525";

            conta = new Corrente();

            conta.numero = "645646";
            conta.cliente = cliente;
            conta.Depositar(1000);
            conta.Sacar(52);

            listaContas.Add(conta);
        }
    }
}
