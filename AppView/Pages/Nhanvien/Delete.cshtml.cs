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
    public class DeleteModel : PageModel
    {
        private readonly AppData.Contexts.MyDbContext _context;

        public DeleteModel(AppData.Contexts.MyDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public NhanVien NhanVien { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.NhanViens.FirstOrDefaultAsync(m => m.ID == id);

            if (nhanvien == null)
            {
                return NotFound();
            }
            else
            {
                NhanVien = nhanvien;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.NhanViens.FindAsync(id);
            if (nhanvien != null)
            {
                NhanVien = nhanvien;
                _context.NhanViens.Remove(NhanVien);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
