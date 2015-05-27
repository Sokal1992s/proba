using Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//jakis komentrz,a
namespace Puzzle
{
    public class FringeLifo<T> : IFringe<T>
    {
        Stack<T> stack = new Stack<T>();

        public void Add(T node)
        {
            stack.Push(node);
        }

        public bool EmptyFringe()
        {
            if (!stack.Any())
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
            return stack.Pop();
        }
    }
}
