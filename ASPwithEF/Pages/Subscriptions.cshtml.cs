using ASPwithEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASPwithEF.Pages
{
    [IgnoreAntiforgeryToken]
    public class SubscriptionsModel : PageModel
    {
        //контекст базы данных
        private ApplicationContext _context;
        //коллекция для отображения записей
        public List<Edition> DisplayedSubscription { get; set; }
        //объект для добавления новой подписки на печатное издание
        [BindProperty] public Edition CurrentSubscription { get; set; }



        //внедрение зависимостей в конструкторе
        public SubscriptionsModel(ApplicationContext db) => _context = db;




        //запрос на получение всех записей из базы данных
        public void OnGet() => DisplayedSubscription = _context.Editions.AsNoTracking().ToList();

        //добавление новой записи
        public async Task<IActionResult> OnPostAddAsync()
        {
            _context.Editions.Add(CurrentSubscription);
            await _context.SaveChangesAsync();

            return RedirectToPage("EditionsTable");
        }

        //удаление записи
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            //находим по айдишнику запись в бд
            var edition = await _context.Editions.FindAsync(id);

            //если нашли, удаляем запись и сохраняем изменения на бд
            if (edition != null)
            {
                _context.Editions.Remove(edition);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("EditionsTable");
        }

        //сортировка по названию
        public void OnGetByName() => DisplayedSubscription = _context.Editions.AsNoTracking().OrderBy(x => x.Name).ToList();
        //сортировка по стоимости
        public void OnGetByCost() => DisplayedSubscription = _context.Editions.AsNoTracking().OrderBy(x => x.Cost).ToList();
        //поиск по индексу
        public void OnPostFindByIndex(string searchIndex) 
            => DisplayedSubscription = _context.Editions.AsNoTracking().Where(x => x.Index.Equals(searchIndex)).ToList();        
        //поиск по стоимости
        public void OnPostFindByCost(int min, int max) 
            => DisplayedSubscription = _context.Editions.AsNoTracking().Where(x => x.Cost >= min && x.Cost <= max).ToList();
        //поиск по длительности подписки
        public void OnPostFindByDuration(int min, int max) 
            => DisplayedSubscription = _context.Editions.AsNoTracking().Where(x => x.Duration >= min && x.Duration <= max).ToList();

    }
}

