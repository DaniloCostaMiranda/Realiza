using Rev.Data;
using Rev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rev.Services
{
    public class FonteService
    {
        private readonly RevContext _context;

        public FonteService(RevContext context)
        {
            _context = context;
        }

        public List<Fonte> FindAll()
        {
            return _context.Fonte.OrderBy(x => x.Nome).ToList();
        }
    }
}
