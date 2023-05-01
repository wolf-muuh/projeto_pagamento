using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_pagamento
{
    public abstract class Cartao
    {
        string Bandeira;
        string NumeroCartao;
        string Titular;
        string Cvv;

        public void Pagar()
        {
            Console.WriteLine($"Text");
        }

        public void SalvarCartao()
        {
            Console.WriteLine($"Text");            
        }
    }
}