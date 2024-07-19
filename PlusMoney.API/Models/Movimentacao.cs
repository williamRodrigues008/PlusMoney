namespace PlusMoney.API.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string TipoMovimentacao { get; set; } = string.Empty;
        public decimal Valor { get; set; }


        public Movimentacao()
        {

        }
    }
}
