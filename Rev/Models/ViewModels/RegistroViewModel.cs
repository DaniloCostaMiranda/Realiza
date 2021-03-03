using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rev.Models.ViewModels
{
    public class RegistroViewModel
    {
        public Registro Registro { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<Tipo> Tipos { get; set; }
    }
}
