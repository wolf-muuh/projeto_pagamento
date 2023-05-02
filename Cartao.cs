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

        public abstract void Pagar();
                    
        

        public abstract void Salvar(); 
    }
}