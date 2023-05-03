using projeto_pagamento;


float ValorPago = 0;
string Opcao = "";
bool limite;

Console.WriteLine(@$"
░░░█░█░█▀█░█▀▀░█▀▀░░░█▀▀░█▀▀░▀█▀░█▀█░░░█▀█░█▀█░░░█▀█░▀█▀░█░█░█▀█░█▀█░█░█░░░░
░░░▀▄▀░█░█░█░░░█▀▀░░░█▀▀░▀▀█░░█░░█▀█░░░█░█░█░█░░░█▀▀░░█░░▄▀▄░█▀▀░█▀█░░█░░░░░
░░░░▀░░▀▀▀░▀▀▀░▀▀▀░░░▀▀▀░▀▀▀░░▀░░▀░▀░░░▀░▀░▀▀▀░░░▀░░░▀▀▀░▀░▀░▀░░░▀░▀░░▀░░░░░
");
do {
    do {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine(@$"
                *************************************
                *    Insira o valor da compra      *
                *************************************");
        Console.Write("     -> ");
        ValorPago = float.Parse(Console.ReadLine()!);
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
            Console.WriteLine($"Limite do cartao ultrapassado !!!");
        }

        else {
            creditoNovo.Pagar(ValorPago);
            
            Console.WriteLine($"");

            creditoNovo.Salvar();
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
           Console.WriteLine($"Saldo insuficiente !!!");
        }

        else {
            Console.WriteLine($"");
            
            debitoNovo.Pagar(ValorPago);

            Console.WriteLine($"");
            
            debitoNovo.Salvar();
        }
        break;

    case "4":
        Pagamento pagamentoNovo = new Pagamento();
        Console.WriteLine(pagamentoNovo.Cancelar());
        Thread.Sleep(1000);
        Opcao = "";
        Console.Clear();
        break;

    case "0":
        break;

    default:
        Console.Beep(1200, 2000);
        Console.WriteLine(@$"
             *************************************
             *        Opcao invalida             *
             *************************************");
        break;
}


} while (Opcao != "1" && Opcao != "2" && Opcao != "3" && Opcao != "4" && Opcao != "0");

Thread.Sleep(1000);

Console.Beep(1000, 500);
Console.Beep(2000, 500);
Console.Beep(3000, 500);

Thread.Sleep(1000);

Console.WriteLine(@$"
░█▀█░█▀▀░█▀▄░█▀█░█▀▄░█▀▀░█▀▀░█▀▀░█▄█░█▀█░█▀▀░░░█▀█░█▀█░█▀▄░░░█░█░█▀▀░█▀█░█▀▄░░░█▀█░░░█▀█░▀█▀░█░█░█▀█░█▀█░█░█░░
░█▀█░█░█░█▀▄░█▀█░█░█░█▀▀░█░░░█▀▀░█░█░█░█░▀▀█░░░█▀▀░█░█░█▀▄░░░█░█░▀▀█░█▀█░█▀▄░░░█░█░░░█▀▀░░█░░▄▀▄░█▀▀░█▀█░░█░░░
░▀░▀░▀▀▀░▀░▀░▀░▀░▀▀░░▀▀▀░▀▀▀░▀▀▀░▀░▀░▀▀▀░▀▀▀░░░▀░░░▀▀▀░▀░▀░░░▀▀▀░▀▀▀░▀░▀░▀░▀░░░▀▀▀░░░▀░░░▀▀▀░▀░▀░▀░░░▀░▀░░▀░░░
");


Console.ResetColor();

