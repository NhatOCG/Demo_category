using CategoryCRUD_31.Models.ViewModels;
using CategoryCRUD_31.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CategoryCRUD_31.Pages.CategoryCRUD
{
	public class EditModel : PageModel
	{
		private readonly ApplicationBdContext _context;

		[BindProperty]
		public AddCategoryViewModel AddCategoryViewModel { get; set; }

		public EditModel(ApplicationBdContext context)
		{
			_context = context;
		}
		public IActionResult OnGet(int CategoryMasterId)
		{
			var category = _context.categorys.Find(CategoryMasterId);

			if (category != null)

			{
				AddCategoryViewModel = new AddCategoryViewModel()
				{
					CategoryMasterId = category.CategoryMasterId,
					CategoryName = category.CategoryName
				};

			}
			else
			{
				return Content("khong co category nao");
			}
			return Page();
		}
		public IActionResult OnPostEdit()
		{
			if (AddCategoryViewModel != null)
			{
				var existingcategory = _context.categorys.Find(AddCategoryViewModel.CategoryMasterId);

				if (existingcategory != null)
				{
					{
						existingcategory.CategoryMasterId = AddCategoryViewModel.CategoryMasterId;
						existingcategory.CategoryName = AddCategoryViewModel.CategoryName;
						_context.SaveChanges();

                        return RedirectToPage("/CategoryCRUD/EditSuccess");

                    }

				}

			}
			return Page();
;		}
	}
}
