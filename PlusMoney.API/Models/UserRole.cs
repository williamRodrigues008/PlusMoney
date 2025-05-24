using System.ComponentModel.DataAnnotations.Schema;

namespace PlusMoney.API.Models
{
    [Table("UserRoles")]
    public class UserRole
    {
        [Column("UserId")]
        public int UsuarioId { get; set; }

        [NotMapped]
        public Usuario Usuario { get; set; }

        [Column("RoleId")]
        public int RoleId { get; set; }

        [NotMapped]
        public Role Role { get; set; }
    }
}
