using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Search;

namespace Puzzle
{

    using HeapElement = Tuple<int, Node>;

    public class Heap
    {
        public IList<HeapElement> data;
        public int HeapSize;

        public Heap()
        {
            data = new List<HeapElement>();
            // dodaję zerowy element ponieważ zaczynamy wypełniać tablicę od indeksu 1
            data.Add(new HeapElement(0, null));
        }

        private void Swap(int index0, int index1)
        {
            HeapElement aux = data[index0];
            data[index0] = data[index1];
            data[index1] = aux;
        }

        public void Insert(int n, Node node)
        {
            HeapElement he = new HeapElement(n, node);
            HeapSize++;
            data.Add(he);
            //data[HeapSize] == n;
            int Index = HeapSize;
            while (Index > 1)
            {
                if (n > data[Index / 2].Item1)
                    Swap(Index, Index / 2);
                else
                    break;
                Index = Index / 2;
            }
        }

        public void MoveDownHeap(int topIndex)
        {
            int index = topIndex;
            HeapElement n = data[topIndex];
            while (index * 2 <= HeapSize)
            {
                int indexGreater;
                if ((index * 2 < HeapSize) && (data[index * 2 + 1].Item1 > data[index * 2].Item1))
                    indexGreater = index * 2 + 1;
                else
                    indexGreater = index * 2;
                if (n.Item1 < data[indexGreater].Item1)
                    Swap(index, indexGreater);
                else
                    break;
                index = indexGreater;
            }
        }

        public void DeleteMax()
        {
            data[1] = data[HeapSize];
            data.RemoveAt(HeapSize);
            HeapSize--;
            MoveDownHeap(1);
        }

        public void Construct(int index)
        {
            if (2 * index <= HeapSize / 2)
                Construct(2 * index);
            if (2 * index + 1 <= HeapSize / 2)
                Construct(2 * index + 1);
            MoveDownHeap(index);
        }

        public void Check()
        {
            for (int i = 1; i <= HeapSize / 2; i++)
            {
                if (data[i].Item1 < data[2 * i].Item1)
                    throw new Exception("Error in Heap");
                if (2 * i + 1 <= HeapSize)
                    if (data[i].Item1 < data[2 * i + 1].Item1)
                        throw new Exception("Error in Heap");
            }
        }
        public int Max()
        {
            return data[1].Item1;
        }
    }
}