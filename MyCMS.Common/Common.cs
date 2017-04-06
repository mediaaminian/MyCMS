using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;

namespace MyCMS.Utilities
{
    public class Common
    {
        public static string GetValueFromEntity(KeyValuePair<string, Tuple<object, string>> entityinfo, dynamic entity)
        {
            var prop = entityinfo.Value.Item2.Split('.');
            if (prop.Count() > 1)
            {
                return RecursiveInnerParameterValue(entity, prop);
            }
            return entity.GetType().GetProperty(entityinfo.Value.Item2).GetValue(entity, null);
        }
        public static string RecursiveInnerParameterValue(dynamic entity, string[] prop, int i = -1)
        {
            try
            {
                if (prop.Count() - 1 == i)
                    return entity.ToString();

                i += 1;
                return RecursiveInnerParameterValue(entity.GetType().GetProperty(prop[i]).GetValue(entity, null), prop, i);
            }
            catch (RuntimeBinderException)
            {
                return "";
            }
        }
    }
}
