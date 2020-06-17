using System.Collections;
using System.Collections.Generic;
using BLL.Adapter.Models;
using BLL.Iterator;

namespace BLL.Adapter.VillageCollection
{
    public class FireworkLaunchSystemCollection : IteratorAggregate
    {
        readonly List<IFirework> _collection = new List<IFirework>();

        bool _direction = false;

        public void ReverseDirection()
        {
            _direction = !_direction;
        }

        public List<IFirework> getItems()
        {
            return _collection;
        }

        public void AddItem(IFirework item)
        {
            this._collection.Add(item);
        }

        public override IEnumerator GetEnumerator()
        {
            return new FireworkLaunchSystemIterator(this, _direction);
        }
    }
}
