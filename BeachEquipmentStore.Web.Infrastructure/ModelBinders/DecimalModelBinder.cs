﻿namespace BeachEquipmentStore.Infrastructure.ModelBinders
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System.Globalization;
    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            ValueProviderResult valueResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);

            if (valueResult != ValueProviderResult.None && !string.IsNullOrEmpty(valueResult.FirstValue))
            {
                decimal parsedValue = 0m;
                bool binderSucceeded = false;

                try
                {
                    string formDecValue = valueResult.FirstValue;
                    formDecValue = formDecValue.Replace(",",
                        CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    formDecValue = formDecValue.Replace(".",
                        CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                    parsedValue = Convert.ToDecimal(formDecValue);
                    binderSucceeded = true;
                }
                catch (Exception fe)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
                }

                if (binderSucceeded)
                {
                    bindingContext.Result = ModelBindingResult.Success(parsedValue);
                }
            }
            return Task.CompletedTask;
        }
    }
}
