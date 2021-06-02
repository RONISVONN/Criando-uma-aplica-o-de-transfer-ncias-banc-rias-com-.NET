using System;

namespace DIO.Bank
{
    public class Conta
    {

        //Atributos 
        // =========================================================================== //
        private TipoConta TipoConta {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}
        private string Nome {get; set;}
        // =========================================================================== //


        //Método Construtor com parâmetros
        // =========================================================================== //
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            TipoConta = tipoConta;
            Saldo = saldo;
            Credito = credito;
            Nome = nome;
        }
        // =========================================================================== //


        //Método Sacar
        // =========================================================================== //
        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito *-1)) {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            //this.Saldo = this.Saldo - valorSaque;
            //é a mesma coisa => "this.Saldo -= valorSaque;"
            this.Saldo -= valorSaque;

            //Mostra na tela
            Console.WriteLine("Saldo atual da conta {0} é {1}", this.Nome, this.Saldo);
            //https://docs.microsoft.com/pt-br/dotnet/standard/base-types/composite-formatting

            return true;
        }
        // =========================================================================== //



        //Método Depositar
        // =========================================================================== //
        public void Depositar(double valorDepositar)
        {
            //this.Saldo = this.Saldo + valorSaque;
            //é a mesma coisa => "this.Saldo += valorSaque;"
            this.Saldo += valorDepositar;

            //Mostra na tela
            Console.WriteLine("Saldo atual da conta {0} é {1}", this.Nome, this.Saldo);

        }
        // =========================================================================== //


        //Método Transferir
        // =========================================================================== //
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia)) {
                contaDestino.Depositar(valorTransferencia);
            }
            
        }
        // =========================================================================== //


        //Método Mostra/Print os dados da conta na Tela
        //Sobrescrevendo da classe mãe
        // =========================================================================== //
        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
            
            return retorno;
        }
        // =========================================================================== //
       

    }
}