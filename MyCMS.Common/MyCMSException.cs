using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.Utilities
{

    [Serializable]
    public class MyCMSException : Exception
    {
        public MyCMSException() { }
        public MyCMSException(string message) : base(message) { }
        public MyCMSException(string message, Exception inner) : base(message, inner) { }
        protected MyCMSException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }


        public MessageTypeEnum MessageType { get; set; }
        public bool ShowModel { get; set; }
        public int TimeOut { get; set; }
        public MessageLocationEnum Location { get; set; }

        public static void Throw(MessageTypeEnum messageType, string message, int timeOut = 0, bool showModel = false, MessageLocationEnum location = MessageLocationEnum.center)
        {

            MyCMSException my = new MyCMSException(message);

            my.ShowModel = showModel;
            my.TimeOut = timeOut * 1000;
            my.MessageType = messageType;
            my.Location = location;
            throw my;

        }
    }

}
