using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Rev.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é requerido")]
        [Display(Name = "Empresa")]
        public string Nome { get; set; }
        public ICollection<Registro> Registros { get; set; } = new List<Registro>();

        public Department()
        {

        }

        public Department(string nome)
        {
            Nome = nome;
        }

        public void AddRegistro(Registro gr)
        {
            Registros.Add(gr);
        }

        public void RemoveRegistro(Registro gr)
        {
            Registros.Remove(gr);
        }
        public double TotalRegistros(DateTime initial, DateTime final)
        {
            return Registros.Where(gr => gr.Data >= initial && gr.Data <= final).Sum(gr => gr.Valor);
        }

    }
}
