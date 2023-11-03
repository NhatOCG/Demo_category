using CategoryCRUD_31.Models;
using CategoryCRUD_31.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CategoryCRUD_31.Pages.CategoryCRUD
{
    public class ListModel : PageModel
    {
        private readonly ApplicationBdContext _context;
        public List<CategoryCRUD_31.Models.Domain.Category> Categories { get; set; }

        [BindProperty]
        public AddCategoryViewModel AddCategoryViewModel { get; set; }

		public ListModel(ApplicationBdContext context)
        {
            _context = context;
        }


		public const int Item_Page = 3;


        [BindProperty(SupportsGet = true,Name ="p")]
		public int currentPage { set; get; }

		public int countPage { set; get; }
		public async Task OnGetAsync(string SearchCategoryname)
        {
            int totalCategory = await _context.categorys.CountAsync();

			countPage = (int)Math.Ceiling((double)totalCategory / Item_Page);

            if(currentPage < 1)
            {
                currentPage = 1;
            }
            if(currentPage > countPage)
            {
                currentPage = countPage;
            }

            var qr = (from a in _context.categorys
                     orderby a.CategoryName descending
                     select a)
                     .Skip((currentPage - 1) * Item_Page)
                     .Take(Item_Page);
            if (!string.IsNullOrEmpty(SearchCategoryname))
            {
                Categories = qr.Where(a => a.CategoryName.Contains(SearchCategoryname)).ToList();
            }
            else
            {
                Categories = await qr.ToListAsync();
			}

        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            if (AddCategoryViewModel != null)
            {
                var existingCategory = await _context.categorys.FindAsync(AddCategoryViewModel.CategoryMasterId);
                if (existingCategory != null)
                {
                    _context.categorys.Remove(existingCategory);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToPage("./List");
        }
    }
}
