using Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle
{
    class Fringe<T> : IFringe<T>
    {
        IFringe<T> fringe;
        public int counter;
        public int Counter
        {
            get
            {
                return counter;
            }
        }

        public Fringe(IFringe<T> Fringe)
        {
            this.counter = 0;
            this.fringe = Fringe;

        }

        public void Add(T node)
        {
            counter++;
            fringe.Add(node);

        }

        public bool EmptyFringe()
        {
            return fringe.EmptyFringe();
        }

        public T UploadState()
        {
            return fringe.UploadState();
        }
    }
}
