using System.ComponentModel.DataAnnotations;

namespace Desafio_Fullstack_Accenture.Models
{
    public class Fornecedor_Cpf : IFornecedor
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        [StringLength(64)]
        public required string Nome { get; set; }

        [Required]
        [StringLength(256)]
        [RegularExpression(".+\\@.+\\..+")]
        public required string Email { get; set; }

        [Required]
        [StringLength(14, MinimumLength = 11)]
        public required string Cnpj_Cpf { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 8)]
        public required string Cep { get; set; }

        [StringLength(32)]
        public string? Rg { get; set; }

        [DisplayFormat(DataFormatString = "yyyy-mm-dd")]
        public DateTime? Data_Nascimento { get; set; }

        public IList<Empresa>? Empresas { get; private set; }

        // Set Id apartado para não influenciar no Swagger. Para funcionar o set padrão precisa ser "private". Por isso existe esse apartado.
        public void SetId(int id) { Id = id; }
    }
}
