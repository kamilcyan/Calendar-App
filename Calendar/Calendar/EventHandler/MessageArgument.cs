using System;

namespace Calendar.EventHandler
{
    public class DateChangedArgument<T> : EventArgs
    {
        public T Message { get; private set; }
        public DateChangedArgument(T message)
        {
            Message = message;
        }
    }
}
