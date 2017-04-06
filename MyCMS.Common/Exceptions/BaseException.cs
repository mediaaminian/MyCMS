using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[Serializable]
public class BaseException : Exception
{

    public BaseException()
    {
        this.Log();
    }

    private void Log()
    {
        throw new NotImplementedException();
    }

    public BaseException(string message): base(message)
    {
        SystemMessage = message;
        this.Log(message);
    }

    private void Log(string message)
    {
        throw new NotImplementedException();
    }

    public BaseException(string message, BaseException inner): base(message, inner)
    {
        SystemMessage = message;
        SystemInnerException = inner;
        this.Log(message);
    }

    public DateTime EventDate
    {
        get
        {
            return DateTime.Now;
        }
    }
    public string SystemMessage { get; set; }
    public BaseException SystemInnerException { get; set; }
}

[Serializable]
public class BaseException<T> : BaseException
{
    public BaseException(T entity)
    {
        Entity = entity;
        this.Log<T>(entity);
    }

    private void Log<T1>(T1 entity)
    {
        throw new NotImplementedException();
    }

    public BaseException(T entity, string message): base(message)
    {
        SystemMessage = message;
        Entity = entity;
        this.Log<T>(message, entity);
    }

    private void Log<T1>(string message, T1 entity)
    {
        throw new NotImplementedException();
    }

    public BaseException(T entity, string message, BaseException<T> inner): base(message, inner)
    {
        SystemMessage = message;
        SystemInnerException = inner;
        Entity = entity;
        this.Log<T>(inner , message , entity);
    }

    private void Log<T1>(BaseException<T1> inner, string message, T1 entity)
    {
        throw new NotImplementedException();
    }

    //public BaseException(T entity, string message, BaseException inner): base(message, inner)
    //{
    //    Entity = entity;
    //    this.Log<T>(inner, message, entity);
    //}

    public T Entity { get; set; }
}

