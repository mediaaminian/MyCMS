using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[Serializable]
public class ModuleException : BaseException
{
    public ModuleException() { }
    public ModuleException(string message) : base(message) { }
    public ModuleException(string message, BaseException inner) : base(message, inner) { }

    
}
[Serializable]
public class ModuleException<T> : BaseException<T>
{
    public ModuleException(T entity) : base(entity) { }
    public ModuleException(T entity,string message) : base(entity,message) { }
    public ModuleException(T entity,string message, BaseException<T> inner) : base(entity , message, inner) { }
    

}

