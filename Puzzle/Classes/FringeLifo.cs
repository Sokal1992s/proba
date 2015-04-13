using Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle
{
    public class FringeLifo<T> : IFringe<T>
    {
        List<T> list = new List<T>();

        public void Add(T node)
        {
            list.Insert(0, node);
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

        public T UploadState()
        {
            T node;

            node = list.First();
            list.RemoveAt(0);

            return node;
        }
    }
}
