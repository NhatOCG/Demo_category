using CategoryCRUD_31.Models.Domain;
using CategoryCRUD_31.Models.ViewModels;
using CategoryCRUD_31.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CategoryCRUD_31.Pages.CategoryCRUD
{
    public class AddCategoryModel : PageModel
    {
        private readonly ApplicationBdContext _context;

        public AddCategoryModel(ApplicationBdContext context)
        {
            _context = context;
        }
        [BindProperty]
        public AddCategoryViewModel CategoryRequest { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostAdd()
        {
            var CategoryDomainModel = new Category
            {
                CategoryName = CategoryRequest.CategoryName,
            };
            _context.categorys.Add(CategoryDomainModel);
            _context.SaveChanges();
            return RedirectToPage("/CategoryCRUD/AddSuccess");
        }
    }
}
