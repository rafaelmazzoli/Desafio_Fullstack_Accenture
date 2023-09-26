using System.ComponentModel.DataAnnotations;

namespace Desafio_Fullstack_Accenture.Models
{
    public class Empresa
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        [StringLength(14, MinimumLength = 14)]
        public required string Cnpj { get; set; }

        [Required]
        [StringLength(55)]
        public required string Nome_Fantasia { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 8)]
        public required string Cep { get; set; }

        public IList<Fornecedor_Cpf>? Fornecedores { get; private set; }

        // Set Id apartado para não influenciar no Swagger. Para funcionar o set padrão precisa ser "private". Por isso existe esse apartado.
        public void SetId(int id) {  Id = id; }
    }
}
