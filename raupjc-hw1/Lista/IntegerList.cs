using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista
{
    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        private int numOfItems;

        public IntegerList()
        {
            _internalStorage = new int[4];
            numOfItems = 0;
        }

        public IntegerList(int initialSize)
        {
            if (initialSize > 0)
            {
                _internalStorage = new int[initialSize];
            }
            else
            {
                _internalStorage = new int[4];
            }
            numOfItems = 0;
        }

        public void Add(int item)
        {
            if (numOfItems == _internalStorage.Length)
            {
                int[] temp = new int[_internalStorage.Length * 2];
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

        public bool Remove(int item)
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

        public int GetElement(int index)
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

        public int IndexOf(int item)
        {
            int index = -1;
            for (int i = 0; i < numOfItems; ++i)
            {
                if (_internalStorage[i] == item)
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

        public bool Contains(int item)
        {
            bool found = false;
            for (int i = 0; i < numOfItems; ++i)
            {
                if (_internalStorage[i] == item)
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
