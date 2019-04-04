using System;
using System.Collections.Generic;

namespace lesson2
{
    public class Container<T>
    {
        private const int BigGap = 2000;

        private Tuple<IntEx, T>[] _array = new Tuple<IntEx, T>[BigGap];
        private Dictionary<IntEx, T[]> _dictionary = new Dictionary<IntEx, T[]>();

        public void Add(IntEx key, T value)
        {
            if (_array != null)
            {
                if(!AddToArray(key, value))
                {
                    MoveToDictinary();
                    _array = null;
                    AddToDictionary(key, value);
                }
            }
            else
            {
                AddToDictionary(key, value);
            }
        }

        private bool AddToArray(IntEx key, T value)
        {
            if (_array == null)
            {
                return false;
            }

            int position = key.GetHashCode();

            if (_array.Length > position && _array[position] != null)
            {
                var lastIndex = Array.FindLastIndex(_array, e => e != null);

                position = lastIndex == -1 ? _array.Length : lastIndex + 1;
            }


            if (_array.Length <= position)
            {
                if ((position - _array.Length) > BigGap)
                {
                    return false;
                }
                else
                {
                    Array.Resize(ref _array, _array.Length + BigGap);
                }
            }
            
            _array[position] = new Tuple<IntEx, T>(key, value);
            return true;
        }

        private void MoveToDictinary()
        {
            foreach (var item in _array)
            {
                if (item != null)
                {
                    AddToDictionary(item.Item1, item.Item2);
                }
            }
        }

        private void AddToDictionary(IntEx key, T value)
        {
            if (!_dictionary.ContainsKey(key))
            {
                _dictionary.Add(key, new[] { value });
                return;
            }

            var keyValues = _dictionary[key];
            Array.Resize(ref keyValues, keyValues.Length + 1);
            keyValues[keyValues.Length - 1] = value;
            _dictionary[key] = keyValues;
        }
    }
}
