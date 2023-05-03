using System.Globalization;

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
            Console.Beep(2530, 300);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"*****************************************");
            Console.WriteLine($"*     Valor a ser pago é {Valor.ToString("C", new CultureInfo("pt-BR"))}          *");
            Console.WriteLine($"*****************************************");
            Console.ResetColor();
        }
        public override void Salvar()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@$"
************************
*    INFO DO CARTÃO    *
************************
* Bandeira: {this.Bandeira}
* Numero do cartão: {this.NumeroCartao}
* Titular: {this.Titular}
* CVV: {this.Cvv}
************************
            ");
            Console.ResetColor();
        }
    }
}