using Rev.Data;
using Rev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rev.Services
{
    public class TipoServico
    {
        private readonly RevContext _context;

        public TipoServico(RevContext context)
        {
            _context = context;
        }
        public List<Tipo> FindAll()
        {
            return _context.Tipo.OrderBy(x=>x.Nome).ToList();
        }
        public void Adicionar(Tipo obj)
        {
            
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Tipo FindById(int id)
        {
            return _context.Tipo.FirstOrDefault(obj => obj.Id == id);
        }
        public void Remover(int id)
        {
            var obj = _context.Tipo.Find(id);
            _context.Tipo.Remove(obj);
            _context.SaveChanges();
        }
    }
}
