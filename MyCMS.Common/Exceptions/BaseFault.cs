using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.Exceptions
{
    [DataContract]
    public class Fault
    {
        public Fault(string description = null, Fault innerFault = null, int code = 0)
        {
            this.Code = code;
            this.Description = description;
            this.InnerFault = innerFault;
            return;
        }

        [DataMember]
        public int Code { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public Fault InnerFault { get; set; }
        public override string ToString()
        {
            return string.Format("{0}, Code {1}: {2}", this.GetType().Name, Code, Description);
        }
        [DebuggerHidden]
        public static void ThrowException(string description = null, Fault innerFault = null, int code = 0)
        {
            throw Exception(description, innerFault, code);
        }
        public static FaultException<Fault> Exception(string description = null, Fault innerFault = null, int code = 0)
        {
            return new FaultException<Fault>(new InvalidName(description, innerFault, code), description);
        }

    }
}
