using System.Collections.Generic;

namespace Rev.Models
{
    public class Fonte
    {
        public int Id { get; set; }
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
