using System.ComponentModel.DataAnnotations;

namespace Desafio_Fullstack_Accenture.Models
{
    public class Empresa_Fornecedor
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        public required string Id_Empresa { get; set; }

        [Required]
        public required string Id_Fornecedor { get; set; }

        // Set Id apartado para não influenciar no Swagger. Para funcionar o set padrão precisa ser "private". Por isso existe esse apartado.
        public void SetId(int id) {  Id = id; }
    }
}
