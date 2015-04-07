using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzle
{
    public class Heap<Key, Value>
        where Key : IComparable<Key>
        where Value : class
    {

        Func<Value, Key> GenerateKeyFunction;
        List<Value> Nodes;

        public Heap(Func<Value, Key> GenerateKeyFunction)
        {
            this.GenerateKeyFunction = GenerateKeyFunction;
            Nodes = new List<Value>();
        }

        public void AddToHeap(Value NewHeapElement)
        {
            Nodes.Add(NewHeapElement);
            ShiftUpValue(Nodes.Count - 1);

        }

        public Value GetFromHeap()
        {
            if (Nodes.Count == 0)
                return null;
            return GetHeapFirstElement();

        }

        private Value GetHeapFirstElement()
        {
            Value HeapFirstElement = Nodes.First();
            Nodes[0] = Nodes.Last();
            Nodes.RemoveAt(Nodes.Count);
            ShiftDownValue(0);
            return HeapFirstElement;
        }

        private void ShiftUpValue(int ElementIndex)
        {
            int ParentIndex;
            int ElementToSwapIndex;
            do
            {
                ParentIndex = GetParentIndex(ElementIndex);
                ElementToSwapIndex = ParentIndex;
                if (IsLeftNodeValueHigher(ParentIndex))
                    ElementToSwapIndex = GenerateLeftNodeIndex(ParentIndex);
                if (IsRightNodeValueHigher(ElementIndex))
                    ElementToSwapIndex = GenerateRightNodeIndex(ParentIndex);
                if (WereChanges(ElementToSwapIndex, ParentIndex))
                {
                    SwapElements(ParentIndex, ElementToSwapIndex);
                    ElementIndex = ParentIndex;
                }
            } while (ParentIndex != 0 || ElementToSwapIndex != ParentIndex);
        }

        private int GenerateRightNodeIndex(int parentIndex)
        {
            return parentIndex * 2 + 2;
        }

        private int GenerateLeftNodeIndex(int parentIndex)
        {
            return parentIndex * 2 + 1;
        }

        private int GetParentIndex(int elementIndex)
        {
            return elementIndex % 2 != 0 ? elementIndex / 2 : (elementIndex / 2) - 1;
        }

        private void ShiftDownValue(int ElementIndex)
        {
            int ParentIndex;
            do
            {
                ParentIndex = ElementIndex;
                if (IsLeftNodeValueHigher(ParentIndex))
                    ElementIndex = GenerateLeftNodeIndex(ParentIndex);
                if (IsRightNodeValueHigher(ParentIndex))
                    ElementIndex = GenerateRightNodeIndex(ParentIndex);
                if (WereChanges(ElementIndex, ParentIndex))
                    SwapElements(ParentIndex, ElementIndex);


            } while (ParentIndex != ElementIndex);
        }

        private void SwapElements(int parentIndex, int elementIndex)
        {
            Value ParentValue = Nodes[parentIndex];
            Nodes[parentIndex] = Nodes[elementIndex];
            Nodes[elementIndex] = ParentValue;
        }

        private bool WereChanges(int elementIndex, int parentIndex)
        {
            return elementIndex != parentIndex;
        }

        private bool IsRightNodeValueHigher(int parentIndex)
        {
            if (parentIndex * 2 + 2 < Nodes.Count - 1 && GenerateKeyFunction(Nodes[2 * parentIndex + 2]).CompareTo(GenerateKeyFunction(Nodes[parentIndex])) > 0)
                return true;
            return false;
        }

        private bool IsLeftNodeValueHigher(int parentIndex)
        {

            if (parentIndex * 2 + 1 < Nodes.Count - 1 && GenerateKeyFunction(Nodes[2 * parentIndex + 1]).CompareTo(GenerateKeyFunction(Nodes[parentIndex])) > 0)
                return true;
            return false;

        }
    }
}