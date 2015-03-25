using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public interface IProblem
    {
        IState InitialState();                           //return the initial state
        bool GoalStateReached(IState state);             //if (a goal state reached) {return true} else {return falese} 
        IEnumerable<IState> Successor(IState state);     //return next states
    }
}
