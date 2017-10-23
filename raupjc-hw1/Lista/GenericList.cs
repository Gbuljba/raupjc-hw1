using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;
        private int numOfItems;

        public GenericList()
        {
            _internalStorage = new X[4];
            numOfItems = 0;
        }

        public GenericList(int initialSize)
        {
            if (initialSize > 0)
            {
                _internalStorage = new X[initialSize];
            }
            else
            {
                _internalStorage = new X[4];
            }
            numOfItems = 0;
        }

        public void Add(X item)
        {
            if (numOfItems == _internalStorage.Length)
            {
                X[] temp = new X[_internalStorage.Length * 2];
                for (int i = 0; i < _internalStorage.Length; ++i)
                {
                    temp[i] = _internalStorage[i];
                }
                _internalStorage = temp;
            }
            _internalStorage[numOfItems] = item;
            numOfItems++;
        }

        public bool RemoveAt(int index)
        {
            if (index >= numOfItems)
            {
                return false;
            }
            for (int i = index; i < numOfItems - 1; ++i)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            numOfItems--;
            return true;
        }

        public bool Remove(X item)
        {
            int index = IndexOf(item);
            if (index != -1)
            {
                return RemoveAt(index);
            }
            else
            {
                return false;
            }
        }

        public X GetElement(int index)
        {
            if (index < numOfItems)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int IndexOf(X item)
        {
            int index = -1;
            for (int i = 0; i < numOfItems; ++i)
            {
                if (_internalStorage[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                return -1;
            }
            else
            {
                return index;
            }
        }

        public void Clear()
        {
            numOfItems = 0;
        }

        public bool Contains(X item)
        {
            bool found = false;
            for (int i = 0; i < numOfItems; ++i)
            {
                if (_internalStorage[i].Equals(item))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        public int Count
        {
            get
            {
                return numOfItems;
            }
        }
    }
}
