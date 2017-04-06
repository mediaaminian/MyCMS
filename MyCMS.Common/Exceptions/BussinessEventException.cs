using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[Serializable]
public class TestException : BaseException
{
    public TestException() { }
    public TestException(string message) : base(message) { }
    public TestException(string message, BaseException inner) : base(message, inner) { }

    
}
[Serializable]
public class TestException<T> : BaseException<T>
{
    public TestException(T entity) : base(entity) { }
    public TestException(T entity,string message) : base(entity,message) { }
    public TestException(T entity,string message, BaseException<T> inner) : base(entity , message, inner) { }
    

}

