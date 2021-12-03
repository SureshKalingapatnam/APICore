using ConsoleToWebAppCore.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleToWebAppCore.CustomBinder
{
    public class CustomCountryDetails : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var modelName = bindingContext.ModelName;
            var value = bindingContext.ValueProvider.GetValue(modelName);
            var result = value.FirstValue;

            if (!int.TryParse(result, out var id))
            {
                return Task.CompletedTask;
            }

            var model = new CountryModel
            {
                Id = id,
                Name = "India",
                Location = "Hyderabad",
                Area = "BHPL"
            };
            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
}
