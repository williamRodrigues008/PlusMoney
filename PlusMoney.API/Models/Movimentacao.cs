using System.ComponentModel.DataAnnotations;

namespace PlusMoney.API.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="preencha o campo Descrição")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Defina o tipo como Entrada ou saída")]
        public string TipoMovimentacao { get; set; } = string.Empty;

        [Required(ErrorMessage = "preencha o campo Valor")]
        public decimal Valor { get; set; }


        public Movimentacao()
        {

        }
    }
}
