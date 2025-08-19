using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppData.Contexts;
using AppData.Models;

namespace AppView.Pages.Nhanvien
{
    public class IndexModel : PageModel
    {
        private readonly AppData.Contexts.MyDbContext _context;

        public IndexModel(AppData.Contexts.MyDbContext context)
        {
            _context = context;
        }

        public IList<NhanVien> NhanVien { get;set; } = default!;

        public async Task OnGetAsync()
        {
            NhanVien = await _context.NhanViens.ToListAsync();
        }
    }
}
