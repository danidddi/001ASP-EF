using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using ASPwithEF.Models;

namespace ASPwithEF.Pages
{
    public class QuerysModel : PageModel
    {
        private ApplicationContext _context;
        public List<Query4>? Query4 { get; set; }
        public List<Query5>? Query5 { get; set; }
        

        public QuerysModel(ApplicationContext context)
        {
            _context = context;
        }

        public void OnGetQuery4()
        {
            Query4 = _context.Editions
                .AsNoTracking()
                .GroupBy(x => x.Type,(key,group) => 
                    new Query4(key,(int)group.Average(x => x.Cost), group.Count()))
                .ToList();
        }        
        
        public void OnGetQuery5()
        {
            Query5 = _context.Editions
                .AsNoTracking()
                .GroupBy(x => x.Type,(key,group) => 
                    new Query5(key,group.Min(x => x.Cost), group.Max(x => x.Cost), group.Count()))
                .ToList();
        }
    }
}

public record Query4 (string type, int avg, int amnt);
public record Query5 (string type, int min, int max, int amnt);