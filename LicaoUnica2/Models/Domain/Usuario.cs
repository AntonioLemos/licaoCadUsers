using LiçãoUnica2.Models.Context;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LicaoUnica2.Models.Domain
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NomeUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Cpf { get; set; }

        [Required]
        [StringLength(20)]
        public string User { get; set; }

        [Required]
        [StringLength(20)]
        public string Senha { get; set; }
    }


}

