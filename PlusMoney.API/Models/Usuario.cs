using PlusMoney.API.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlusMoney.API.Models
{
    [Table("usuario")]
    public class Usuario
    {
        public int Id { get; set; }
        [Column("Usuario")]
        public string? NomeUsuario { get; set; }
        public string? NomeCompleto { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public bool Admin { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
        public void GerarCriptografia()
        {
            Senha = Senha!.CriptografarSenha();
        }
    }

}
