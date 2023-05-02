namespace projeto_pagamento
{
    public class Pagamento
    {
        private DateTime Data = DateTime.Now;
        public float Valor { get; set; }

        public string Cancelar()
        {
            return "Pagamento cancelado com sucesso";
        }
    }
}