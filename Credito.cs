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
                    Console.Write("Em quantas vezes voce quer paracelar (Somente até 12x): ");
                    p = int.Parse(Console.ReadLine()!);

                    if (p <= 0 || p > 12)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"ERRO, apenas parcelamos de 1 a 12x !!!");
                        Console.ResetColor();
                    }

                    Console.ResetColor();
                } while (p <= 0 || p > 12);

                if (p == 6)
                {
                    valorPar = compra * (1 + 0.05f) / p;
                    totalPar = valorPar * p;
                }

                else if (p >= 7 || p <= 12)
                {
                    valorPar = compra * (1 + 0.08f) / p;
                    totalPar = valorPar * p;
                }
            }

            else
            {
                valorPar = 0;
                totalPar = compra;
            }

            Console.WriteLine($"");
            
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"Valor das parcelas com juros: {valorPar.ToString("C", new CultureInfo("pt-BR"))}");
            Console.WriteLine($"Valor total com juros: {totalPar.ToString("C", new CultureInfo("pt-BR"))}");
            Console.ResetColor();
        }

        public override void Salvar()
        {   
            Console.WriteLine($"");
            
            this.Bandeira = "Master";
            this.NumeroCartao = "1234567";
            this.Titular = "Murilo";
            this.Cvv = "123";
            
            Console.WriteLine($"{this.Bandeira}, {this.NumeroCartao}, {this.Titular}, {this.Cvv}");
            
        }
    }
}