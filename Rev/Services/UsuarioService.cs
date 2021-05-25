using Rev.Data;
using Rev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rev.Services
{
    public class UsuarioService
    {
        private readonly RevContext _context;
        

        public UsuarioService(RevContext context)
        {
            _context = context;
        }

        public List<Usuario> FindAll()
        {
          return _context.Usuario.OrderBy(x => x.Nome).ToList();
        }

        public void Adicionar(Usuario obj)
        {
           _context.Add(obj);
           _context.SaveChanges();
        }
    }
}
