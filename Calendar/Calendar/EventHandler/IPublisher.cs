using System;

namespace Calendar.EventHandler
{
    public interface IPublisher<T>
    {
        event EventHandler<DateChangedArgument<T>> DataPublisher;
        //void OnDataPublisher(MessageArgument<T> args);
        void PublishData(DateChangedArgument<T> data);
    }
}
