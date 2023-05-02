using projeto_pagamento;


float ValorPago = 0;
int Opcao = 0;
bool limite;

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
    Opcao = int.Parse(Console.ReadLine()!);

switch (Opcao)
{
    case 1:
        Boleto boletoNovo = new Boleto();
        boletoNovo.Valor = ValorPago;
        boletoNovo.Registrar();
        break;

    case 2:
        Credito creditoNovo = new Credito();
        creditoNovo.Valor = ValorPago;
        limite = creditoNovo.Limitar(ValorPago);

        if (limite == true) {
            Console.WriteLine($"Limite do cartao ultrapassado !!!");
        }

        else {
            creditoNovo.Pagar(ValorPago);
        }
        break;

    case 3:
        Debito debitoNovo = new Debito();
        debitoNovo.Valor = ValorPago;

        limite = debitoNovo.VerificarSaldo(ValorPago);

        if (limite == true) {
           Console.WriteLine($"Saldo insuficiente !!!");
        }

        else {
            debitoNovo.Pagar(ValorPago);
        }
        break;

    case 4:
        Pagamento pagamentoNovo = new Pagamento();
        Console.WriteLine(pagamentoNovo.Cancelar());
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

