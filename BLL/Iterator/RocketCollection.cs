using System.Collections;
using System.Collections.Generic;
using BLL.Factory.Model;

namespace BLL.Iterator
{
    public class RocketCollection : IteratorAggregate
    {
        readonly List<IRocket> _collection = new List<IRocket>();

        bool _direction = false;

        public void ReverseDirection()
        {
            _direction = !_direction;
        }

        public List<IRocket> getItems()
        {
            return _collection;
        }

        public void AddItem(IRocket item)
        {
            this._collection.Add(item);
        }

        public override IEnumerator GetEnumerator()
        {
            return new RocketIterator(this, _direction);
        }
    }
}
