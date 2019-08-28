using System;

namespace Calendar.EventHandler
{

    public class Publisher<T> : IPublisher<T>
    {
        //Defined datapublisher event
        public event EventHandler<DateChangedArgument<T>> DataPublisher;

        private void OnDataPublisher(DateChangedArgument<T> args)
        {
            var handler = DataPublisher;
            if (handler != null)
                handler(this, args);
        }


        public void PublishData(DateChangedArgument<T> data)
        {
            OnDataPublisher(data);
        }
    }
}
