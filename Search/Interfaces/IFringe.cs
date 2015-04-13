using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public interface IFringe<T>
    {
        void Add(T node);      // Add state to the fringe
        bool EmptyFringe();        // if (fringe is empty) {return true} else {reurn false}
        T UploadState();        // return state and its parent; remove state from the fringe
    }
}
