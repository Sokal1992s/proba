using Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle
{
    class Fringe : IFringe
    {
        IFringe fringe;
        public int counter;
        public int Counter
        {
            get
            {
                return counter;
            }
        }

        public Fringe(IFringe Fringe)
        {
            this.counter = 0;
            this.fringe = Fringe;

        }

        public void Add(Node node)
        {
            counter++;
            fringe.Add(node);

        }

        public bool EmptyFringe()
        {
            return fringe.EmptyFringe();
        }

        public Node UploadState()
        {
            return fringe.UploadState();
        }
    }
}
