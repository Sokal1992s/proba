using Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle
{
    public class State : IState
    {
        const int n = 3;

        public int[] PuzzleState;
        public int N
        {
            get
            {
                return n;
            }
        }

        public State()
        {
            this.PuzzleState = new int[n * n];
        }

        public int Find (int value)
        {
            for (int i = 0; i < PuzzleState.Length; i++)
            {
                if (PuzzleState[i] == value)
                    return i;
            }
            return Int32.MaxValue;
        }

        public State ReplaceTwoValue(int index1, int index2)
        {
            State _state = new State();
            for(int i=0; i< this.PuzzleState.Length;i++)
            {
                _state.PuzzleState[i] = this.PuzzleState[i];
            }
            _state.PuzzleState[index1] = this.PuzzleState[index2];
            _state.PuzzleState[index2] = this.PuzzleState[index1];
            return _state;
        }

        public override string ToString()
        {
            string result = "";
            for(int i=0; i< this.N*this.N; i++)
            {
                result += this.PuzzleState[i].ToString();
            }
            return result;
        }
    }
}
