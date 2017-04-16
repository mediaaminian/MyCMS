using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MyCMS.Web.Binders
{
    public class DecimalBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(decimal) || bindingContext.ModelType == typeof(decimal?))
            {
                return bindDecimal(bindingContext);
            }
            return base.BindModel(controllerContext, bindingContext);
        }

        private static object bindDecimal(ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueProviderResult == null)
                return null;

            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);
            decimal value;
            var valueAsString = valueProviderResult.AttemptedValue?.Trim();
            if (string.IsNullOrEmpty(valueAsString))
                return null;

            if (!decimal.TryParse(valueAsString, NumberStyles.Any, Thread.CurrentThread.CurrentCulture, out value))
            {
                const string error = "عدد وارد شده معتبر نیست";
                var ex = new InvalidOperationException(error, new Exception(error, new FormatException(error)));
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex);
                return null;
            }
            return value;
        }
    }
}