using projeto_pagamento;


float ValorPago = 0;
string Opcao = "";
bool limite;

Console.BackgroundColor = ConsoleColor.DarkBlue;
Console.WriteLine(@$"
░░░█░█░█▀█░█▀▀░█▀▀░░░█▀▀░█▀▀░▀█▀░█▀█░░░█▀█░█▀█░░░█▀█░▀█▀░█░█░█▀█░█▀█░█░█░░░░
░░░▀▄▀░█░█░█░░░█▀▀░░░█▀▀░▀▀█░░█░░█▀█░░░█░█░█░█░░░█▀▀░░█░░▄▀▄░█▀▀░█▀█░░█░░░░░
░░░░▀░░▀▀▀░▀▀▀░▀▀▀░░░▀▀▀░▀▀▀░░▀░░▀░▀░░░▀░▀░▀▀▀░░░▀░░░▀▀▀░▀░▀░▀░░░▀░▀░░▀░░░░░
");
Console.ResetColor();

while (Opcao != "0" && Opcao != "N") {
do {
    do {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine(@$"
                *************************************
                *    Insira o valor da compra      *
                *************************************");
        Console.Write("     -> ");
        ValorPago = float.Parse(Console.ReadLine()!);

        if ( ValorPago <= 0) {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"ERRO, apenas valores MAIORES que 0 !!!");
            Console.ResetColor();
            Console.Beep(550, 500);
        }
        Console.ResetColor();
    } while (ValorPago <= 0);

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
        Console.Write("     -> ");
        Opcao = Console.ReadLine()!;

    switch (Opcao)
{
    case "1":
        Boleto boletoNovo = new Boleto();
        boletoNovo.Valor = ValorPago;
        boletoNovo.Registrar();
        break;

    case "2":
        Credito creditoNovo = new Credito();
        creditoNovo.Valor = ValorPago;
        limite = creditoNovo.Limitar(ValorPago);
        
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(@$"
***********************
*   Dados do Cartao   *
***********************
        ");

        Console.Write("* Bandeira do cartão: ");
        creditoNovo.Bandeira = Console.ReadLine()!;
    
        Console.WriteLine($"");
        
        Console.Write("* Numero do cartão: ");
        creditoNovo.NumeroCartao = Console.ReadLine()!;

        Console.WriteLine($"");
        
        Console.Write("* Titular: ");
        creditoNovo.Titular = Console.ReadLine()!;
        
        Console.WriteLine($"");
        
        Console.Write("* CVV do cartão: ");
        creditoNovo.Cvv = Console.ReadLine()!;

        Console.WriteLine($"***********************");
        
        if (limite == true) {
            Console.WriteLine(@$"
            *************************************
            * Limite do cartao ultrapassado !!! *
            *************************************
            ");
        }

        else {
            creditoNovo.Salvar();
            
            Console.WriteLine($"");

            creditoNovo.Pagar(ValorPago);
        }
        break;

    case "3":
        Debito debitoNovo = new Debito();
        debitoNovo.Valor = ValorPago;

        limite = debitoNovo.VerificarSaldo(ValorPago);

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(@$"
***********************
*   Dados do Cartao   *
***********************
        ");

        Console.Write("Bandeira do cartão: ");
        debitoNovo.Bandeira = Console.ReadLine()!;
    
        Console.WriteLine($"");
        
        Console.Write("Numero do cartão: ");
        debitoNovo.NumeroCartao = Console.ReadLine()!;

        Console.WriteLine($"");
        
        Console.Write("Titular: ");
        debitoNovo.Titular = Console.ReadLine()!;
        
        Console.WriteLine($"");
        
        Console.Write("CVV do cartão: ");
        debitoNovo.Cvv = Console.ReadLine()!;
        Console.WriteLine($"***********************");

        if (limite == true) {
           Console.WriteLine(@$"
           **************************
           * Saldo insuficiente !!! *
           **************************
           ");
        }

        else {
            Console.WriteLine($"");
            
            debitoNovo.Salvar();

            Console.WriteLine($"");
            
            debitoNovo.Pagar(ValorPago);
        }
        break;

    case "4":
        Pagamento pagamentoNovo = new Pagamento();
        Console.WriteLine(pagamentoNovo.Cancelar());
        Console.Beep(550, 500);
        Thread.Sleep(1000);
        Opcao = "";
        Console.Clear();
        break;

    case "0":
        break;

    default:
        Console.Beep(3000, 500);
        Console.WriteLine(@$"
        *************************************
        *            Opcao invalida          *
        *************************************");
        Thread.Sleep(1000);
        break;
}

if (Opcao != "0") {
    do {
        Console.WriteLine($"");
        
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("Voce quer fazer mais uma operação ? [S/N]:");
        Console.ResetColor();
        Opcao = Console.ReadLine()!.ToUpper();       

        if (Opcao != "S" && Opcao != "N") {
            Console.WriteLine($"");
            
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"ERRO, apenas S ou N");
            Console.ResetColor();
        }

    } while(Opcao != "S" && Opcao != "N");
}

} while (Opcao != "1" && Opcao != "2" && Opcao != "3" && Opcao != "4" && Opcao != "0" && Opcao != "N");
} 


Thread.Sleep(1000);

Console.Beep(1000, 300);
Console.Beep(2000, 300);
Console.Beep(3000, 150);
Console.Beep(250, 400);

Thread.Sleep(1000);

Console.Clear();

Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine(@$"
░█▀█░█▀▀░█▀▄░█▀█░█▀▄░█▀▀░█▀▀░█▀▀░█▄█░█▀█░█▀▀░░░█▀█░█▀█░█▀▄░░░█░█░█▀▀░█▀█░█▀▄░░░█▀█░░░█▀█░▀█▀░█░█░█▀█░█▀█░█░█░░
░█▀█░█░█░█▀▄░█▀█░█░█░█▀▀░█░░░█▀▀░█░█░█░█░▀▀█░░░█▀▀░█░█░█▀▄░░░█░█░▀▀█░█▀█░█▀▄░░░█░█░░░█▀▀░░█░░▄▀▄░█▀▀░█▀█░░█░░░
░▀░▀░▀▀▀░▀░▀░▀░▀░▀▀░░▀▀▀░▀▀▀░▀▀▀░▀░▀░▀▀▀░▀▀▀░░░▀░░░▀▀▀░▀░▀░░░▀▀▀░▀▀▀░▀░▀░▀░▀░░░▀▀▀░░░▀░░░▀▀▀░▀░▀░▀░░░▀░▀░░▀░░░");

Console.ResetColor();