using projeto_pagamento;

Credito a = new Credito();

float valor = 1000f;

bool x = a.Limitar(valor);

if (x == true) {
    Console.WriteLine($"{x}");
}

else {
    a.Parcelar(valor);
}
