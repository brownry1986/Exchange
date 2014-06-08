using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /*
     * Domain object for storing message information to pass between components
     * 
     * Implemented by Ryan Brown
     */
    public class Message
    {
        public MessageType messageType { get; set; }

        public Int32 messageLength { get; set; }

        public Object payload { get; set; }

        public Message(MessageType messageType, Object payload)
        {
            this.messageType = messageType;
            this.payload = payload;
        }
    }
}
