using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Check
{
    public static T NotNull<T>(T value, string parameterName) where T : class
    {
        if (value == null)
        {
            throw new ArgumentNullException(parameterName);
        }

        return value;
    }

    public static T? NotNull<T>(T? value, string parameterName) where T : struct
    {
        if (value == null)
        {
            throw new ArgumentNullException(parameterName);
        }

        return value;
    }

    public static string NotEmpty(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(value);
        }

        return value;
    }

    public static bool Is<T>(object des) where T : class
    {

        return typeof(T) == des.GetType();

    }

}
