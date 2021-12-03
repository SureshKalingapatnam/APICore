using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleToWebAppCore.CustomBinder
{
    public class CustomeBinderModel : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var data = bindingContext.HttpContext.Request.Query;

            var result = data.TryGetValue("countries", out var country);
            if(result)
            {
                var array = country.ToString().Split('|');
                bindingContext.Result = ModelBindingResult.Success(array);
            }
            return Task.CompletedTask;           
        }
    }
}
