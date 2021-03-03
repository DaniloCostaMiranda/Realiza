using Rev.Data;
using Rev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rev.Services.Exceptions;

namespace Rev.Services
{
    public class RegistroServico
    {
        private readonly RevContext _context;

        public RegistroServico(RevContext context)
        {
            _context = context;
        }
        public List<Registro> FindAll()
        {
            return _context.Registro.Include(obj=>obj.Department).Include(obj=>obj.Tipo).ToList();
        }
        public void Adicionar(Registro obj)
        {

            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Edit(Registro obj)
        {

            _context.Update(obj);
            _context.SaveChanges();
        }
        public Registro FindById(int id)
        {
            return _context.Registro.Include(obj=>obj.Department).Include(obj=>obj.Tipo).FirstOrDefault(obj => obj.Id == id);
        }
        public void Remover(int id)
        {
            try { 
            var obj = _context.Registro.Find(id);
            _context.Registro.Remove(obj);
            _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
         }
        public void Atualizar(Registro obj)
        {
            if (!_context.Registro.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundExceptions("Id não encontrado");
            }
            try { 
            _context.Update(obj);
            _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
            }
    }
}
