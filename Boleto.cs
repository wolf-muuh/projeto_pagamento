namespace trabalho_em_grupo
{
    public class Boleto
    {
        public int CodBarras;

        public void Registrar()
        {



            Random codigodebarras = new Random();
            Console.WriteLine(@$"O Valor a ser pago com desconto sera de {ValorPago*0.88}
            
            
            Segue o boleto:

            34191.{codigodebarras.Next(90000)} {codigodebarras.Next(90000)}.{codigodebarras.Next(900000)} {codigodebarras.Next(90000)}.{codigodebarras.Next(900000)} 3 {codigodebarras.Next(900000000)}{ValorPago*0.88}
            
            ");
            
        }   
        
    }
}