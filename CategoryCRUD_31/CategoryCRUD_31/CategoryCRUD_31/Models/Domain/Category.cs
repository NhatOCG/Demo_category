using CategoryCRUD_31.Binders;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CategoryCRUD_31.Models.Domain
{
	public class Category
	{
		[Key]
		public int CategoryMasterId { get; set; }

		[StringLength(50)]
		[Required(ErrorMessage = "入力してください。")]
		[ModelBinder(BinderType = typeof(CategoryNameBinding))]
		public string CategoryName { get; set; }
	}
}
