using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;

namespace CategoryCRUD_31.Binders
{
	public class CategoryNameBinding : IModelBinder

	{
		Task IModelBinder.BindModelAsync(ModelBindingContext bindingContext)
		{
			if (bindingContext == null)
				throw new ArgumentNullException(nameof(bindingContext));

			string modelName = bindingContext.ModelName;

			//doc gia trij gui den
			ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

			// Không có giá trị gửi đến (không thiết lập giá trị cho thuộc  tính)
			if (valueProviderResult == ValueProviderResult.None)
			{
				return Task.CompletedTask;
			}
			// Thiết lập cho ModelState giá trị bindinng
			bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

			string value = valueProviderResult.FirstValue;

			// Xử lý nếu chuỗi giá trị gửi đến null
			if (string.IsNullOrEmpty(value))
			{
				bindingContext.ModelState.TryAddModelError(
					modelName, "入力してください。");
					return Task.CompletedTask;
			}

			bindingContext.Result = ModelBindingResult.Success(value);
			return Task.CompletedTask;

		}
	}
}
