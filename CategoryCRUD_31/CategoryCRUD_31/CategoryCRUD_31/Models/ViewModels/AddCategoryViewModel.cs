using CategoryCRUD_31.Binders;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CategoryCRUD_31.Models.ViewModels
{
	public class AddCategoryViewModel
	{

		public int CategoryMasterId { get; set; }


		[StringLength(50)]
		[Required(ErrorMessage = "入力してください。")]
		[ModelBinder(BinderType = typeof(CategoryNameBinding))]
		public string CategoryName { get; set; }
	}
}
