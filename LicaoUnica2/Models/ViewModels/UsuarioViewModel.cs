using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LicaoUnica2.Models.ViewModels
{
    public class UsuarioViewModel
    {

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [DisplayName("Nome")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório.")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###-##-####}")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O Usuário é obrigatório.")]
        [Display(Name = "Usuário")]
        public string User { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "A senha é obrigatória.")]
       // [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmar Senha")]
        [Required(ErrorMessage = "A confirmação da senha é obrigatório.")]
       // [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As Senhas Não Correspodem.")]
        public string ConfirmPassword { get; set; }

        public bool statusConfir { get; set; }
        public bool statusError { get; set; }
    }

}
