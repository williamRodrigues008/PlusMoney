using PlusMoney.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PlusMoney.API.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="preencha o campo Descrição")]
        public string Descricao { get; set; } = string.Empty;
        public string NomeUsuario { get; set; } = string.Empty;
        public DateTime DataMovimentacao { get; set; }

        [Required(ErrorMessage = "Defina o tipo como Entrada ou saída")]
        public string TipoMovimentacao { get; set; } = string.Empty;

        [JsonIgnore]
        [NotMapped]
        public TipoMovimentacaoEnum TipoMovimentacaoEnum 
        {
            get => Enum.TryParse<TipoMovimentacaoEnum>(TipoMovimentacao, out var tipo)
            ? tipo
            : TipoMovimentacaoEnum.Entrada;

            set => TipoMovimentacao = value.ToString();
        }

        [Required(ErrorMessage = "preencha o campo Valor")]
        public decimal Valor { get; set; }


        public Movimentacao()
        {

        }
    }
}
