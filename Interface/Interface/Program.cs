using System;
using System.Collections.Generic;
namespace Interface
{
    class Program
    {
        static List<IConta> listaContas = new List<IConta>();
        static void Main(string[] args)
        {
            int opcao = 0;

            while (opcao != 4)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Menu de Opções:");
                Console.WriteLine("1) Criar uma conta");
                Console.WriteLine("2) Realizar saque");
                Console.WriteLine("3) Realizar depósito");
                Console.WriteLine("4) Sair");
                Console.WriteLine(" ");
                Console.Write("Selecione uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        criarConta();
                        break;
                    case 2:
                        saque();
                        break;
                    case 3:
                        deposito();
                        break;
                    case 4:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
                Console.WriteLine();
            }
        }
        static void criarConta()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Tipos de conta:");
            Console.WriteLine("1) Salário");
            Console.WriteLine("2) Corrente");
            Console.WriteLine("3) Poupança");
            Console.WriteLine(" ");
            Console.Write("Selecione o tipo de conta: ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.Write("Informe o número da conta: ");
            string ContaNumero = Console.ReadLine();
            Console.Write("Informe o CPF do titular da conta: ");
            string cpfTitular = Console.ReadLine();
            Console.Write("Informe o Nome do titular da conta: ");
            string nome = Console.ReadLine();
            Console.Write("Informe o saldo inicial da conta: ");
            double saldo = double.Parse(Console.ReadLine());


            Cliente cliente = buscarClientePorCPF(cpfTitular);
            if (cliente == null)
            {
                cliente = criarCliente();
                if (cliente == null)
                {
                    Console.WriteLine("Falha ao criar a conta. Verifique os dados informados.");
                    return;
                }
            }

            switch (tipoConta)
            {
                case 1:
                    IConta contaS = new Salario();
                    contaS.cliente = cliente;
                    listaContas.Add(contaS);
                    Console.WriteLine("Conta salário criada com sucesso.");
                    break;
                case 2:
                    IConta contaC = new Corrente();
                    contaC.cliente = cliente;
                    listaContas.Add(contaC);
                    Console.WriteLine("Conta corrente criada com sucesso.");
                    break;
                case 3:
                    IConta contaP = new Poupanca();
                    contaP.cliente = cliente;
                    listaContas.Add(contaP);
                    Console.WriteLine("Conta poupança criada com sucesso.");
                    break;
                default:
                    Console.WriteLine("Tipo de conta inválido!");
                    break;
            }
        }
        static Cliente criarCliente()
        {

            Cliente cliente = new Cliente();

            Console.WriteLine(" ");
            Console.Write("Informe o nome do titular: ");
            cliente.Nome = Console.ReadLine();
            Console.Write("Informe o CPF do titular: ");
            cliente.CPF = Console.ReadLine();


            if (buscarClientePorCPF(cliente.CPF) != null)
            {
                Console.WriteLine("Já existe um cliente com o CPF informado. Não é possível adicionar um cliente duplicado.");
                return null;
            }

            Console.WriteLine("Cliente criado com sucesso.");

            return cliente;
        }
        static Cliente buscarClientePorCPF(string cpf)
        {
            Cliente cliente = new Cliente();
            while (cliente.CPF == cpf)
            {
                    return cliente;      
            }
            return null;
        }
        static void saque()
        {
            Console.Write("Informe o número da conta: ");
            string numero = Console.ReadLine();

            IConta conta = buscarContaPorNumero(numero);
            if (conta == null)
            {
                Console.WriteLine("Conta não encontrada. Verifique o número informado.");
                return;
            }

            Console.Write("Informe o valor do saque: ");
            double valor = double.Parse(Console.ReadLine());

            conta.Sacar(valor);
        }
        static void deposito()
        {
            Console.Write("Informe o número da conta: ");
            string numero = Console.ReadLine();

            IConta conta = buscarContaPorNumero(numero);
            if (conta == null)
            {
                Console.WriteLine("Conta não encontrada. Verifique o número informado.");
                return;
            }

            Console.Write("Informe o valor do depósito: ");
            double valor = double.Parse(Console.ReadLine());

            conta.Depositar(valor);         
        }
        static IConta buscarContaPorNumero(string ContaNumero)
        {
            foreach (IConta conta in listaContas)
            {
                if (conta.numero == ContaNumero)
                {
                    return conta;
                }
            }
            return null;
        }
    }
}