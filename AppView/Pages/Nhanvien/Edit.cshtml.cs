using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppData.Contexts;
using AppData.Models;

namespace AppView.Pages.Nhanvien
{
    public class EditModel : PageModel
    {
        private readonly AppData.Contexts.MyDbContext _context;

        public EditModel(AppData.Contexts.MyDbContext context)
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

            var nhanvien =  await _context.NhanViens.FirstOrDefaultAsync(m => m.ID == id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            NhanVien = nhanvien;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(NhanVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhanVienExists(NhanVien.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NhanVienExists(Guid id)
        {
            return _context.NhanViens.Any(e => e.ID == id);
        }
    }
}
