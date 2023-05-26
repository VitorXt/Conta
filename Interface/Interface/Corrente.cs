using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Corrente : IConta
    {
        public double saldo { get; set; }
        public string numero { get; set; }
        public decimal taxa { get; set; }
        public Cliente cliente { get; set; }

        public double CalcularSaldo()
        {
            return saldo;
        }

        public void Depositar(double valor)
        {
            saldo += valor;
            Console.WriteLine($"Depósito de R${valor} realizado com sucesso na conta salário {numero}");
        }

        public void Sacar(double valor)
        {
            if (valor <= saldo)
            {
                saldo -= valor;
                Console.WriteLine($"Saque de R${valor} realizado com sucesso na conta salário {numero}");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente.");
            }
        }

        public double CalcularTarifa()
        {
            return 0;
        }
    }
}
