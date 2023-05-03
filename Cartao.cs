namespace projeto_pagamento
{
    public abstract class Cartao
    {
        public string Bandeira {get; set;}
        public string NumeroCartao {get; set;}
        public string Titular {get; set;}
        public string Cvv {get; set;}

        public abstract void Pagar(float compra);
                    
        public abstract void Salvar(); 
    }
}