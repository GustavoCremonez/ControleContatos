using System.ComponentModel.DataAnnotations;

namespace controleContatos.Models
{
    public class ContatoModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o email do contato")]
        [EmailAddress(ErrorMessage = "Digite um email valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o Celular do contato")]
        [Phone(ErrorMessage = "Digite um celular valido")]
        public string Celular { get; set; }
    }
}
