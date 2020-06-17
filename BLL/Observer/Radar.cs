using System;
using BLL.Observer.Interfaces;

namespace BLL.Observer
{

    public class Radar : IObserver
    {
        private readonly string _name;
        private IObservable _notifiers;

        public Radar(string name, IObservable notifiers)
        {
            _name = name;
            _notifiers = notifiers;
            _notifiers.RegisterObserver(this);
        }

        public void Update(object data)
        {
            var report = (string)data;

            Console.WriteLine($"Radar detected some action, action data: {data}");
        }
    }
}