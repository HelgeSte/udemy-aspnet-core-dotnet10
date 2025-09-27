using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using ModelValidationsExample.Models;

namespace ModelValidationsExample.CustomModelBinders;

// by using this, you can hide [ModelBinder(BinderType...))] from the IActionResult method:
// public IActionResult Index([ModelBinder(typeof(PersonModelBinder))]Person person)
public class PersonBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        if (context.Metadata.ModelType == typeof(Person))
        {
            return new BinderTypeModelBinder(typeof(PersonModelBinder));
        }

        return null; // else, use the default model binding
    }
}