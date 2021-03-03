using Microsoft.AspNetCore.Mvc;
using Rev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rev.Controllers
{
    public class RegistroRecordsController : Controller
    {
        private readonly RegistroRecordService _registroRecordService;

        public RegistroRecordsController(RegistroRecordService registroRecordService)
        {
            _registroRecordService = registroRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _registroRecordService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }
        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}
