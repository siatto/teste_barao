using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Domain.Models
{
    [Table("Localidade")]
    public class LocalidadeModel : BaseEntity
    {
        private string _cidade;
        private string _estado;
        private string _logradouro;
        private string _cep;

        [Required]
        public string Cidade
        {
            get { return _cidade; }
            set { _cidade = value.ToUpper(); }
        }
        [Required]
        public string Estado
        {
            get { return _estado; }
            set { _estado = value.ToUpper(); }
        }
        [Required]
        public string Logradouro
        {
            get { return _logradouro; }
            set { _logradouro = value.ToUpper(); }
        }
        [Required]
        public string Cep
        {
            get { return _cep; }
            set { _cep = value.ToUpper(); }
        }
    }
}
