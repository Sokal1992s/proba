using Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle
{
    public class FringeLifo : IFringe
    {
        List<Node> list = new List<Node>();

        public void Add(Node node)
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

        public Node UploadState()
        {
            Node node;

            node = list.First();
            list.RemoveAt(0);

            return node;
        }
    }
}
