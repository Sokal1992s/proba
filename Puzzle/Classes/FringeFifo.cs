using Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle
{
    public class FringeFifo<T> :IFringe<T>
    {
        Queue<T> list = new Queue<T>();
        

        public void Add(T node)
        {
            list.Enqueue(node);
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
            return list.Dequeue();
        }
    }
}
