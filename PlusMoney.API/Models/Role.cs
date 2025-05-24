using System.ComponentModel.DataAnnotations.Schema;

namespace PlusMoney.API.Models
{
    [Table("Roles")]
    public class Role
    {
        [Column("id_role")]
        public int Id { get; set; }

        [Column("Role")]
        public string Name { get; set; }
    }
}
