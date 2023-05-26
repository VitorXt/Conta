using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    interface IConta
    {
        double saldo { get; set; }
        string numero { get; set; }
        Cliente cliente { get; set; }

        double CalcularSaldo();
        void Sacar(double valor);
        void Depositar(double valor);

    }
}
