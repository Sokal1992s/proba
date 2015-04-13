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
        //List<Node> list = new List<Node>();
        Queue<T> list = new Queue<T>();

        public void Add(T node)
        {
            //list.Add(node);
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
            //Node node;

            //node = list.First();
            //list.RemoveAt(0);

            //return node;
            return list.Dequeue();
        }
    }
}
