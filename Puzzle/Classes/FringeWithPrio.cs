using Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle
{
    class FringeWithPrio
    {
        List<Node> list = new List<Node>();

        public void Add(Node node)
        {
            list.Add(node);
            
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

        public Node UploadState()
        {
            Node node;

            node = list.First();
            list.RemoveAt(0);

            return node;

        }
    }
}
