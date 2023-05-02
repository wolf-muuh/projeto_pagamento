
float ValorPago = 0;
int Opcao = 0;
Console.WriteLine(@$"
░░░█░█░█▀█░█▀▀░█▀▀░░░█▀▀░█▀▀░▀█▀░█▀█░░░█▀█░█▀█░░░█▀█░▀█▀░█░█░█▀█░█▀█░█░█░░░░
░░░▀▄▀░█░█░█░░░█▀▀░░░█▀▀░▀▀█░░█░░█▀█░░░█░█░█░█░░░█▀▀░░█░░▄▀▄░█▀▀░█▀█░░█░░░░░
░░░░▀░░▀▀▀░▀▀▀░▀▀▀░░░▀▀▀░▀▀▀░░▀░░▀░▀░░░▀░▀░▀▀▀░░░▀░░░▀▀▀░▀░▀░▀░░░▀░▀░░▀░░░░░
");
do
{
do
{
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine(@$"
             *************************************
             *    Insira o valor da compra      *
             *************************************");
    ValorPago = float.Parse(Console.ReadLine());
    Console.ResetColor();
}
while (ValorPago <= 0);

Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.ResetColor();
Console.ForegroundColor = ConsoleColor.Red;

    Console.WriteLine(@$" 
             *************************************
             *    Escolha a forma de pagamento:  *
              |1|---> Boleto
              |2|---> Credito
              |3|---> Debito
              |4|---> Cancelar Operação
              |0|---> Sair do Sistema    
             *************************************
    
    
    ");
    Opcao = int.Parse(Console.ReadLine());

switch (Opcao)
{
    case 1:
        Console.WriteLine($"parabéns vc escolheu 1");
        // Boleto boletoNovo = new Boleto();
        // boletoNovo.Boleto = ValorPago;
        // Console.WriteLine(ValorPago);
        break;
    case 2:
        // Console.WriteLine($"parabéns vc escolheu 2");
        // Credito creditoNovo = new Credito();
        // creditoNovo.Credito = ValorPago;
        // Console.WriteLine(ValorPago);
        break;
    case 3:
        Console.WriteLine($"parabéns vc escolheu 3");
        break;
    case 4:
        // Console.WriteLine($"parabéns vc escolheu 4");
        Opcao = 20;
        break;
    case 0:
        // Console.WriteLine($"parabéns vc escolheu 0");
        break;
    default:
        Console.WriteLine(@$"
             *************************************
             *        Opcao invalida             *
             *************************************");
        break;
}
} while (Opcao != 1 && Opcao != 2 && Opcao != 3 && Opcao != 4 && Opcao != 0);
Console.WriteLine(@$"
░█▀█░█▀▀░█▀▄░█▀█░█▀▄░█▀▀░█▀▀░█▀▀░█▄█░█▀█░█▀▀░░░█▀█░█▀█░█▀▄░░░█░█░█▀▀░█▀█░█▀▄░░░█▀█░░░█▀█░▀█▀░█░█░█▀█░█▀█░█░█░░
░█▀█░█░█░█▀▄░█▀█░█░█░█▀▀░█░░░█▀▀░█░█░█░█░▀▀█░░░█▀▀░█░█░█▀▄░░░█░█░▀▀█░█▀█░█▀▄░░░█░█░░░█▀▀░░█░░▄▀▄░█▀▀░█▀█░░█░░░
░▀░▀░▀▀▀░▀░▀░▀░▀░▀▀░░▀▀▀░▀▀▀░▀▀▀░▀░▀░▀▀▀░▀▀▀░░░▀░░░▀▀▀░▀░▀░░░▀▀▀░▀▀▀░▀░▀░▀░▀░░░▀▀▀░░░▀░░░▀▀▀░▀░▀░▀░░░▀░▀░░▀░░░
");
Console.ResetColor();