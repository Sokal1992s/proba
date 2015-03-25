using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Search;

namespace Puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            State startState = new State();

            //for (int i = 0; i < 9; i++)
            //    startState.PuzzleState[i] = i;
            //to sie liczy długo..
            //startState.PuzzleState[0] = 4;
            //startState.PuzzleState[1] = 1;
            //startState.PuzzleState[2] = 0;
            //startState.PuzzleState[3] = 7;
            //startState.PuzzleState[4] = 6;
            //startState.PuzzleState[5] = 5;
            //startState.PuzzleState[6] = 2;
            //startState.PuzzleState[7] = 3;
            //startState.PuzzleState[8] = 8;

            startState.PuzzleState[0] = 1;
            startState.PuzzleState[1] = 6;
            startState.PuzzleState[2] = 0;
            startState.PuzzleState[3] = 5;
            startState.PuzzleState[4] = 7;
            startState.PuzzleState[5] = 2;
            startState.PuzzleState[6] = 4;
            startState.PuzzleState[7] = 8;
            startState.PuzzleState[8] = 3;

            State endState = new State();
            //for (int i = 0; i < 9; i++)
            //    endState.PuzzleState[i] = i;
            endState.PuzzleState[0] = 1;
            endState.PuzzleState[1] = 2;
            endState.PuzzleState[2] = 3;
            endState.PuzzleState[3] = 4;
            endState.PuzzleState[4] = 5;
            endState.PuzzleState[5] = 6;
            endState.PuzzleState[6] = 7;
            endState.PuzzleState[7] = 8;
            endState.PuzzleState[8] = 0;

            Problem P = new Problem(startState, endState);
            FringeFifo F = new FringeFifo();
            
            TreeSearchWithQueue treeSearchWithQueue=new TreeSearchWithQueue();

            Console.WriteLine("Wait...");

            var result = treeSearchWithQueue.Search(P, F);
            foreach (var state in result)
            {
                State _state = state as State;
                Console.WriteLine(_state.ToString());
            }

            Console.WriteLine("Done...");
            Console.ReadLine();

        }
    }
}
