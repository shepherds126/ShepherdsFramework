using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShepherdsFramework.Core
{
    public class ShepherdsFrameWorkException : Exception
    {
        public ShepherdsFrameWorkException()
        {

        }

        public ShepherdsFrameWorkException(string message) : base(message)
        {

        }

        public ShepherdsFrameWorkException(string messageFormat, params object[] args)
            : base(string.Format(messageFormat, args))
        {

        }
    }
}
