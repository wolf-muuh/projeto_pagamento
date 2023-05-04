using System.Globalization;

namespace projeto_pagamento
{
    public class Boleto : Pagamento
    {
        

        public void Registrar()
        {
            Random codigodebarras = new Random();
            double UltDigitos = Valor*0.88;

            Console.Beep(2530, 300);

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(@$"
            ***************************************************************************************************************************
            * O Valor a ser pago com desconto de 12%, será de R${Valor*0.88:N2}                                                                                                        
            
            * Segue o boleto:

            * 34191.{codigodebarras.Next(90000)} {codigodebarras.Next(90000)}.{codigodebarras.Next(900000)} {codigodebarras.Next(90000)}.{codigodebarras.Next(900000)} 3 {codigodebarras.Next(900000000)}000{(UltDigitos).ToString().Replace(".", "")}


            * O boleto tem vencimento no dia {Data}
            **************************************************************************************************************************
            ");
            Console.ResetColor();

        }   
        
    }
}