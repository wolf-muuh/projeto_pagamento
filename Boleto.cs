using System.Globalization;

namespace projeto_pagamento
{
    public class Boleto : Pagamento
    {
        

        public void Registrar()
        {
            Random codigodebarras = new Random();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(@$"
            ***************************************************************************************************************************
            * O Valor a ser pago com desconto será de R${Valor*0.88:N2}                                                                                                        
            
            * Segue o boleto:

            * 34191.{codigodebarras.Next(90000)} {codigodebarras.Next(90000)}.{codigodebarras.Next(900000)} {codigodebarras.Next(90000)}.{codigodebarras.Next(900000)} 3 {codigodebarras.Next(900000000)}000{Math.Round(Valor*0.88)}


            * O boleto tem vencimento no dia {Data}
            **************************************************************************************************************************
            ");
            Console.ResetColor();

        }   
        
    }
}