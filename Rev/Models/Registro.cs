using System;
using System.Collections.Generic;
using System.Linq;
using Rev.Models.Enums;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rev.Models
{
    public class Registro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é requerido")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "{0} é requerido")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "Descreva algo")]
        public string Descrição { get; set; }

        [Required(ErrorMessage = "{0} é requerido")]
        public DateTime Data { get; set; }

    
        public Tipo Tipo { get; set; }

        [Required(ErrorMessage = "{0} é requerido")]
        [Display(Name = "Tipo de registro")]
        public int TipoId { get; set; }

        [Required(ErrorMessage = "{0} é requerido")]
        [Display(Name = "Entrada ou Saída")]
        public Operacao Operacao { get; set; }


       
        public Department Department { get; set; }

        [Required(ErrorMessage = "{0} é requerido")]
        [Display(Name = "Empresa")]
        public int DepartmentId { get; set; }
        public Fonte Fonte { get; set; }

        public Registro()
        {

        }

        public Registro(double valor, string descrição, DateTime data, Tipo tipo, Operacao operacao, Department department, Fonte fonte)
        {
           
            Valor = valor;
            Descrição = descrição;
            Data = data;
            Tipo = tipo;
            Operacao = operacao;
            Department = department;
            Fonte = fonte;
        }

            
    }

}
