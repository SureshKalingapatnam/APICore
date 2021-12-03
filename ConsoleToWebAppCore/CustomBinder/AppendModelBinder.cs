using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleToWebAppCore.CustomBinder
{
    public class AppendModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var data = bindingContext.HttpContext.Request.Query;

            var input = data.TryGetValue("InputVal", out var result);
            if (input)
            {
                result = "Hello " + result.ToString() + " Bye!!!!";
                bindingContext.Result = ModelBindingResult.Success(result.ToString());
            }

            return Task.CompletedTask;
        }
    }
}
