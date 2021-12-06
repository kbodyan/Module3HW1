using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnCollection
{
    public class ListCollection<T> : IEnumerable<T>
    {
        private T[] _array;
        private int _position = 0;

        public ListCollection()
        {
            _array = new T[10];
        }

        public ListCollection(int size)
        {
            _array = new T[size + 10];
        }

        public int Capacity
        {
            get
            {
                return _array.Length;
            }
        }

        public int Count
        {
            get
            {
                return _position;
            }
        }

        public void Add(T item)
        {
            if (_position >= _array.Length)
            {
                Resize(1);
            }

            _array[_position] = item;
            _position++;
        }

        public void AddRange(ICollection<T> collection)
        {
            if (_position + collection.Count >= _array.Length)
            {
                Resize(collection.Count);
            }

            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public void Clear()
        {
            _position = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < _position; i++)
            {
                yield return _array[i];
            }
        }

        public bool Remove(T item)
        {
            var flags = new bool[_position];
            var count = 0;
            for (var i = 0; i < _position; i++)
            {
                if (_array[i].GetHashCode() == item.GetHashCode())
                {
                    flags[i] = true;
                    count++;
                }
            }

            Zip(flags);
            _position -= count;
            if (count > 0)
            {
                return true;
            }

            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index <= _position)
            {
                var flags = new bool[_position];
                flags[index] = true;
                Zip(flags);
                return true;
            }

            return false;
        }

        public void Sort()
        {
            Array.Sort<T>(_array);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _array.GetEnumerator();
        }

        private void Resize(int size)
        {
            var bigger = new T[(_array.Length + size) * 2];
            _array.CopyTo(bigger, 0);
            _array = bigger;
        }

        private void Zip(bool[] flags)
        {
            var tempCount = 0;
            foreach (var item in flags)
            {
                if (item)
                {
                    tempCount++;
                }
            }

            var tempPosition = 0;
            for (var i = 0; i < _position && tempCount > 0; i++)
            {
                while (flags[i])
                {
                    i++;
                    tempCount--;
                }

                if (i != tempPosition)
                {
                    _array[tempPosition] = _array[i];
                }
            }
        }
    }
}
