using System.Globalization;

namespace projeto_pagamento
{
    public class Credito : Cartao
    {
        private float Limite = 10000f;
        public float Valor;
        //  Metodos

        public bool Limitar(float compra)
        {
            bool l = false;

            if (compra > this.Limite)
            {
                l = true;
            }

            return l;
        }

        public override void Pagar(float compra)
        {
            bool parcelar = false;
            int p = 0;
            float valorPar = 0, totalPar = 0;
            string opcao;
            string juros = "";

            do
            {
                Console.WriteLine($"");
                
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Voce quer parcelar no cartao:[S/N] ");
                opcao = Console.ReadLine()!.ToUpper();

                Console.WriteLine($"");

                if (opcao != "S" && opcao != "N")
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"ERRO, apenas S ou N");
                    Console.ResetColor();
                }

                Console.ResetColor();
            } while (opcao != "S" && opcao != "N");

            parcelar = opcao == "S" ? true : false;

            if (parcelar == true)
            {

                do
                {
                    Console.WriteLine($"");

                    Console.ForegroundColor = ConsoleColor.DarkGreen;

                    Console.WriteLine(@$"
                    **********************************
                    * De 2 ate 6 vezes: 5% de juros  *
                    * De 7 ate 12 vezes: 8% de juros *
                    **********************************
                    ");
                    
                    
                    
                    Console.Write("Em quantas vezes voce quer parcelar (Somente até 12x): ");
                    p = int.Parse(Console.ReadLine()!);

                    if (p <= 1 || p > 12)
                    {
                        Console.WriteLine($"");
                        
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"ERRO, apenas parcelamos de 2 a 12x !!!");
                        Console.ResetColor();
                    }

                    Console.ResetColor();
                } while (p <= 1 || p > 12);

                if (p <= 6)
                {
                    valorPar = compra * (1 + 0.05f) / p;
                    totalPar = valorPar * p;
                    juros = "5%";
                }

                else if (p >= 7 || p <= 12)
                {
                    valorPar = compra * (1 + 0.08f) / p;
                    totalPar = valorPar * p;
                    juros = "8%";
                }
            }

            else
            {
                valorPar = 0;
                totalPar = compra;
            }

            Console.WriteLine($"");
            
            Console.Beep(2530, 300);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"***********************************************");
            Console.WriteLine(valorPar == 0 ? $"* Não será utilizado parcelas" : $"* Valor das parcelas com juros de {juros}: {valorPar.ToString("C", new CultureInfo("pt-BR"))}");
            Console.WriteLine($"* Valor total com juros: {totalPar.ToString("C", new CultureInfo("pt-BR"))}");
            Console.WriteLine($"***********************************************");
            Console.ResetColor();
        }

        public override void Salvar()
        {   
            Console.ForegroundColor = ConsoleColor.DarkCyan;
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