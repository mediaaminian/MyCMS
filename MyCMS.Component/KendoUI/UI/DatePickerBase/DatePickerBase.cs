namespace Kendo.Mvc.UI
{
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.Infrastructure;

    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Globalization;
    using System.Threading;

    public class DatePickerBase : WidgetBase, IPicker
    {
        public DatePickerBase(ViewContext viewContext, IJavaScriptInitializer initializer, ViewDataDictionary viewData)
            : base(viewContext, initializer, viewData)
        {
            ParseFormats = new List<string>();

            Animation = new PopupAnimation();

            Dates = new List<DateTime>();

            Value = null;
            Enabled = true;
        }

        public PopupAnimation Animation
        {
            get;
            private set;
        }

        public string Culture
        {
            get;
            set;
        }

        public CultureInfo CultureInfo
        {
            get
            {
                CultureInfo info = null;
                if (Culture.HasValue())
                {
                    info = new CultureInfo(Culture);
                }
                else
                {
                    info = Thread.CurrentThread.CurrentCulture;
                }

                return info;
            }
        }

        public IList<DateTime> Dates
        {
            get;
            set;
        }

        public string Format
        {
            get;
            set;
        }

        public List<string> ParseFormats
        {
            get;
            set;
        }
        private DateTime? _value;
        public DateTime? Value
        {
            get
            {
                if (_value != null)
                    return Convert.ToDateTime(_value.Value.GetPersianCalendar());
                else
                    return DateTime.Now;
            }
            set
            {
                if(value.HasValue)
                _value = value.Value.ToString().GetEnglishCalendar();
                
            }
        }

        public DateTime Min
        {
            get;
            set;
        }

        public DateTime Max
        {
            get;
            set;
        }

        public bool Enabled
        {
            get;
            set;
        }
    }
}