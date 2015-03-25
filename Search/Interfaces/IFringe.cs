using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public interface IFringe
    {
        void Add(Node node);      // Add state to the fringe
        bool EmptyFringe();        // if (fringe is empty) {return true} else {reurn false}
        Node UploadState();        // return state and its parent; remove state from the fringe
    }
}
