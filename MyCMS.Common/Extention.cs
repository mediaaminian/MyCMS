
using System.Text.RegularExpressions;
using System.Web.Mvc.Html;
using System.Xml;
using System.Xml.Linq;
using MyCMS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using MyCMS.Utilities.DynamicLinq;
using Kendo.Mvc.Extensions;
using Newtonsoft.Json;
using Kendo.Mvc.UI;
using System.Resources;
using System.Reflection;
using System.Web;
using System.Globalization;
using Kendo.Mvc;
using System.Linq.Expressions;

using Formatting = Newtonsoft.Json.Formatting;
using System.ComponentModel;

public static class Extention
{


    public static Expression<Func<T, bool>> AndNoExtension<T>(Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
    {
        return first.Compose(second, Expression.And);
    }


    public static string GetPropertyName<t>(Expression<Func<t>> PropertyExp)
    {
        return (PropertyExp.Body as MemberExpression).Member.Name;
    }

    public static int ToInt(this Byte source)
    {
        return int.Parse(source.ToString());
    }

    public static bool IsBuiltIn(this byte item)
    {
        return (item.ToInt() != (int)BuiltInEntityState.IsArcived) && (item.ToInt() != (int)BuiltInEntityState.IsDeleted) && (item.ToInt() != (int)BuiltInEntityState.IsInTrash);
    }

    public static bool IsBuiltIn(this int item)
    {
        return (item != (int)BuiltInEntityState.IsArcived) && (item != (int)BuiltInEntityState.IsDeleted) && (item != (int)BuiltInEntityState.IsInTrash);
    }

    public static BuiltInEntityState GetBuiltIn(this string item)
    {
        string dic;
        Dictionary<int, Tuple<string, string>> r = new Dictionary<int, Tuple<string, string>>();

        if (System.Web.HttpContext.Current.Request.RequestContext.RouteData.Values["status"] != null)
        {
            DataDictionary m = new DataDictionary();
            object ut = new object();
            dic = System.Web.HttpContext.Current.Request.RequestContext.RouteData.Values["controller"] + "StatusItems";
            r = (Dictionary<int, Tuple<string, string>>)m.GetType().GetProperty(dic).GetValue(ut);

            var t = r.FirstOrDefault(q => q.Value.Item1 == item);
            if (t.Value == null)
            {
                t = DataDictionary.BuiltInDictionary.FirstOrDefault(q => q.Key.ToString() == item);
            }
            return (BuiltInEntityState)t.Key;
        }
        var yy = DataDictionary.BuiltInDictionary.FirstOrDefault(q => q.Value.Item1 == item);
        if (yy.Value == null)
        {
            yy = DataDictionary.BuiltInDictionary.FirstOrDefault(q => q.Key.ToString() == item);
        }
        return (BuiltInEntityState)yy.Key;
    }

    public static Kendo.Mvc.UI.DataSourceResult ToDataSourceResult(this System.Collections.IEnumerable enumerable, Kendo.Mvc.UI.DataSourceRequest request, int total)
    {

        return new Kendo.Mvc.UI.DataSourceResult()
        {
            Data = enumerable.AsQueryable(),
            Total = total

        };

    }

    public static KeyValuePair<int, Tuple<string, string>> GetBuiltInDic(this string item)
    {
        string dic;

        DataDictionary m = new DataDictionary();
        object ut = new object();
        dic = System.Web.HttpContext.Current.Request.RequestContext.RouteData.Values["controller"] + "StatusItems";
        var r = (Dictionary<int, Tuple<string, string>>)m.GetType().GetProperty(dic).GetValue(ut);

        var t = r.FirstOrDefault(q => q.Value.Item1 == item || q.Key.ToString() == item);
        if (t.Value == null)
        {
            t = DataDictionary.BuiltInDictionary.FirstOrDefault(q => q.Key.ToString() == item);
        }
        return t;

    }

    public static string GetResource(string key)
    {
        try
        {
            var rm = new ResourceManager("MyCMS.Utilities.Localized.LocalizedResource", Assembly.GetExecutingAssembly());
            return rm.GetString(key);
        }
        catch (Exception)
        {

            return "";
        }

    }

    public static HtmlString UploadControl(this HtmlHelper helper, string fieldname, string url)
    {
        int w = 150, h = 150;

        // TODO: Get data from setting :D

        return UploadControl(helper, fieldname, url, w, h);
    }

    public static HtmlString UploadControl(this HtmlHelper helper, string fieldname, string url, int thumbnailwidth, int thumbnailheight)
    {

        UrlHelper m = new UrlHelper(helper.ViewContext.RequestContext);

        var t = m.Action("ThumbnailBySize", "ImageBrowser", new { thumbnailwidth = thumbnailheight, thumbnailheight = thumbnailwidth, path = "tmp_url" });

        string html = @"
                        <img id='%PreviewImage%' src=''   />
                        <input type='button' id='%BID%' class='k-button k-button-icontext k-grid' value='%BIDT%' style='float: right;clear: right;'/>
                        <input type='button' id='%RID%' class='k-button k-button-icontext k-grid' value='%RIDT%' />
                        
                        <input type='hidden' name='%HID%'  id='%HID%' value='' />
                        <script>
                            $('#%BID%').bind('click', function () { loadimagebrowser('%URL%', '#%HID%'); });
                            
                            $('#%RID%').bind('click', function () {
                                var t = confirm('آیا برای حذف فایل اطمینان دارید؟');
                                    if (t == true) {
                                        $('#%HID%').val('').trigger('change');
                                    }
                             });
                            $('#%HID%').change(function () {
                                window_open();
                            });
                            $(document).ready(function () {

                               setTimeout(window_open,100);
                            });
                                                        
                            function window_open() {
                               var txt = $('#%HID%').val();
                                
                                if (txt.length > 0) {
                                    $('#%PreviewImage%').attr('src', '#URL#'.replace('tmp_url', txt));
                                    $('#%PreviewImage%').attr('style', 'display: block;clear: both;float: right;padding: 5px;');
                                    $('#%RID%').attr('style', 'display: block;float: right;');
                                }
                                else {
                                    $('#%PreviewImage%').attr('style', 'display: none;clear: both;padding: 5px;');
                                    $('#%RID%').attr('style', 'display: none;clear: both;');
                    
                                }
                            }
                            var dialog = $('.k-window').data('kendoWindow');
                            $(dialog).bind('open', setTimeout(window_open,100)).bind('activate', setTimeout(window_open,100));
                        </script>"
                        .Replace("%BID%", fieldname + "_upload_button")
                        .Replace("%RID%", fieldname + "_remove_button")
                        .Replace("%HID%", fieldname)
                        .Replace("%URL%", url)
                        .Replace("%RIDT%", MyCMS.Component.KendoUI.Resources.Messages.Upload_Remove)
                        .Replace("%VIDT%", "نمایش")
                        .Replace("%BIDT%", MyCMS.Component.KendoUI.Resources.Messages.Upload_Select)
                        .Replace("%PreviewImage%", fieldname + "_preview_image")
                        .Replace("#URL#", t);
   

        return new HtmlString(html);
    }


    //--------------test---------------------
    //    private static MvcHtmlString GetPartial<TRootModel, TModelForPartial>(
    //HtmlHelper<TRootModel> helper, string partialName, Expression<Func<TRootModel, TModelForPartial>> getter)
    //    {
    //        var prefix = ExpressionHelper.GetExpressionText(getter);
    //        return helper.Partial(partialName, getter.Compile().Invoke(helper.ViewData.Model),
    //        new ViewDataDictionary { TemplateInfo = new TemplateInfo { HtmlFieldPrefix = prefix } });
    //    }

    //    public static MvcHtmlString EditorForNameModel<TModel,TName>(
    //this HtmlHelper<TModel> helper, Expression<Func<TModel, TName>> getter)
    //    {
    //        return GetPartial(helper, "EditorTemplates/PropertyGroup", getter);
    //    }

    //----------------------------------------


    public static object GetEnglishCalendar(this string helper)
    {
        string pattern = @"(?>((?>13|14)\d\d)|(\d\d))\/(0?[1-9]|1[012])\/([12][0-9]|3[01]|0?[1-9])";
        try
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(helper, pattern))
            {

                System.Text.RegularExpressions.Regex d = new System.Text.RegularExpressions.Regex(pattern);



                int year = int.Parse(d.Match(helper).Groups[1].Value);

                int month = int.Parse(d.Match(helper).Groups[3].Value);

                int day = int.Parse(d.Match(helper).Groups[4].Value);

                PersianCalendar result = new PersianCalendar();

                return result.ToDateTime(year, month, day, 0, 0, 0, 0);
            }

        }
        catch (Exception)
        {
            return helper;
        }
        return helper;
    }

    public static bool Compare(this DateTime source, DateTime to)
    {

        return source.Date.Year == to.Date.Year && source.Date.Month == to.Date.Month && source.Date.Day == to.Date.Day;
    }

    public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
    {
        // build parameter map (from parameters of second to parameters of first)
        var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

        // replace parameters in the second lambda expression with parameters from the first
        var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

        // apply composition of lambda expression bodies to parameters from the first expression 
        return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
    }

    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
    {
        return first.Compose(second, Expression.And);
    }


    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
    {
        return first.Compose(second, Expression.Or);
    }


    public static Expression<Func<T, bool>> ConvertDataSourceRequestToExpression<T>(DataSourceRequest dataSourceRequest)
    {
        return ConvertDataSourceRequestToExpression<T>(new List<T>().AsQueryable(), dataSourceRequest);
    }
    public static Expression<Func<T, bool>> ConvertDataSourceRequestToExpression<T>
    (this IQueryable<T> items, DataSourceRequest dataSourceRequest)
    {

        var t = items.GetExperssion(dataSourceRequest.Filters);

        //string q = "";
        //List<IFilterDescriptor> filter = dataSourceRequest.Filters.ToList();
        //object item;
        //if (filter.Is(typeof(FilterDescriptor)))
        //{
        //    item = new FilterDescriptor();
        //}
        //else if (filter.Is(typeof(CompositeFilterDescriptor)))
        //{
        //    item = new CompositeFilterDescriptor();

        //}
        //try
        //{

        //    foreach (var filterDescriptor in dataSourceRequest.Filters.Cast<CompositeFilterDescriptor>())
        //    {

        //        var list = filterDescriptor.FilterDescriptors.Cast<FilterDescriptor>().ToList();
        //        foreach (var i in list)
        //        {
        //            q += i.Operator.getOerationToString().Replace("y", i.Member).Replace("x", i.Value.ToString()) + " " + (list.Last().Value == i.Value ? " " : filterDescriptor.LogicalOperator.ToString()) + "  ";
        //        }
        //    }

        //}
        //catch { }
        //try
        //{
        //    var list = dataSourceRequest.Filters.Cast<FilterDescriptor>();
        //    foreach (var i in list)
        //    {

        //        q += i.Operator.getOerationToString().Replace("y", i.Member).Replace("x", i.Value.ToString()) + " " + (list.Last().Value == i.Value ? " " : " and ") + "  ";

        //    }
        //}
        //catch { }

        return (items.ConvertStringToPredicate(t));
    }

    public static string GetExperssion<T>(this IQueryable<T> items, IList<IFilterDescriptor> filter, FilterCompositionLogicalOperator opr = FilterCompositionLogicalOperator.And)
    {
        string q = "";

        if (filter.Is(typeof(FilterDescriptor)))
        {

            var list = filter.Cast<FilterDescriptor>();
            foreach (var i in list)
            {
                q += i.Operator.getOerationToString().Replace("y", i.Member).Replace("x", i.Value.ToString()) + " " + (list.Last().Value == i.Value ? " " : " " + opr.ToString() + " ");
            }


        }
        else if (filter.Is(typeof(CompositeFilterDescriptor)))
        {
            foreach (var i in filter.Cast<IFilterDescriptor>())
            {

                if (i.GetType() == typeof(CompositeFilterDescriptor))
                {
                    q +=
                        "(" +
                        items.GetExperssion(((CompositeFilterDescriptor)i).FilterDescriptors, ((CompositeFilterDescriptor)i).LogicalOperator)
                        + " ) " +
                        (filter.Cast<IFilterDescriptor>().Last() == ((CompositeFilterDescriptor)i) ? " " : " And ");
                }
                else if (i.GetType() == typeof(FilterDescriptor))
                {

                    q += ((FilterDescriptor)i).Operator.getOerationToString().Replace("y", ((FilterDescriptor)i).Member).Replace("x", ((FilterDescriptor)i).Value.ToString()) + " " + (filter.Cast<IFilterDescriptor>().Last() == ((FilterDescriptor)i) ? " " : " " + opr.ToString() + " ");
                }
            }


        }
        return q;
    }

    public static string getOerationToString(this FilterOperator source)
    {

        switch (source)
        {
            case FilterOperator.IsLessThan:
                return " y < \"x\"";
                break;
            case FilterOperator.IsLessThanOrEqualTo:
                return " y <= \"x\"";
                break;
            case FilterOperator.IsEqualTo:
                return " y = \"x\"";
                break;
            case FilterOperator.IsNotEqualTo:
                return " y <> \"x\"";
                break;
            case FilterOperator.IsGreaterThanOrEqualTo:
                return " y >=\"x\"";
                break;
            case FilterOperator.IsGreaterThan:
                return " y > \"x\"";
                break;
            case FilterOperator.StartsWith:
                return " y.StartsWith(\"x\") ";
                break;
            case FilterOperator.EndsWith:
                return " y.EndsWith(\"x\") ";
                break;
            case FilterOperator.Contains:
                return " y.Contains(\"x\") ";
                break;
            case FilterOperator.IsContainedIn:
                return " y.Contains(\"x\") ";
                break;
            case FilterOperator.DoesNotContain:
                return " !y.Contains(\"x\") ";
                break;
            default:
                return "";
                break;
        }
    }

    public static Expression<Func<T, bool>> ConvertStringToPredicate<T>(this IQueryable<T> source, string predicate)
    {

        if (source == null) throw new ArgumentNullException("source");
        if (predicate == null) throw new ArgumentNullException("predicate");

        LambdaExpression lambda = MyCMS.Utilities.DynamicLinq.DynamicExpression.ParseLambda(source.ElementType, typeof(bool), predicate);


        var funcType = typeof(Func<T, bool>);
        var variable = Expression.Variable(typeof(Func<T, bool>));

        var props = new[] { variable };
        var result = (Expression<Func<T, bool>>)lambda;


        return result;


    }

    public static bool Is(this IEnumerable<IFilterDescriptor> source, Type com)
    {
        return (source.FirstOrDefault()).GetType().FullName.Replace((source.FirstOrDefault()).GetType().Namespace + ".", "").Equals(com.FullName.Replace((com).Namespace + ".", ""));
    }

    public static bool Is(this IFilterDescriptor source, Type com)
    {
        return (source).GetType().FullName.Replace((source).GetType().Namespace + ".", "").Equals(com.GetType().FullName.Replace((com).Namespace + ".", ""));
    }

    public static Expression<Func<T, bool>> GetLambdaOrListWhereDynamically<T>(this Dictionary<int, Tuple<string, object, Type>> myDictionary)
    {
        Expression<Func<T, bool>> lambdaWhereExpression = null;
        for (int index = 0; index < myDictionary.Count; index++)
        {
            var dic = myDictionary.ElementAt(index);
            var paramSelect2 = Expression.Parameter(typeof(T), typeof(T).Name.ToLower());
            var lenSelect2 = Expression.PropertyOrField(paramSelect2, dic.Value.Item1);
            Expression rightExpression = null;

            rightExpression = Expression.Convert(Expression.Constant(dic.Value.Item2), dic.Value.Item3);
            var body2 = Expression.Equal(lenSelect2, rightExpression);
            var lWE = Expression.Lambda<Func<T, bool>>(body2, paramSelect2);
            if (lambdaWhereExpression == null)
                lambdaWhereExpression = lWE;
            else
                lambdaWhereExpression = lambdaWhereExpression.Or(lWE);
        }
        return lambdaWhereExpression;
    }
    public static Expression<Func<T, bool>> GetLambdaListWhereDynamically<T>(this Dictionary<int, Tuple<string, object, Type>> myDictionary)
    {
        Expression<Func<T, bool>> lambdaWhereExpression = null;
        for (int index = 0; index < myDictionary.Count; index++)
        {
            var dic = myDictionary.ElementAt(index);
            var paramSelect2 = Expression.Parameter(typeof(T), typeof(T).Name.ToLower());
            var lenSelect2 = Expression.PropertyOrField(paramSelect2, dic.Value.Item1);
            Expression rightExpression = null;
            /*
            if ((Nullable.GetUnderlyingType(dic.Value.Item3) != null)
                || (dic.Value.Item3==null)
                || (!dic.Value.Item3.IsValueType))
            {
                // It's nullable
                rightExpression = Expression.Convert(Expression.Constant(dic.Value.Item2), dic.Value.Item3); 
                
            }
            else
            {
                rightExpression = Expression.Constant(dic.Value.Item2, dic.Value.Item3);
            }
            BinaryExpression body2 = null;
            if (dic.Value.Item3 == typeof (System.Int32))
                body2 = Expression.Equal(Expression.Convert(lenSelect2, typeof(int?)),  rightExpression);
                //body2 = Expression.Assign(lenSelect2, rightExpression);
            else
                body2 = Expression.Equal(lenSelect2, rightExpression);
            */
            rightExpression = Expression.Convert(Expression.Constant(dic.Value.Item2), dic.Value.Item3);
            var body2 = Expression.Equal(lenSelect2, rightExpression);
            var lWE = Expression.Lambda<Func<T, bool>>(body2, paramSelect2);
            if (lambdaWhereExpression == null)
                lambdaWhereExpression = lWE;
            else
                lambdaWhereExpression = lambdaWhereExpression.And(lWE);
        }
        return lambdaWhereExpression;
    }

    public static Expression<Func<T, string>> GetLambdaSelectDynamically<T>(this string columnName)
    {
        var item = Expression.Parameter(typeof(T), typeof(T).Name.ToLower());
        var length = Expression.PropertyOrField(item, columnName);
        var lambdaSelectExpression = Expression.Lambda<Func<T, string>>(length, item);
        return lambdaSelectExpression;
    }



    public static string GetPersianCalendar(this DateTime helper, string format = "yyyy/mm/dd")
    {

        if (helper.Year < 1000) helper = DateTime.Now;
        PersianCalendar pc = new PersianCalendar();

        string result = format.ToLower();

        result = result.Replace("yyyy", pc.GetYear(helper).ToString());

        result = result.Replace("mm", pc.GetMonth(helper).ToString());

        result = result.Replace("dd", pc.GetDayOfMonth(helper).ToString());

        return result;
    }

    public static string ConvertBoolToString(this string val)
    {
        return bool.Parse(val) ? "دارد" : "ندارد";
    }

    //public static IHtmlString CheckboxListFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, IEnumerable<string>>> ex, IEnumerable<string> possibleValues)
    //{

    //    var metadata = ModelMetadata.FromLambdaExpression(ex, html.ViewData);
    //    var availableValues = (IEnumerable<string>)metadata.Model;
    //    var name = ExpressionHelper.GetExpressionText(ex);
    //    return html.CheckboxList(name, availableValues, possibleValues);
    //}

    //private static IHtmlString CheckboxList(this HtmlHelper html, string name, IEnumerable<string> selectedValues, IEnumerable<string> possibleValues)
    //{
    //    var result = new StringBuilder();

    //    foreach (string current in possibleValues)
    //    {
    //        var label = new TagBuilder("label");
    //        var sb = new StringBuilder();

    //        var checkbox = new TagBuilder("input");
    //        checkbox.Attributes["type"] = "checkbox";
    //        checkbox.Attributes["name"] = name;
    //        checkbox.Attributes["value"] = current;
    //        var isChecked = selectedValues.Contains(current);
    //        if (isChecked)
    //        {
    //            checkbox.Attributes["checked"] = "checked";
    //        }

    //        sb.Append(checkbox.ToString());
    //        sb.Append(current);

    //        label.InnerHtml = sb.ToString();
    //        result.Append(label);
    //    }
    //    return new HtmlString(result.ToString());
    //}

    public static string CalculateMonthName(this int value)
    {
        if (value >= 1 && value <= 11)
        {
            return value.ConvertNumberToText() + " ماهه ";
        }
        else if (value >= 12)
        {
            int x = value / 12;
            return x.ConvertNumberToText() + " ساله ";
        }
        else
            return "";
    }

    public static string ConvertNumberToText(this int value)
    {
        return ReadableInteger.NumberToText(value, Language.Persian);
    }




    public static bool IsBuiltIn(this string item)
    {
        return DataDictionary.BuiltInDictionary.Any(q => q.Value.Item1 == item);
    }

    public static T ParseEnum<T>(this string value)
    {
        return (T)Enum.Parse(typeof(T), value, true);
    }

    public static string GetFileNameSubstring(this string filename, int length)
    {
        string extention = filename.Split('.')[filename.Split('.').Length - 1];

        if (filename.Replace(extention, "").Length < length + 2)
        {
            return filename;
        }
        return filename.Replace(extention, "").Substring(0, length) + "..." + extention;

    }


    public static IEnumerable<T> DistinctBy<T, TIdentity>(this IEnumerable<T> source, Func<T, TIdentity> identitySelector)
    {
        return source.Distinct(By(identitySelector));
    }

    public static IEqualityComparer<TSource> By<TSource, TIdentity>(Func<TSource, TIdentity> identitySelector)
    {
        return new DelegateComparer<TSource, TIdentity>(identitySelector);
    }

    private class DelegateComparer<T, TIdentity> : IEqualityComparer<T>
    {
        private readonly Func<T, TIdentity> identitySelector;

        public DelegateComparer(Func<T, TIdentity> identitySelector)
        {
            this.identitySelector = identitySelector;
        }

        public bool Equals(T x, T y)
        {
            return Equals(identitySelector(x), identitySelector(y));
        }

        public int GetHashCode(T obj)
        {
            return identitySelector(obj).GetHashCode();
        }
    }



    //public static string GenerateSalt(this string pass, int saltSize)
    //{
    //    ////Create and populate random byte array
    //    //byte[] randomArray = new byte[saltSize];
    //    //string randomString;

    //    ////Create random salt and convert to string
    //    //Random rnd = new Random();
    //    //rnd.NextBytes(randomArray);
    //    //randomString = Convert.ToBase64String(randomArray);
    //    //return randomString;

    //    var random = new RNGCryptoServiceProvider();
    //    var salt = new Byte[saltSize];
    //    random.GetBytes(salt);
    //    return Convert.ToBase64String(salt);
    //}


    //public static string CreatePasswordHash(this string password, string saltvalue)
    //{
    //    //string saltAndPwd = String.Concat(password, saltvalue);
    //    //string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "SHA1");
    //    //return hashedPwd;
    //    MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
    //    var combinedPassword = String.Concat(password, saltvalue);
    //    //var sha256 = new SHA256Managed();
    //    var bytes = UTF8Encoding.UTF8.GetBytes(combinedPassword);
    //    var hash = md5Provider.ComputeHash(bytes);
    //    return Convert.ToBase64String(hash);
    //}

    public static string DecryptHashedPassword(this string hashpass)
    {
        //if (hashpass == null) throw new ArgumentNullException("cipher");

        ////parse base64 string
        //byte[] data = Convert.FromBase64String(hashpass);

        ////decrypt data
        //byte[] decrypted = ProtectedData.Unprotect(data, null, Scope);
        //return Encoding.Unicode.GetString(decrypted);
        return null;
    }

    public static MvcHtmlString DataDictionaryDropDownList(this HtmlHelper htmlHelper, string name, Dictionary<int, Tuple<string, string>> selectedValue, int selectedItem, bool hasDefaultValue, KeyValuePair<string, string> defaultValue, object htmlAttribute)
    {
        var items = new List<SelectListItem>();
        if (hasDefaultValue)
        {
            items.Add(new SelectListItem()
            {
                Value = defaultValue.Key,
                Text = defaultValue.Value
            });

        }
        items.AddRange(selectedValue.Select(s => new SelectListItem
        {
            Value = s.Key.ToString(),
            Text = selectedItem == 1 ? s.Value.Item1 : s.Value.Item2

        }));
        //new SelectListItem
        //    {
        //        Text = value.ToString(),
        //        Value = value.ToString(),
        //        Selected = (value.Equals(selectedValue))
        //    };

        return htmlHelper.DropDownList(
            name,
            items,
            htmlAttribute
            );
    }

    public static MvcHtmlString DataDictionaryDropDownList(this HtmlHelper htmlHelper, string name, Dictionary<int, Tuple<string, string>> selectedValue, int selectedItem, object htmlAttribute)
    {


        IEnumerable<SelectListItem> items = selectedValue.Select(s => new SelectListItem
        {
            Value = s.Key.ToString(),
            Text = selectedItem == 1 ? s.Value.Item1 : s.Value.Item2

        });
        return htmlHelper.DropDownList(
            name,
            items,
            htmlAttribute
            );
    }

    public static string ParserFormatParameter<T>(T entity, string[] parametersName)
    {
        string result = "";

        var plist = entity.GetType().GetProperties();
        foreach (var prop in plist)
        {
            if (parametersName.Contains(prop.Name))
            {
                result += prop.Name + ":" + prop.GetValue(entity) + "#";

            }
        }
        return result.Remove(result.Count() - 1);
    }

    public static string GetLongPersianDateString(this DateTime dateValue)
    {
        return new ClassGetShamsiDay(dateValue).CRCompleteShamsiDate;
    }
    public static string GetEnumDescription(this Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        DescriptionAttribute[] attributes =
            (DescriptionAttribute[])fi.GetCustomAttributes(
            typeof(DescriptionAttribute),
            false);

        if (attributes != null &&
            attributes.Length > 0)
            return attributes[0].Description;
        else
            return value.ToString();
    }
    #region  Xml stuff and xml to json and vice versa   // YB

    #region Set
    public static string XmlSetElementValueByElementName(this string xmlstr, string element, string value)
    {
        var xml = XDocument.Parse(xmlstr, LoadOptions.PreserveWhitespace);
        var el = from node in xml.Descendants(element) select node;
        var elem = el.FirstOrDefault();
        if (elem != null)
            elem.SetValue(value);
        return xml.ToString();
    }
    public static string XmlSetElementAttributeValue(this string xmlstr, string element, string attr, string value)
    {
        var xml = XDocument.Parse(xmlstr);
        var el = from node in xml.Descendants(element) select node;
        var elem = el.FirstOrDefault();
        if (elem != null)
            elem.Attribute(attr).SetValue(value);
        return xml.ToString();
    }

    #endregion

    #region get

    public static string XmlGetElementValueByElementName(this string xmlstr, string element)
    {
        //XElement tempElement = doc.Descendants(XName.Get("test", "ab")).FirstOrDefault();
        var xml = XDocument.Parse(xmlstr, LoadOptions.PreserveWhitespace);
        var el = from node in xml.Descendants(element) select node;
        if (el.Any())
            return el.FirstOrDefault().Value;
        return null;
    }
    public static string XmlGetElementValueByElementName(this string xmlstr, string element, int itemNo)
    {
        var xml = XDocument.Parse(xmlstr, LoadOptions.PreserveWhitespace);
        var el = from node in xml.Descendants(element) select node;
        var xElements = el as XElement[] ?? el.ToArray();
        if ((xElements.Any()) && (xElements.ToList().Count >= itemNo))
            return xElements.ToList()[itemNo].Value;
        return null;
        //if ((el.Any()) && (el.ToList().Count >= itemNo))
        //  return el.ToList()[itemNo].Value;
    }
    public static string XmlGetElementValueByElementName(this string xmlstr, string nameSpace, string element, int itemNo)
    {
        XNamespace contact = nameSpace; //"http://epp.nic.ir/ns/contact-1.0";
        XElement po = XElement.Parse(xmlstr);
        IEnumerable<XElement> items =
            from el in po.Descendants(contact + element)
            select el;
        var xElements = items as XElement[] ?? items.ToArray();
        if ((xElements.Any()) && (xElements.ToList().Count >= itemNo))
            return xElements.ToList()[itemNo].Value;
        return null;
    }
    public static Dictionary<string, string> XmlGetElementValueAndAttributeValueByElementAndAttributeName(this string xmlstr, string nameSpace, string element, string attr)
    {
        var strList = new Dictionary<string, string>();
        XNamespace contact = nameSpace; //"http://epp.nic.ir/ns/contact-1.0";
        XElement po = XElement.Parse(xmlstr);
        IEnumerable<XElement> items =
            from el in po.Descendants(contact + element)
            select el;
        var list = items.ToList();

        foreach (var i in list)
        {
            strList.Add(i.Value, i.Attribute(XName.Get(attr)).Value);
        }
        if (strList.Any())
            return strList;
        return null;
    }
    public static string XmlGetElementAttributeValueByElementName(this string xmlstr, string element, string attr)
    {
        var str = xmlstr.Replace(Environment.NewLine, "");
        var xml = XDocument.Parse(str, LoadOptions.None);
        var el = from node in xml.Descendants(element)
                 select node.Attribute(attr).Value;
        return el.FirstOrDefault();

    }
    public static string XmlGetElementAttributeValueByElementName(this string xmlstr, string nameSpace, string element, string attr, int itemNo)
    {
        XNamespace contact = nameSpace; //"http://epp.nic.ir/ns/contact-1.0";
        XElement po = XElement.Parse(xmlstr);
        IEnumerable<XElement> items =
            from el in po.Descendants(contact + element)
            select el;
        var xElements = items as XElement[] ?? items.ToArray();
        if ((xElements.Any()) && (xElements.ToList().Count >= itemNo))
            return xElements.ToList()[itemNo].Attribute(attr).Value;
        return null;
    }

    public static string XmlGetElementValueByRegexPattern(this string xmlstr, string elementName)
    {
        //elementName = "contact:id";
        var regex = new Regex(string.Format(@"<{0}>[a-zA-Z0-9\s]+<\/{0}>", elementName));
        Match match = regex.Match(xmlstr);
        if (match.Success)
        {
            return match.Value.Replace(string.Format(@"<{0}>", elementName), "").Replace(string.Format(@"</{0}>", elementName), "");
        }
        return null;
    }


    public static string XmlGetElementAttributeValueByElementNameAndOtherAttributeValue(this string xmlstr, string element, string attr, string attrValue, string secondAttr)
    {
        var str = xmlstr.Replace(Environment.NewLine, "");
        var xml = XDocument.Parse(str, LoadOptions.None);
        var el = from node in xml.Descendants(element)
                 select node;
        return el.FirstOrDefault(i => (string)i.Attribute(attr) == attrValue).Attribute(secondAttr).Value;
    }
    public static string XmlGetElementValueByElementNameAndAttributeValue(this string xmlstr, string element, string attr, string attrValue)
    {
        var str = xmlstr.Replace(Environment.NewLine, "");
        var xml = XDocument.Parse(str, LoadOptions.None);
        var el = from node in xml.Descendants(element)
                 select node;
        return el.FirstOrDefault(i => (string)i.Attribute(attr) == attrValue).Value;
    }
    public static List<string> XmlGetElementValueByElementNameAndAttributeValue(this string xmlstr, string nameSpace, string element, string attr, string attrValue)
    {
        var strList = new List<string>();
        XNamespace contact = nameSpace; //"http://epp.nic.ir/ns/contact-1.0";
        XElement po = XElement.Parse(xmlstr);
        IEnumerable<XElement> items =
            from el in po.Descendants(contact + element)
            select el;
        var list = items.ToList().Where(i => (string)i.Attribute(attr) == attrValue);

        foreach (var i in list)
        {
            strList.Add(i.Value);
            //prdName.Attribute(XName.Get(attr)).Name + ":" + (string)prdName);
        }
        if (strList.Any())
            return strList;
        return null;

    }
    public static List<string> XmlGetElementAttributeValuesByTheSameElementName(this string xmlstr, string nameSpace, string element, string attr)
    {
        var strList = new List<string>();
        XNamespace contact = nameSpace; //"http://epp.nic.ir/ns/contact-1.0";
        XElement po = XElement.Parse(xmlstr);
        IEnumerable<XElement> items =
            from el in po.Descendants(contact + element)
            select el;
        foreach (XElement prdName in items)
        {
            strList.Add(prdName.Attribute(XName.Get(attr)).Value);
        }
        return strList;
    }
    public static Dictionary<string, string> XmlGetElementAttributeValuesByTheSameElementName(this string xmlstr, string nameSpace, string element, string attr, string secondAttr)
    {
        var strList = new Dictionary<string, string>();
        XNamespace contact = nameSpace;
        XElement po = XElement.Parse(xmlstr);
        IEnumerable<XElement> items =
            from el in po.Descendants(contact + element)
            select el;
        foreach (XElement prdName in items)
        {
            strList.Add(prdName.Attribute(XName.Get(attr)).Value, prdName.Attribute(XName.Get(secondAttr)).Value);
        }
        return strList;
    }
    public static Dictionary<string, string> XmlGetElementValuesByTheSameElementName(this string xmlstr, string nameSpace, string element, string attr)
    {
        var strList = new Dictionary<string, string>();
        XNamespace contact = nameSpace;
        XElement po = XElement.Parse(xmlstr);
        IEnumerable<XElement> items =
            from el in po.Descendants(contact + element)
            select el;
        foreach (XElement prdName in items)
        {
            strList.Add(prdName.Attribute(XName.Get(attr)).Value, prdName.Value);
        }
        return strList;
    }
    public static Dictionary<int, Tuple<string, string>> XmlGetElementElementsAndValueByElementName(this string xmlstr, string element)
    {
        var xml = XDocument.Parse(xmlstr, LoadOptions.PreserveWhitespace);

        var elements = from node in xml.Descendants(element)
                       select node;
        int i = 1;
        return elements.ToDictionary(elem => i++, elem => Tuple.Create(elem.Name.ToString(), elem.Value));
    }
    public static List<Dictionary<int, Tuple<string, string>>> XmlGetElementElementsAndValueByElement(this string xmlstr, string element)
    {
        var list = new List<Dictionary<int, Tuple<string, string>>>();
        var xml = XDocument.Parse(xmlstr, LoadOptions.PreserveWhitespace);
        var elements = from node in xml.Descendants(element)
                       select node;

        foreach (var elem in elements)
        {
            int i = 1;
            var dic = elem.Elements().ToDictionary(node => i++, node => Tuple.Create(node.Name.ToString(), node.Value));
            list.Add(dic);
        }
        return list;
    }




    #endregion






    #region Convert
    public static string XmlToJson(this string xml)
    {
        var x = new XmlDocument();
        x.LoadXml(xml);
        return JsonConvert.SerializeXmlNode(x, Formatting.Indented, true);

    }
    public static string XmlFromJson(this string json)
    {
        var xml = JsonConvert.DeserializeXmlNode(json, "Root");
        return xml.InnerXml;
    }
    #endregion
    #region call Expression methods such as Equal NotEqual etc



    public static bool CallExpressionMethods(this string methodName, dynamic left, dynamic right)
    {
        var type = left.GetType();

        Expression leftVal = Expression.Constant(Convert.ChangeType(left, type), type);
        Expression rightVal = Expression.Constant(Convert.ChangeType(right, type), type);

        MethodInfo method = typeof(Expression).GetMethod(methodName, new[] { typeof(Expression), typeof(Expression) });
        var exp = (Expression)method.Invoke(null, new object[] { leftVal, rightVal });
        var lambda = Expression.Lambda<Func<bool>>(exp);
        var compiled = lambda.Compile().DynamicInvoke();
        return (bool)compiled;
    }
    public static bool CallStringMethods<T>(this string methodName, T sourceText, T innertext)
    {
        Expression sourceTextVal = Expression.Constant(sourceText, typeof(T));
        Expression innertextVal = Expression.Constant(innertext, typeof(T));

        var method = typeof(string).GetMethod(methodName, new[] { typeof(string) });
        var call = Expression.Call(sourceTextVal, method, innertextVal);

        var lambda = Expression.Lambda<Func<bool>>(call);
        var compiled = lambda.Compile().DynamicInvoke();
        return (bool)compiled;
    }

    #endregion

    public static List<Tuple<string, string>> GetAllVariableOrConstantTemplateTags(this string htmlStr, string tagSign)
    {
        //\[(@@|##)+[a-zA-Z0-9\s]+(@@|##)\]
        var regex = new Regex(string.Format(@"\[({0})+[a-zA-Z0-9\s]+({0})\]", tagSign));
        return (from Match element in regex.Matches(htmlStr) select Tuple.Create(element.Value, element.Value.Replace("[" + tagSign + "", "").Replace("" + tagSign + "]", ""))).ToList();
    }




    public static string ToHexString(this byte[] hex)
    {
        if (hex == null)
        {
            return null;
        }
        if (hex.Length == 0)
        {
            return string.Empty;
        }
        var s = new StringBuilder();
        foreach (byte b in hex)
        {
            s.Append(b.ToString("x2"));
        }
        return s.ToString();
    }

    public static byte[] ToHexBytes(this string hex)
    {
        if (hex == null)
        {
            return null;
        }
        if (hex.Length == 0)
        {
            return new byte[0];
        }
        int l = hex.Length / 2;
        var b = new byte[l];
        for (int i = 0; i < l; ++i)
        {
            b[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        }
        return b;
    }

    #endregion
}


