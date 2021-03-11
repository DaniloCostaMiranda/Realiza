using Microsoft.EntityFrameworkCore;
using Rev.Data;
using Rev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rev.Services
{
    public class RegistroRecordService
    {
        private readonly RevContext _context;

        public RegistroRecordService(RevContext context)
        {
            _context = context;
        }

        public async Task<List<Registro>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Registro select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }
            return await result
                .Include(x => x.Department)
                .Include(x => x.Tipo)
                .OrderByDescending(x => x.Data)
                .ToListAsync();

        }

        public async Task<List<IGrouping<Department,Registro>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = await FindByDateAsync(minDate, maxDate);

            return result.GroupBy(x => x.Department).ToList();

        }
    }
}
