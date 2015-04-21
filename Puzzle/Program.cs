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

        static string[] addCounter = new string[6] {"", "", "", "", "", ""};
        static string[] executionTime = new string[6] { "", "", "", "", "", "" };
        static string[] wayLength = new string[6] { "", "", "", "", "", "" };
        static string[] label = new string[6] { "", "", "", "", "", "" };

        static void Main(string[] args)
        {
            for (int i = 0; i < 8; i++)
                endState.PuzzleState[i] = i + 1;
            endState.PuzzleState[8] = 0;

            startState.PuzzleState[0] = 4;
            startState.PuzzleState[1] = 1;
            startState.PuzzleState[2] = 0;
            startState.PuzzleState[3] = 7;
            startState.PuzzleState[4] = 6;
            startState.PuzzleState[5] = 5;
            startState.PuzzleState[6] = 2;
            startState.PuzzleState[7] = 3;
            startState.PuzzleState[8] = 8;

            Count("from: 410765238 to: 12345670");
            ShowStatistics();

            startState.PuzzleState[0] = 1;
            startState.PuzzleState[1] = 6;
            startState.PuzzleState[2] = 2;
            startState.PuzzleState[3] = 5;
            startState.PuzzleState[4] = 7;
            startState.PuzzleState[5] = 0;
            startState.PuzzleState[6] = 4;
            startState.PuzzleState[7] = 8;
            startState.PuzzleState[8] = 3;

            Count("from: 162570483 to: 12345670");
            ShowStatistics();

            startState.PuzzleState[0] = 0; 
            startState.PuzzleState[1] = 6;
            startState.PuzzleState[2] = 2;
            startState.PuzzleState[3] = 1;
            startState.PuzzleState[4] = 5;
            startState.PuzzleState[5] = 7;
            startState.PuzzleState[6] = 4;
            startState.PuzzleState[7] = 8;
            startState.PuzzleState[8] = 3;

            Count("from: 062157483 to: 12345670");
            ShowStatistics();

            startState.PuzzleState[0] = 6;
            startState.PuzzleState[1] = 0;
            startState.PuzzleState[2] = 2;
            startState.PuzzleState[3] = 1;
            startState.PuzzleState[4] = 5;
            startState.PuzzleState[5] = 7;
            startState.PuzzleState[6] = 4;
            startState.PuzzleState[7] = 8;
            startState.PuzzleState[8] = 3;

            Count("from: 602157483 to: 12345670");
            ShowStatistics();

            startState.PuzzleState[0] = 1;
            startState.PuzzleState[1] = 2;
            startState.PuzzleState[2] = 3;
            startState.PuzzleState[3] = 0;
            startState.PuzzleState[4] = 5;
            startState.PuzzleState[5] = 6;
            startState.PuzzleState[6] = 4;
            startState.PuzzleState[7] = 7;
            startState.PuzzleState[8] = 8;

            Count("from: 123056478 to: 12345670");
            ShowStatistics();

            startState.PuzzleState[0] = 4;
            startState.PuzzleState[1] = 0;
            startState.PuzzleState[2] = 2;
            startState.PuzzleState[3] = 1;
            startState.PuzzleState[4] = 3;
            startState.PuzzleState[5] = 5;
            startState.PuzzleState[6] = 6;
            startState.PuzzleState[7] = 7;
            startState.PuzzleState[8] = 8;

            for (int i = 0; i < 9; i++)
                endState.PuzzleState[i] = i;

            Count("from: 402135678 to: 01234567");
            ShowStatistics();

            Console.ReadLine();
        }

        private static void Count(string text)
        {
            Console.WriteLine("Wait... {0}",text);

            Problem P = new Problem(startState, endState);

            //breadth-first search - szukanie wszerz
            GenerateResult(P, new FringeFifo<Node>(), 0, "fifo");

            //depth-first search - szukanie w głąb 
            GenerateResult(P, new FringeLifo<Node>(), 1, "lifo");

            Func<Node, int> function1 = funcNumberOfElement;
            Func<Node, int> function2 = funcManhattanDistance;

            GenerateResult(P, new FringeWithPrio<Node, int>(function1), 2, "list with prio + h1");
            GenerateResult(P, new FringeWithPrio<Node, int>(function2), 3, "list with prio + h2");

            GenerateResult(P, new Heap3<Node, int>(function1), 4, "heap + h1");
            GenerateResult(P, new Heap3<Node, int>(function2), 5, "heap + h2");

            Console.WriteLine("Done...");
        }


        private static void ShowStatistics()
        {
            Console.Write(string.Format("{0,20}", ""));
            Console.Write(string.Format("{0,20}", "Add counter"));
            Console.Write(string.Format("{0,20}", "Execution time"));
            Console.WriteLine(string.Format("{0,20}", "Way length"));

            for (int i = 0; i < 6; i++)
            {
                Console.Write(string.Format("{0,20}", label[i]));
                Console.Write(string.Format("{0,20}", addCounter[i]));
                Console.Write(string.Format("{0,20}", executionTime[i]));
                Console.WriteLine(string.Format("{0,20}", wayLength[i]));
            }

            Console.WriteLine();
            Console.WriteLine("\th1- number of elements");
            Console.WriteLine("\th2- Manhattan distance");
            Console.WriteLine();
        }

        private static void GenerateResult(IProblem P, IFringe<Node> F,int i,string title)
        {
            Fringe<Node> _f = new Fringe<Node>(F);

            TreeSearchWithQueue treeSearchWithQueue = new TreeSearchWithQueue();

            var watch = Stopwatch.StartNew();
            var result = treeSearchWithQueue.Search(P, _f).Reverse();
            watch.Stop();

            int wayCounter = 0;
            foreach (var state in result)
            {
                //State _state = state as State;
                //Console.WriteLine(_state.ToString());
                wayCounter++;
            }

            label[i] = title;
            addCounter[i] = _f.Counter.ToString();
            executionTime[i]=watch.ElapsedMilliseconds.ToString();
            wayLength[i] = wayCounter.ToString();

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
