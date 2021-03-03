using Microsoft.AspNetCore.Mvc;
using Rev.Models;
using Rev.Models.ViewModels;
using Rev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Rev.Services.Exceptions;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Rev.Controllers
{
    public class RegistrosController : Controller
    {
        private readonly RegistroServico _registroServico;
        private readonly TipoServico _tipoServico;
        private readonly DepartmentService _departmentService;

        public RegistrosController(RegistroServico registroServico, DepartmentService departmentService, TipoServico tipoServico)
        {
            _registroServico = registroServico;
            _tipoServico = tipoServico;
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var list = _registroServico.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
           
            var tipos = _tipoServico.FindAll();
            var viewModel = new RegistroViewModel { Departments = departments, Tipos = tipos };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Registro registro)
        {
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var tipos = _tipoServico.FindAll();
                var viewModel = new RegistroViewModel { Registro = registro, Departments = departments, Tipos = tipos };
                return View(viewModel);
            }
            _registroServico.Adicionar(registro);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = _registroServico.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try { 
            _registroServico.Remover(id);
            return RedirectToAction(nameof(Index));
            }
            catch(IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = _registroServico.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = _registroServico.FindById(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            List<Department> departments = _departmentService.FindAll();
            List<Tipo> tipos = _tipoServico.FindAll();

            RegistroViewModel viewModel = new RegistroViewModel { Registro = obj, Departments = departments, Tipos = tipos };
           
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Registro registro)
        {
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var tipos = _tipoServico.FindAll();
                var viewModel = new RegistroViewModel { Registro = registro, Departments = departments, Tipos = tipos };
                return View(viewModel);
            }
            if (id!=registro.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Registro não corresponde" });
            }
            try { 
            _registroServico.Atualizar(registro);
            return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
           
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }

    }
}
