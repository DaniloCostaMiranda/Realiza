using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rev.Data;
using Rev.Models;
using Rev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rev.Controllers
{
    public class TiposController : Controller
    {
        private readonly TipoServico _tipoServico;
        private readonly RevContext _context;

        public TiposController(TipoServico tipoServico, RevContext context)
        {
            _tipoServico = tipoServico;
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _tipoServico.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tipo tipo)
        {
            _tipoServico.Adicionar(tipo);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _tipoServico.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _tipoServico.Remover(id);
            return RedirectToAction(nameof(Index));
        }
        
    }
}
