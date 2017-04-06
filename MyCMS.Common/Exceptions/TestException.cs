using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[Serializable]
public class BussinessEventException : BaseException
{
    public BussinessEventException() { }
    public BussinessEventException(string message) : base(message) { }
    public BussinessEventException(string message, BaseException inner) : base(message, inner) { }

    
}
[Serializable]
public class BussinessEventException<T> : BaseException<T>
{
    public BussinessEventException(T entity) : base(entity) { }
    public BussinessEventException(T entity,string message) : base(entity,message) { }
    public BussinessEventException(T entity,string message, BaseException<T> inner) : base(entity , message, inner) { }
    



}

