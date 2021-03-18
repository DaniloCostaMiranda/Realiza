using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rev.Models
{
    public class Fonte
    {
        public int Id { get; set; }
        [Display (Name = "Parceiro" )]
        public string Nome { get; set; }

        public Fonte()
        {

        }

        public Fonte(string nome)
        {
           Nome = nome;
        }
    }
}
