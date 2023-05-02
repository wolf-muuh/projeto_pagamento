
namespace projeto_pagamento
{
    public class Debito : Cartao
    {
        private float saldo = 10000F;


        public bool Pagamento(float valor)
        {
            bool s = false;
            if (valor > saldo)
            {

                Console.WriteLine($"Não é possível pagar, Saldo insuficiente.");
                s = true;
            }
            return s;
        }
        public override void Pagar(float compra)
        {
            Console.WriteLine($"o valor a ser pago é {compra}");
        }
        public override void Salvar()
        {
            this.Bandeira = "master";
            this.NumeroCartao = "1234567";
            this.Titular = "Murilo";
            this.Cvv = "123";

            Console.WriteLine($"{Bandeira} {NumeroCartao} {Titular} {Cvv}");

        }
    }
}