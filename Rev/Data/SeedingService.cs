using Rev.Models;
using Rev.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rev.Data
{
    public class SeedingService
    {
        private RevContext _context;
        public SeedingService(RevContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Fonte.Any() ||
                _context.Registro.Any() ||
                _context.Tipo.Any())
            {
                return; //DB has been seeded
            }

            Department d1 = new Department("Revitalize");
            Department d2 = new Department("Realiza");

            Tipo t1 = new Tipo("Imposto");
            Tipo t2 = new Tipo("Fixa");

            Fonte f1 = new Fonte("Sul America");
            Fonte f2 = new Fonte("Amil");

            Registro r1 = new Registro(2200.0, "Condominio", new DateTime(2021,1,04), t2, Operacao.Credito, d1, f2);
            Registro r2 = new Registro(1200.0, "Energia", new DateTime(2021,1,08), t2, Operacao.Credito, d1, f2);
            Registro r3 = new Registro(200.0, "ISS", new DateTime(2021,1,10), t1, Operacao.Credito, d1, f2);
            Registro r4 = new Registro(9000.0, "Faturamento", new DateTime(2021,1,15), t1, Operacao.Debito, d1, f1);

            _context.Registro.AddRange(r1, r2, r3, r4);
            _context.Tipo.AddRange(t1, t2);
            _context.Fonte.AddRange(f1, f2);
            _context.Department.AddRange(d1, d2);

            _context.SaveChanges();


        }
    }
}
