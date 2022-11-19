using ASPwithEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASPwithEF.Pages
{
    [IgnoreAntiforgeryToken]
    public class SubscriptionsModel : PageModel
    {
        //�������� ���� ������
        private ApplicationContext _context;
        //��������� ��� ����������� �������
        public List<Edition> DisplayedSubscription { get; set; }
        //������ ��� ���������� ����� �������� �� �������� �������
        [BindProperty] public Edition CurrentSubscription { get; set; }



        //��������� ������������ � ������������
        public SubscriptionsModel(ApplicationContext db) => _context = db;




        //������ �� ��������� ���� ������� �� ���� ������
        public void OnGet() => DisplayedSubscription = _context.Editions.AsNoTracking().ToList();

        //���������� ����� ������
        public async Task<IActionResult> OnPostAddAsync()
        {
            _context.Editions.Add(CurrentSubscription);
            await _context.SaveChangesAsync();

            return RedirectToPage("EditionsTable");
        }

        //�������� ������
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            //������� �� ��������� ������ � ��
            var edition = await _context.Editions.FindAsync(id);

            //���� �����, ������� ������ � ��������� ��������� �� ��
            if (edition != null)
            {
                _context.Editions.Remove(edition);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("EditionsTable");
        }

        //���������� �� ��������
        public void OnGetByName() => DisplayedSubscription = _context.Editions.AsNoTracking().OrderBy(x => x.Name).ToList();
        //���������� �� ���������
        public void OnGetByCost() => DisplayedSubscription = _context.Editions.AsNoTracking().OrderBy(x => x.Cost).ToList();
        //����� �� �������
        public void OnPostFindByIndex(string searchIndex) 
            => DisplayedSubscription = _context.Editions.AsNoTracking().Where(x => x.Index.Equals(searchIndex)).ToList();        
        //����� �� ���������
        public void OnPostFindByCost(int min, int max) 
            => DisplayedSubscription = _context.Editions.AsNoTracking().Where(x => x.Cost >= min && x.Cost <= max).ToList();
        //����� �� ������������ ��������
        public void OnPostFindByDuration(int min, int max) 
            => DisplayedSubscription = _context.Editions.AsNoTracking().Where(x => x.Duration >= min && x.Duration <= max).ToList();

    }
}

