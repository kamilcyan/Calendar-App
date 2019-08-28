using System;

namespace Calendar.EventHandler
{
    public class Subscriber<T> : IDisposable
    {
        private static IPublisher<T> Publisher = new Publisher<T>();

        public Subscriber(EventHandler<DateChangedArgument<T>> action)
        {
            Publisher.DataPublisher += action;
            Action = action;
        }

        private EventHandler<DateChangedArgument<T>> Action;

        public void Dispose()
        {
            Publisher.DataPublisher -= Action;
        }

        internal void PublishData(DateChangedArgument<T> eventArgs)
        {
            Publisher.PublishData(eventArgs);
        }
    }
}
