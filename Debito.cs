
namespace projeto_pagamento
{
    public class Debito : Cartao
    {
        private float Saldo = 10000F;
        public float Valor;

        public bool VerificarSaldo(float Valor)
        {
            bool s = false;
            if (this.Valor > Saldo) {
                s = true;
            }
            return s;
        }
        public override void Pagar(float Valor)
        {
            Console.WriteLine($"o valor a ser pago é {Valor:C2}");
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