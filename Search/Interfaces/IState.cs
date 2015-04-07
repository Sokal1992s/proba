using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public interface IState
    {
        bool IsEqual(IState state);
    }
}
