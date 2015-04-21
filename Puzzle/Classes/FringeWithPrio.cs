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
            //if (this.list.Count > 0)
            //{
            //    bool isSet = false;
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        if (Key(node).CompareTo(Key(list[i])) > 0)
            //        {
            //            list.Insert(i, node);
            //            isSet = true;
            //            break;
            //        }
            //    }
            //    if (!isSet)
            //    {
            //        list.Add(node);
            //    }
            //}
            //else
            //{
            //    list.Add(node);
            //}

            if(this.list.Count>0)
            {
                int first = 0;
                int last = this.list.Count - 1;
                int length = 0;
                int index = 0;
                bool isSet = false;
                var key = Key(node);

                do
                {
                    length = Math.Abs(first - last) + 1;
                    index = first + length / 2;
                    var keyIndex = Key(list[index]);

                    if (key.CompareTo(keyIndex) == 0)
                    {
                        list.Insert(index, node);
                        isSet = true;
                    }
                    else if (key.CompareTo(keyIndex) > 0)
                    {
                        //left
                        last = index;
                    }
                    else
                    {
                        //right
                        first = index;
                    }
                } while (isSet == false && length > 2);

                if(isSet==false)
                {
                    list.Insert(index, node);
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
