using Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle
{
    public class Problem :IProblem
    {
        State startState;
        State endState;

        public Problem ( State start, State end)
        {
            this.startState = start;
            this.endState = end;
        }

        public IState InitialState()
        {
            return startState;
        }

        public bool GoalStateReached(IState state)
        {
            State _state = state as State;

            for (int i = 0; i < _state.PuzzleState.Length; i++)
            {
                if (_state.PuzzleState[i] != endState.PuzzleState[i])
                    return false;
            }
            return true;
        }

        public IEnumerable<IState> Successor(IState state)
        {
            State _s = state as State;
            int _poz0 = _s.Find(0);
            List<State> N = new List<State>();

            if(_poz0 != Int32.MaxValue)
            {
                if (_poz0 - _s.N >= 0)
                    N.Add(_s.ReplaceTwoValue(_poz0, _poz0 - _s.N));
                if(_poz0+_s.N < _s.N*_s.N) 
                    N.Add(_s.ReplaceTwoValue(_poz0, _poz0 + _s.N));
                if (_poz0 % _s.N != 0)
                    N.Add(_s.ReplaceTwoValue(_poz0, _poz0 - 1));
                if (_poz0 % _s.N != _s.N-1)
                    N.Add(_s.ReplaceTwoValue(_poz0, _poz0 +1));
            }
            else
            {
                Console.WriteLine("ni ma 0  w tablicy");
            }
            return N as IEnumerable<IState>;
        }
    }
}
