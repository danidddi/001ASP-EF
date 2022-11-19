using ASPwithEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPwithEF.Pages
{
    [IgnoreAntiforgeryToken]
    public class EditModalModel : PageModel
    {
        private ApplicationContext _context;
        [BindProperty] public Edition _edition { get; set; }

        public EditModalModel(ApplicationContext db) => _context = db;

        public void OnPost(int id) => _edition = _context.Editions.Find(id);

        public async Task<IActionResult> OnPostEditeAsync()
        {
            _context.Editions.Update(_edition);
            await _context.SaveChangesAsync();
            return RedirectToPage("EditionsTable");
        }
    }
}
