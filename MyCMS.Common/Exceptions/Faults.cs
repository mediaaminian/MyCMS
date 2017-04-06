using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Diagnostics;

namespace ERP.Common.Exceptions
{
    
	[DataContract]
    public partial class DataBase : Fault
    {
        public DataBase (string description = null, Fault innerFault = null, int code = 0): base(description, innerFault, code) { }
        [DebuggerHidden]
        new public static void ThrowException(string description = null, Fault innerFault = null, int code = 0)
        {
            throw Exception(description, innerFault, code);
        }
        new public static FaultException< DataBase > Exception(string description = null, Fault innerFault = null, int code = 0)
        {
            return new FaultException< DataBase >(new DataBase (description, innerFault, code), description);
        }
		new public static FaultException< DataBase > Exception(string description, params object[] args)
        {
            return new FaultException< DataBase >(new DataBase (string.Format(description,args),null,0), string.Format(description,args));
        }

    }
    
	[DataContract]
    public partial class InvalidFormat : Fault
    {
        public InvalidFormat (string description = null, Fault innerFault = null, int code = 0): base(description, innerFault, code) { }
        [DebuggerHidden]
        new public static void ThrowException(string description = null, Fault innerFault = null, int code = 0)
        {
            throw Exception(description, innerFault, code);
        }
        new public static FaultException< InvalidFormat > Exception(string description = null, Fault innerFault = null, int code = 0)
        {
            return new FaultException< InvalidFormat >(new InvalidFormat (description, innerFault, code), description);
        }
		new public static FaultException< InvalidFormat > Exception(string description, params object[] args)
        {
            return new FaultException< InvalidFormat >(new InvalidFormat (string.Format(description,args),null,0), string.Format(description,args));
        }

    }
    
	[DataContract]
    public partial class DuplicateName : Fault
    {
        public DuplicateName (string description = null, Fault innerFault = null, int code = 0): base(description, innerFault, code) { }
        [DebuggerHidden]
        new public static void ThrowException(string description = null, Fault innerFault = null, int code = 0)
        {
            throw Exception(description, innerFault, code);
        }
        new public static FaultException< DuplicateName > Exception(string description = null, Fault innerFault = null, int code = 0)
        {
            return new FaultException< DuplicateName >(new DuplicateName (description, innerFault, code), description);
        }
		new public static FaultException< DuplicateName > Exception(string description, params object[] args)
        {
            return new FaultException< DuplicateName >(new DuplicateName (string.Format(description,args),null,0), string.Format(description,args));
        }

    }
    
	[DataContract]
    public partial class InvalidOperation : Fault
    {
        public InvalidOperation (string description = null, Fault innerFault = null, int code = 0): base(description, innerFault, code) { }
        [DebuggerHidden]
        new public static void ThrowException(string description = null, Fault innerFault = null, int code = 0)
        {
            throw Exception(description, innerFault, code);
        }
        new public static FaultException< InvalidOperation > Exception(string description = null, Fault innerFault = null, int code = 0)
        {
            return new FaultException< InvalidOperation >(new InvalidOperation (description, innerFault, code), description);
        }
		new public static FaultException< InvalidOperation > Exception(string description, params object[] args)
        {
            return new FaultException< InvalidOperation >(new InvalidOperation (string.Format(description,args),null,0), string.Format(description,args));
        }

    }
    
	[DataContract]
    public partial class NotFound : Fault
    {
        public NotFound (string description = null, Fault innerFault = null, int code = 0): base(description, innerFault, code) { }
        [DebuggerHidden]
        new public static void ThrowException(string description = null, Fault innerFault = null, int code = 0)
        {
            throw Exception(description, innerFault, code);
        }
        new public static FaultException< NotFound > Exception(string description = null, Fault innerFault = null, int code = 0)
        {
            return new FaultException< NotFound >(new NotFound (description, innerFault, code), description);
        }
		new public static FaultException< NotFound > Exception(string description, params object[] args)
        {
            return new FaultException< NotFound >(new NotFound (string.Format(description,args),null,0), string.Format(description,args));
        }

    }
    
	[DataContract]
    public partial class AccessDenied : Fault
    {
        public AccessDenied (string description = null, Fault innerFault = null, int code = 0): base(description, innerFault, code) { }
        [DebuggerHidden]
        new public static void ThrowException(string description = null, Fault innerFault = null, int code = 0)
        {
            throw Exception(description, innerFault, code);
        }
        new public static FaultException< AccessDenied > Exception(string description = null, Fault innerFault = null, int code = 0)
        {
            return new FaultException< AccessDenied >(new AccessDenied (description, innerFault, code), description);
        }
		new public static FaultException< AccessDenied > Exception(string description, params object[] args)
        {
            return new FaultException< AccessDenied >(new AccessDenied (string.Format(description,args),null,0), string.Format(description,args));
        }

    }
    
	[DataContract]
    public partial class InvalidArgument : Fault
    {
        public InvalidArgument (string description = null, Fault innerFault = null, int code = 0): base(description, innerFault, code) { }
        [DebuggerHidden]
        new public static void ThrowException(string description = null, Fault innerFault = null, int code = 0)
        {
            throw Exception(description, innerFault, code);
        }
        new public static FaultException< InvalidArgument > Exception(string description = null, Fault innerFault = null, int code = 0)
        {
            return new FaultException< InvalidArgument >(new InvalidArgument (description, innerFault, code), description);
        }
		new public static FaultException< InvalidArgument > Exception(string description, params object[] args)
        {
            return new FaultException< InvalidArgument >(new InvalidArgument (string.Format(description,args),null,0), string.Format(description,args));
        }

    }
    
	[DataContract]
    public partial class InvalidName : Fault
    {
        public InvalidName (string description = null, Fault innerFault = null, int code = 0): base(description, innerFault, code) { }
        [DebuggerHidden]
        new public static void ThrowException(string description = null, Fault innerFault = null, int code = 0)
        {
            throw Exception(description, innerFault, code);
        }
        new public static FaultException< InvalidName > Exception(string description = null, Fault innerFault = null, int code = 0)
        {
            return new FaultException< InvalidName >(new InvalidName (description, innerFault, code), description);
        }
		new public static FaultException< InvalidName > Exception(string description, params object[] args)
        {
            return new FaultException< InvalidName >(new InvalidName (string.Format(description,args),null,0), string.Format(description,args));
        }

    }

}