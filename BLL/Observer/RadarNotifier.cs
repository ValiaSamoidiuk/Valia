using System.Collections.Generic;
using BLL.Observer.Interfaces;

namespace BLL.Observer
{
    public class RadarNotifier : IObservable
    {
        readonly List<IObserver> _affairNotifiers;
        private string _data;

        public RadarNotifier()
        {
            _affairNotifiers = new List<IObserver>();
        }

        public void AddData(string report)
        {
            _data = report;
            NotifyObservers();
        }

        public void RegisterObserver(IObserver o)
        {
            _affairNotifiers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            _affairNotifiers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (var o in _affairNotifiers)
            {
                o.Update(_data);
            }
        }
    }
}