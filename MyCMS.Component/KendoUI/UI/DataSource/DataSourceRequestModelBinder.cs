﻿using System;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.Infrastructure;
using System.Text.RegularExpressions;

namespace Kendo.Mvc.UI
{
    public class DataSourceRequestModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            DataSourceRequest request = new DataSourceRequest();

            string sort, group, filter, aggregates;
            int currentPage;
            int pageSize;

            if (TryGetValue(bindingContext, GridUrlParameters.Sort, out sort))
            {
                request.Sorts = GridDescriptorSerializer.Deserialize<SortDescriptor>(sort);
            }

            if (TryGetValue(bindingContext, GridUrlParameters.Page, out currentPage))
            {
                request.Page = currentPage;
            }

            if (TryGetValue(bindingContext, GridUrlParameters.PageSize, out pageSize))
            {
                request.PageSize = pageSize;
            }

            if (TryGetValue(bindingContext, GridUrlParameters.Filter, out filter))
            {
                request.Filters = FilterDescriptorFactory.Create(filter);
            }

            if (TryGetValue(bindingContext, GridUrlParameters.Group, out group))
            {
                request.Groups = GridDescriptorSerializer.Deserialize<GroupDescriptor>(group);
            }

            if (TryGetValue(bindingContext, GridUrlParameters.Aggregates, out aggregates))
            {
                request.Aggregates = GridDescriptorSerializer.Deserialize<AggregateDescriptor>(aggregates);
            }

            return request;
        }

        public string Prefix { get; set; }

        private bool TryGetValue<T>(ModelBindingContext bindingContext, string key, out T result)
        {
            if (Prefix.HasValue())
            {
                key = Prefix + "-" + key;
            }

            var value = bindingContext.ValueProvider.GetValue(key);

            if (value == null)
            {
                result = default(T);

                return false;
            }

            result = (T)value.ConvertTo(typeof(T));
            if (key == "filter" && result.ToString().Contains("datetime"))
            {
                var t = ConvertDateTimeFilter<T>(result, value);

                result = (T)(object)t;

            }
            return true;
        }

        // add by ghorbani for handel exeption .
        public static string ConvertDateTimeFilter<T>(T result, ValueProviderResult value)
        {


            //string temp = result.ToString().Split('\'')[1];

            //string date = temp.ToString().Split('T')[0];
            //string time = temp.ToString().Split('T')[1];

            //int year = int.Parse(date.Split('-')[0]);
            //int month = int.Parse(date.Split('-')[1]);
            //int day = int.Parse(date.Split('-')[2]);

            //int h = int.Parse(time.Split('-')[0]);
            //int m = int.Parse(time.Split('-')[1]);
            //int s = int.Parse(time.Split('-')[2]);

            //var t = new System.Globalization.PersianCalendar().ToDateTime(year, month, day, h, m, s, 0);
            //return value.AttemptedValue.Replace(temp, t.ToString("yyyy-MM-ddTHH-mm-ss"));






            var pdate = Regex.Matches(result.ToString(), "[0-2][0-9]{3,3}-[0|1]{0,1}[0-9]-[0-3][0-9]");
            var ptime = Regex.Matches(result.ToString(), "[0-2][0-9]-[0-6][0-9]-[0-6][0-9]");
            string res = value.AttemptedValue;
            for (int i = 0; i < pdate.Count; i++)
            {
              
                string date = pdate[i].Value;
                string time = ptime[i].Value;

                int year = int.Parse(date.Split('-')[0]);
                int month = int.Parse(date.Split('-')[1]);
                int day = int.Parse(date.Split('-')[2]);

                int h = int.Parse(time.Split('-')[0]);
                int m = int.Parse(time.Split('-')[1]);
                int s = int.Parse(time.Split('-')[2]);

                var t = new System.Globalization.PersianCalendar().ToDateTime(year, month, day, h, m, s, 0);
              res=  res.Replace(date + "T" + time, t.ToString("yyyy-MM-ddTHH-mm-ss"));
                
            }

            return res;
  





        }
    }
}
