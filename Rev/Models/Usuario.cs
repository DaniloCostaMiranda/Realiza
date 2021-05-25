using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Rev.Services.Lang;

namespace Rev.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName="MSG_E001")]
        [Required(ErrorMessage = "{0} é requerido")]
        public string Nome { get; set; }

       
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "{0} não é um formato de email")]
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
