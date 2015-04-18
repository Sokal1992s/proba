using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Search;
using System.Diagnostics;

namespace Puzzle
{
    class Program
    {
        static State startState = new State();
        static State endState = new State();

        static List<string> addCounter = new List<string>();
        static List<string> executionTime = new List<string>();
        static List<string> label = new List<string>();

        static void Main(string[] args)
        {
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

            startState.PuzzleState[0] = 0;   //**
            startState.PuzzleState[1] = 6;
            startState.PuzzleState[2] = 2;
            startState.PuzzleState[3] = 1;
            startState.PuzzleState[4] = 5;
            startState.PuzzleState[5] = 7;
            startState.PuzzleState[6] = 4;
            startState.PuzzleState[7] = 8;
            startState.PuzzleState[8] = 3;

            //startState.PuzzleState[0] = 6;
            //startState.PuzzleState[1] = 0;
            //startState.PuzzleState[2] = 2;
            //startState.PuzzleState[3] = 1;
            //startState.PuzzleState[4] = 5;
            //startState.PuzzleState[5] = 7;
            //startState.PuzzleState[6] = 4;
            //startState.PuzzleState[7] = 8;
            //startState.PuzzleState[8] = 3;

            //startState.PuzzleState[0] = 1;
            //startState.PuzzleState[1] = 2;
            //startState.PuzzleState[2] = 3;
            //startState.PuzzleState[3] = 0;
            //startState.PuzzleState[4] = 5;
            //startState.PuzzleState[5] = 6;
            //startState.PuzzleState[6] = 4;
            //startState.PuzzleState[7] = 7;
            //startState.PuzzleState[8] = 8;

            for (int i = 0; i < 8; i++)
                endState.PuzzleState[i] = i + 1;
            endState.PuzzleState[8] = 0;

            //startState.PuzzleState[0] = 4;
            //startState.PuzzleState[1] = 0;
            //startState.PuzzleState[2] = 2;
            //startState.PuzzleState[3] = 1;
            //startState.PuzzleState[4] = 3;
            //startState.PuzzleState[5] = 5;
            //startState.PuzzleState[6] = 6;
            //startState.PuzzleState[7] = 7;
            //startState.PuzzleState[8] = 8;

            //for (int i = 0; i < 9; i++)
            //    endState.PuzzleState[i] = i;

            Problem P = new Problem(startState, endState);

            //breadth-first search - szukanie wszerz
            GenerateResult(P, new FringeFifo<Node>(), "fifo");

            //depth-first search - szukanie w głąb 
            //GenerateResult(P, new FringeLifo<Node>(), "lifo");

            Func<Node, int> function1 = funcNumberOfElement;
            Func<Node, int> function2 = funcManhattanDistance;

            //GenerateResult(P, new FringeWithPrio<Node, int>(function1), "prio1");
            //GenerateResult(P, new FringeWithPrio<Node, int>(function2), "prio2");


            Heap3<Node, int> heap1 = new Heap3<Node, int>(function1);
            GenerateResult(P, heap1, "num of element");
            Heap3<Node, int> heap2 = new Heap3<Node, int>(function2);
            GenerateResult(P, heap2, "Manhattan dist");


            label.Insert(0, "");
            foreach (string s in label)
            {
                Console.Write(string.Format("{0,15}", s));
            }
            Console.WriteLine();

            Console.Write(string.Format("{0,15}","Add counter:"));
            foreach(string s in addCounter)
            {
                Console.Write(string.Format("{0,15}",s));
            }
            Console.WriteLine();

            Console.Write(string.Format("{0,15}","Execution time:"));
            foreach (string s in executionTime)
            {
                Console.Write(string.Format("{0,15}",s));
            }

            Console.ReadLine();
        }

        private static void GenerateResult(IProblem P, IFringe<Node> F,string title)
        {
            Fringe<Node> _f = new Fringe<Node>(F);

            TreeSearchWithQueue treeSearchWithQueue = new TreeSearchWithQueue();

            Console.WriteLine("Wait...");

            var watch = Stopwatch.StartNew();
            var result = treeSearchWithQueue.Search(P, _f).Reverse();
            watch.Stop();

            foreach (var state in result)
            {
                State _state = state as State;
                Console.WriteLine(_state.ToString());
            }

            //Console.WriteLine("Add function counter: {0}", _f.Counter);
            addCounter.Add(_f.Counter.ToString());
            //Console.WriteLine("Execution time: {0}ms", watch.ElapsedMilliseconds);
            executionTime.Add(watch.ElapsedMilliseconds.ToString());
            label.Add(title);
            
            Console.WriteLine("Done...");
        }

        private static int funcManhattanDistance(Node n)
        {
            var state = n.State as State;
            int totalWeight = 0;

            int maxDistance = 2 * (state.N - 1);

            for (int i = 0; i < state.PuzzleState.Length; i++)
            {
                int weight = maxDistance;

                int xp = i / state.N;
                int yp = i % state.N;

                int j = endState.Find(state.PuzzleState[i]);
                int xk = j / state.N;
                int yk = j % state.N;

                weight -= Math.Abs(xp - xk) + Math.Abs(yp - yk);
                totalWeight += weight;
            }

            return totalWeight;
        }

        private static int funcNumberOfElement(Node n)
        {
            int weight=0;

            var state = n.State as State;
            for (int i = 0; i < state.PuzzleState.Length; i++)
            {
                if (state.PuzzleState[i] == endState.PuzzleState[i])
                    weight++;
            }

            return weight;
        }
    }
}
