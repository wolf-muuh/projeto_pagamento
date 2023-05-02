namespace projeto_pagamento
{
    public abstract class Cartao
    {
        public string Bandeira;
        public string NumeroCartao;
        public string Titular;
        public string Cvv;

        public abstract void Pagar(float compra);
                    
        

        public abstract void Salvar(); 
    }
}