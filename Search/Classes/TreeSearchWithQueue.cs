using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public class TreeSearchWithQueue
    {
        public IEnumerable<IState> Search(IProblem P, IFringe F)
        {
            F.Add(new Node(P.InitialState(), null));
            while (!F.EmptyFringe())
            {
                Node node = F.UploadState();
                if (P.GoalStateReached(node.State))
                {
                    return Predecessors(node);
                }
                IEnumerable<IState> successors = P.Successor(node.State); //as List<IState>
                AddUnvisited(successors, node, F);
            }
            IEnumerable<IState> _null = new List<IState>();
            return _null;
        }

        static List<IState> Predecessors(Node node)
        {
            List<IState> result = new List<IState>();
            while (node != null)
            {
                result.Add(node.State);
                node = node.Parent;
            }
            return result;
        }

        void AddUnvisited(IEnumerable<IState> successors, Node node, IFringe F)
        {
            if (successors == null)
                return;
            foreach (var nextState in successors)
            {
                if (!Visited(node, nextState))
                {
                    F.Add(new Node(nextState, node));
                }
            }
        }

        private bool Visited(Node node, IState nextState)
        {
            while (node != null)
            {
                if (node.State == nextState)
                    return true;
                node = node.Parent;
            }
            return false;

        }
    }
}
