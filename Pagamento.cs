namespace projeto_pagamento
{
    public class Pagamento
    {
        public DateTime Data { get; private set; } = DateTime.Now.Date.Hour < 22 ? DateTime.Now.Date.AddDays(6) : DateTime.Now.Date.AddDays(7);
        public float Valor { get; set; }

        public string Cancelar()
        {
            // Zera valor das propriedades
            this.Data = new DateTime();
            this.Valor = 0;
            return @"
            ***********************************
            * Pagamento cancelado com sucesso * 
            ***********************************
            ";
        }
    }
}