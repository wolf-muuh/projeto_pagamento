using System.Globalization;

namespace projeto_pagamento
{
    public class Credito
    {
        private float Limite = 10000f;

        //  Metodos
         public void Parcelar(float compra) {
            bool parcelar = false;
            int p = 0;
            float valorPar = 0, totalPar = 0;
            string opcao;

            do {
                Console.Write("Voce quer parcelar no cartao:[S/N] ");
                opcao = Console.ReadLine()!.ToUpper();

                Console.WriteLine($"");
                
                if (opcao != "S" && opcao != "N") {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"ERRO, apenas S ou N");
                    Console.ResetColor();
                }
            } while(opcao != "S" && opcao != "N");


            parcelar = opcao == "S" ? true : false;

            if (parcelar == true) {
                Console.Write("Em quantas vezes voce quer paracelar (Somente até 12x): ");
                p = int.Parse(Console.ReadLine()!);

                if (p == 6) {
                    valorPar = compra * (1 + 0.05f) / p;
                    totalPar = valorPar * p;
                }

                else if (p >= 7 || p <= 12) {
                    valorPar = compra * (1 + 0.08f) / p;
                    totalPar = valorPar * p;
                }
            }

                Console.WriteLine($"Valor das parcelas com {p}% de juros: {valorPar.ToString("C", new CultureInfo("pt-BR"))}");    
                Console.WriteLine($"Valor total com juros: {totalPar.ToString("C", new CultureInfo("pt-BR"))}");    
            
         }

    }
}