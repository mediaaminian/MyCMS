
using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


public static class Logging
{
    private static IDocumentStore _db;

    private static IDocumentStore db
    {
        get
        {
            if (_db == null)
                _db = new DocumentStore()
                {
                    Url = ServerUrl
                }.Initialize();
            return _db;
        }
    }
    /// <summary>
    /// Database Name
    /// </summary>
    private static string LogDocument
    {
        get
        {
            return "Logging";
        }
    }

    /// <summary>
    /// Server Config url.
    /// </summary>
    private static string ServerUrl
    {
        get
        {
            return "http://192.168.0.40:54321";

        }
    }

    public static void Log(string message)
    {
        using (var session = db.OpenSession(LogDocument))
        {
            session.Store(new { Message = message });
            session.SaveChanges();
        }
    }

    public static void Log(this BaseException ex)
    {
        using (var session = db.OpenSession(LogDocument))
        {
            session.Store(ex);
            session.SaveChanges();
        }
    }

    public static void Log(this BaseException ex, string message)
    {
        ex.SystemMessage = message;
        ex.Log();
    }

    public static void Log(this BaseException ex, BaseException inner)
    {

        ex.SystemInnerException = inner;
        ex.Log();
    }

    public static void Log(this BaseException ex, BaseException inner, string message)
    {
        ex.SystemMessage = message;
        ex.SystemInnerException = inner;
        ex.Log();

    }


    public static void Log<T>(this BaseException<T> ex, T entity)
    {
        using (var session = db.OpenSession(LogDocument))
        {
            ex.Entity = entity;
            session.Store(ex);
            session.SaveChanges();
        }
    }

    public static void Log<T>(this BaseException<T> ex, string message, T entity)
    {
        ex.SystemMessage = message;
        ex.Entity = entity;
        ex.Log<T>(entity);
    }

    public static void Log<T>(this BaseException<T> ex, BaseException inner, T entity)
    {
        ex.SystemInnerException = inner;
        ex.Log<T>(entity);
    }

    public static void Log<T>(this BaseException<T> ex, BaseException inner, string message, T entity)
    {
        ex.SystemMessage = message;
        ex.SystemInnerException = inner;
        ex.Log<T>(entity);
    }


}

public class Log<T>
{
    public T Entity { get; set; }
    public string Message { get; set; }
}


