using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppData.Contexts;
using AppData.Models;

namespace AppView.Pages.Nhanvien
{
    public class CreateModel : PageModel
    {
        private readonly AppData.Contexts.MyDbContext _context;

        public CreateModel(AppData.Contexts.MyDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public NhanVien NhanVien { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.NhanViens.Add(NhanVien);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
