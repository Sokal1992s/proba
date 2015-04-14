using Search;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzle
{
    public class Heap3<T, K> :IFringe<T>
        where K : IComparable<K>
    {
        public Func<T, K> Key;          
        private List<T> list = new List<T>();

        public Heap3(Func<T, K> _key)
        {
            Key = _key;
        }

        public T UploadState()
        {
            var element = list.First();

            this.list[0] = this.list[this.list.Count - 1];
            this.list.RemoveAt(this.list.Count - 1);
            this.ShiftDown(0);                         

            return element;
        }

        public void Add(T element)
        {
            this.list.Add(element);
            this.ShiftUp(this.list.Count - 1);

            //if(this.list.Count-1 != 0)
            //{
            //    this.ShiftUp(this.list.Count - 1);
            //}
            
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

        private void ShiftDown(int child)
        {
            int parent;
            do
            {
                parent = child; 
                try
                {
                    if (2 * parent + 1 < list.Count && Key(list[2 * parent + 1]).CompareTo(Key(list[child])) > 0)
                        child = 2 * parent + 1;
                    if (2 * parent < list.Count && Key(list[2 * parent + 2]).CompareTo(Key(list[child])) > 0)
                        child = 2 * parent + 2;
                    T tmp = list[parent];
                    list[parent] = list[child];
                    list[child] = tmp;
                }
                catch 
                { }
                
            } while (parent != child);
        }

        private void ShiftUp(int child)
        {
            int parent;
            do
            {
                if (child % 2 == 0)
                    //parent = (child / 2) + 1;
                    parent = child / 2;
                else
                    //parent = child / 2;
                    parent = (child / 2) + 1;
                if (Key(this.list[child]).CompareTo(Key(this.list[parent])) > 0)
                {
                    T tmp_parent = list[parent];
                    T tmp_child = list[child];
                    list[child] = tmp_parent;
                    list[parent] = tmp_child;
                    child = parent;
                }
                else
                {
                    child = 0;
                }
            } while (child !=0 && child==parent);

        }

    }
}
