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

            //startState.PuzzleState[0] = 1;
            //startState.PuzzleState[1] = 6;
            //startState.PuzzleState[2] = 2;
            //startState.PuzzleState[3] = 5;
            //startState.PuzzleState[4] = 7;
            //startState.PuzzleState[5] = 0;
            //startState.PuzzleState[6] = 4;
            //startState.PuzzleState[7] = 8;
            //startState.PuzzleState[8] = 3;

            //startState.PuzzleState[0] = 0;  **
            //startState.PuzzleState[1] = 6;
            //startState.PuzzleState[2] = 2;
            //startState.PuzzleState[3] = 1;
            //startState.PuzzleState[4] = 5;
            //startState.PuzzleState[5] = 7;
            //startState.PuzzleState[6] = 4;
            //startState.PuzzleState[7] = 8;
            //startState.PuzzleState[8] = 3;

            //startState.PuzzleState[0] = 6;
            //startState.PuzzleState[1] = 0;
            //startState.PuzzleState[2] = 2;
            //startState.PuzzleState[3] = 1;
            //startState.PuzzleState[4] = 5;
            //startState.PuzzleState[5] = 7;
            //startState.PuzzleState[6] = 4;
            //startState.PuzzleState[7] = 8;
            //startState.PuzzleState[8] = 3;

            startState.PuzzleState[0] = 1;
            startState.PuzzleState[1] = 2;
            startState.PuzzleState[2] = 3;
            startState.PuzzleState[3] = 0;
            startState.PuzzleState[4] = 5;
            startState.PuzzleState[5] = 6;
            startState.PuzzleState[6] = 4;
            startState.PuzzleState[7] = 7;
            startState.PuzzleState[8] = 8;

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
            FringeFifo<Node> fifo = new FringeFifo<Node>();
            FringeLifo<Node> lifo = new FringeLifo<Node>();

            //GenerateResult(P, fifo);
            //GenerateResult(P, lifo);


            //1) liczba kostek nie na swoim miejscu 2)odl. Manhatan
            Func<Node, int> function = delegate(Node n)
            {
                return 1; 
            };

            Heap3<Node, int> heap = new Heap3<Node, int>(function);

            GenerateResult(P, heap);
            
            Console.ReadLine();
        }

        private static void GenerateResult(IProblem P, IFringe<Node> F)
        {
            Fringe<Node> _f = new Fringe<Node>(F);

            TreeSearchWithQueue treeSearchWithQueue = new TreeSearchWithQueue();

            Console.WriteLine("Wait...");

            var result = treeSearchWithQueue.Search(P, _f).Reverse();
            foreach (var state in result)
            {
                State _state = state as State;
                Console.WriteLine(_state.ToString());
            }

            Console.WriteLine("Count: {0}", _f.Counter);
            Console.WriteLine("Done...");
        }
    }
}
