using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public class Node
    {
        #region Fields

        IState state;
        Node parent;

        #endregion

        #region Propertis
        public IState State
        {
            get
            {
                return state;
            }
        }
        public Node Parent
        {
            get
            {
                return parent;
            }
        }

        #endregion

        #region Constructors
        public Node()
        {
            state = null;
            parent = null;
        }
        public Node(IState state, Node parent)
        {
            this.state = state;
            this.parent = parent;
        }

        #endregion

    }
}
