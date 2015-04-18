using Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle
{
    class FringeWithPrio<T, K> : IFringe<T>
        where K : IComparable<K>
    {
        public Func<T, K> Key;
        private List<T> list = new List<T>();

        public FringeWithPrio(Func<T, K> _key)
        {
            Key = _key;
        }

        public T UploadState()
        {
            T node;
            node = list.First();
            list.RemoveAt(0);

            return node;
        }

        public void Add(T node)
        {
            if (this.list.Count > 0)
            {
                bool isSet = false;
                for (int i = 0; i < list.Count; i++)
                {
                    if (Key(node).CompareTo(Key(list[i])) > 0)
                    {
                        list.Insert(i, node);
                        isSet = true;
                        break;
                    }
                }
                if(!isSet)
                {
                    list.Add(node);
                }
            }
            else
            {
                list.Add(node);
            }
        }

        public bool EmptyFringe()
        {
            if (!list.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
