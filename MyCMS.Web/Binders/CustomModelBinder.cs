using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCMS.Web.Binders
{
    public class CustomModelBinder : DefaultModelBinder
    {
        protected override void SetProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor, object value)
        {
            if (value is List<SelectListItem>)
            {
                List<SelectListItem> tmp = ((List<SelectListItem>)value);

                List<SelectListItem> result = new List<SelectListItem>();

                for (int i = 0; i < tmp.Count; i++)
                {

                    string k = ((System.ComponentModel.MemberDescriptor)(propertyDescriptor)).Name;

                    var key = bindingContext.ValueProvider.GetValue(k + "[" + i + "]");
                    if (key != null)
                    {
                        result.Add(new SelectListItem() { Text = key.AttemptedValue, Value = key.AttemptedValue });
                    }
                    else
                    {


                        var text = bindingContext.ValueProvider.GetValue(k + "[" + i + "][Text]").AttemptedValue;

                        var val = bindingContext.ValueProvider.GetValue(k + "[" + i + "][Value]").AttemptedValue;

                        result.Add(new SelectListItem() { Text = text, Value = val });
                    }
                }

                value = result;
            }
            //if (value is List<EventConditionViewModel>)
            //{
            //    value = NewMethod<EventConditionViewModel>(bindingContext, propertyDescriptor, value);
            //}
            base.SetProperty(controllerContext, bindingContext, propertyDescriptor, value);
        }

        private static List<T> NewMethod<T>(ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor, object value)
        {
            List<T> result = new List<T>();

            if (value is List<T>)
            {
                List<T> tmp = ((List<T>)value);

                for (int i = 0; i < tmp.Count; i++)
                {
                    string k = ((System.ComponentModel.MemberDescriptor)(propertyDescriptor)).Name;
                    var ecvm = Activator.CreateInstance<T>();
                    foreach (var j in typeof(T).GetProperties())
                    {
                        if (bindingContext.ValueProvider.GetValue(k + "[" + i + "][" + j.Name + "]") != null)
                        {
                            var pvalue = bindingContext.ValueProvider.GetValue(k + "[" + i + "][" + j.Name + "]").AttemptedValue;

                            ecvm.GetType()
                                .GetProperty(j.Name)
                                .SetValue(ecvm, Convert.ChangeType(pvalue, j.PropertyType));
                        }
                        else if (bindingContext.ValueProvider.GetValue(k + "[" + i + "]." + j.Name) != null)
                        {
                            var pvalue = bindingContext.ValueProvider.GetValue(k + "[" + i + "]." + j.Name).AttemptedValue;

                            ecvm.GetType()
                                .GetProperty(j.Name)
                                .SetValue(ecvm, Convert.ChangeType(pvalue, j.PropertyType));
                        }
                    }
                    result.Add(ecvm);
                }
            }
            return result;
        }

        //public Dictionary<string, ProductPropertyViewModel> data { get; set; }



        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {

            try
            {
                //bool isValidateRequest = bindingContext.ModelName.ToLower() == "templatevalue";
                bool isValidateRequest = controllerContext.Controller.ValidateRequest && bindingContext.ModelMetadata.RequestValidationEnabled;

                //var value = isValidateRequest == false ? bindingContext.ValueProvider.GetValue(bindingContext.ModelName) : GetValueFromValueProvider(bindingContext, true);
                var value = isValidateRequest == true ? bindingContext.ValueProvider.GetValue(bindingContext.ModelName) : GetValueFromValueProvider(bindingContext, false);

                if (value != null)
                {
                    var r = value.AttemptedValue.GetEnglishCalendar();

                    if (r is DateTime)
                    {
                        return (DateTime)r;
                    }
                    else if ((bindingContext.ModelName.ToLower() == "templatecontent") || (bindingContext.ModelName.ToLower() == "templatevalue"))
                    {
                        var shouldPerformRequestValidation = controllerContext.Controller.ValidateRequest && bindingContext.ModelMetadata.RequestValidationEnabled;

                        var valueProviderResult = GetValueFromValueProvider(bindingContext, shouldPerformRequestValidation);

                        if (valueProviderResult != null)
                        {
                            var theValue = valueProviderResult.AttemptedValue;
                            return theValue;
                            // etc...
                        }
                    }
                    else
                    {
                        //return value;
                        return base.BindModel(controllerContext, bindingContext);
                    }

                }
            }
            catch (HttpRequestValidationException ex)
            {
                return base.BindModel(controllerContext, bindingContext);
            }
            return base.BindModel(controllerContext, bindingContext);
        }

        ValueProviderResult GetValueFromValueProvider(ModelBindingContext bindingContext, bool performRequestValidation)
        {
            var unvalidatedValueProvider = bindingContext.ValueProvider as IUnvalidatedValueProvider;
            return (unvalidatedValueProvider != null)
                       ? unvalidatedValueProvider.GetValue(bindingContext.ModelName, !performRequestValidation)
                       : bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        }

    }
}