public class ParameterRebinder : ExpressionVisitor
{
    private readonly Dictionary<ParameterExpression, ParameterExpression> map;

    public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
    {
        this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
    }

    public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
    {
        return new ParameterRebinder(map).Visit(exp);
    }

    protected override Expression VisitParameter(ParameterExpression p)
    {
        ParameterExpression replacement;
        if (map.TryGetValue(p, out replacement))
        {
            p = replacement;
        }
        return base.VisitParameter(p);
    }


}


#region ShamsiDateFullString
public class ClassGetShamsiDay
{
    private String DayName;
    private String MonthName;
    private String CompleteShamsiDate;

    public ClassGetShamsiDay()
        : this(DateTime.Now)
    {
    }
    public ClassGetShamsiDay(DateTime dt)
    {
        //DateTime dt = DateTime.Now;
        if (dt.DayOfWeek == DayOfWeek.Friday)
            DayName = "جمعه";
        if (dt.DayOfWeek == DayOfWeek.Saturday)
            DayName = "شنبه";
        if (dt.DayOfWeek == DayOfWeek.Sunday)
            DayName = "یکشنبه";
        if (dt.DayOfWeek == DayOfWeek.Monday)
            DayName = "دوشنبه";
        if (dt.DayOfWeek == DayOfWeek.Tuesday)
            DayName = "سه شنبه";
        if (dt.DayOfWeek == DayOfWeek.Wednesday)
            DayName = "چهار شنبه";
        if (dt.DayOfWeek == DayOfWeek.Thursday)
            DayName = "پنج شنبه";

        PersianCalendar pt = new PersianCalendar();
        int MoName = pt.GetMonth(dt);

        switch (MoName)
        {
            case 1:
                MonthName = "فروردین";
                break;
            case 2:
                MonthName = "اردیبهشت";
                break;
            case 3:
                MonthName = "خرداد";
                break;
            case 4:
                MonthName = "تیر";
                break;
            case 5:
                MonthName = "مرداد";
                break;
            case 6:
                MonthName = "شهریور";
                break;
            case 7:
                MonthName = "مهر";
                break;
            case 8:
                MonthName = "آبان";
                break;
            case 9:
                MonthName = "آذر";
                break;
            case 10:
                MonthName = "دی";
                break;
            case 11:
                MonthName = "بهمن";
                break;
            case 12:
                MonthName = "اسفند";
                break;
        }

        CompleteShamsiDate = DayName + " " + pt.GetDayOfMonth(dt) +
        " " + MonthName + " " + pt.GetYear(dt);
    }

    public String CRDaysName
    {
        set
        {
            DayName = value;
        }
        get
        {
            return DayName;
        }
    }

    public String CRMotheName
    {
        set
        {
            MonthName = value;
        }
        get
        {
            return MonthName;
        }
    }

    public String CRCompleteShamsiDate
    {
        set
        {
            CompleteShamsiDate = value;
        }
        get
        {
            return CompleteShamsiDate;
        }
    }
}
#endregion



