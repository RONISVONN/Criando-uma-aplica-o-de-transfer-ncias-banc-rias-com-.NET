using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {

    //"List"/Lista = Grava uma "Collection"/coleção ou melhor Gravar na memória as contas e os dados
	static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {

            /*
            //Instânciando de um Objeto
            //Ou melhor
            //Cria um objeto
            Conta minhaConta = new Conta();

            //Recebe um set Nome "Ronisvonn"
            minhaConta.Nome = "Ronisvonn";
            
            //Mostra o get Nome "Ronisvonn"
            Console.WriteLine(minhaConta.Nome.ToString());
            
            //Mostra na Tela ou pausa na tela mostrando o conteudo
            Console.Read();

            //Console.Read();       // Apenas para ler oque está na tela do console é oque você quer , faz tipo um "Pause" do  Batch
            //Console.ReadKey();    // Faz a leitura das entradas do teclado e espera você pressionar qualquer letra e continua
            //Console.ReadLine();   // Ler uma string ou linha
            */

            /*
            Conta minhaConta = new Conta(TipoConta.PessoaFisica, 0, 0, "Ronisvonn");
            Console.WriteLine(minhaConta.ToString());
            Console.Read();
            */

        // =========================================================================== //
            //Opções do Usuario Menu
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarContas();
						break;
					case "2":
						InserirConta();
						break;
					case "3":
						Transferir();
						break;
					case "4":
						Sacar();
						break;
					case "5":
						Depositar();
						break;
                    case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}
			
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}
        // =========================================================================== //



        // =========================================================================== //
        //Método "Depositar"
		private static void Depositar()
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
		}
        // =========================================================================== //



        // =========================================================================== //

		private static void Sacar()
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
		}
        // =========================================================================== //



        // =========================================================================== //
		private static void Transferir()
		{
			Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
		}
        // =========================================================================== //




        // =========================================================================== //
		private static void InserirConta()
		{
			Console.WriteLine("Inserir nova conta");

			Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int entradaTipoConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Cliente: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o saldo inicial: ");
			double entradaSaldo = double.Parse(Console.ReadLine());

			Console.Write("Digite o crédito: ");
			double entradaCredito = double.Parse(Console.ReadLine());

			Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
										saldo: entradaSaldo,
										credito: entradaCredito,
										nome: entradaNome);

			listContas.Add(novaConta);
		}
        // =========================================================================== //


        // =========================================================================== //
		private static void ListarContas()
		{
			Console.WriteLine("Listar contas");

			if (listContas.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
				return;
			}

			for (int i = 0; i < listContas.Count; i++)
			{
				Conta conta = listContas[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);
			}
		}
        // =========================================================================== //


        // =========================================================================== //
        //Menu de opções
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Bank a seu dispor !!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir Nova Conta");
            Console.WriteLine("3 - Tranferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        // =========================================================================== //


    }
}
