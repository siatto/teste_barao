using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Domain.Models
{
    [Table("Usuario")]
    public class UsuarioModel : BaseEntity
    {
        private string _login;

        [Required]
        public string Login
        {
            get { return _login; }
            set { _login = value.ToUpper(); }
        }

        public required string Senha { get; set; }
    }
}