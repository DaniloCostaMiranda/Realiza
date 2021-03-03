using Rev.Data;
using Rev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rev.Services
{
    public class DepartmentService
    {
        private readonly RevContext _context;

        public DepartmentService(RevContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x=>x.Nome).ToList();
        }
    }
}
