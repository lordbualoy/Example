#define LOG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonSortingAlgorithm
{
    class HeapSort
    {
        public static void Sort(int[] input)
        {
#if LOG
            Console.WriteLine("Initial Input");
            Console.WriteLine(DrawHeap(input)); Console.ReadKey(false);
#endif

            //Build Initial Binary Heap
            int heapSize = input.Length;
            int i;
            for (i = heapSize / 2 - 1; i >= 0; i--)
                RecursiveMaxBinaryHeapify(input, heapSize, i);

#if LOG
            Console.WriteLine("Max Heap is built"); Console.ReadKey(false);
#endif

            do
            {
                i = heapSize - 1;
                if (input[i] != input[0])
                    Swap(ref input[i], ref input[0]);
#if LOG
                Console.WriteLine(DrawHeap(input, heapSize)); Console.ReadKey(false);
#endif
                RecursiveMaxBinaryHeapify(input, --heapSize, 0);
            } while (i > 1);
#if LOG
            Console.WriteLine("Finished");
            Console.WriteLine(string.Join(",", input));
            Console.ReadKey(false);
#endif
        }

        static void RecursiveMaxBinaryHeapify(int[] input, int heapSize, int index)
        {
            int leftChildIndex = LeftChildIndex(index);
            int rightChildIndex = leftChildIndex + 1;
            int swapIndex = index;
            if (leftChildIndex < heapSize && input[leftChildIndex] > input[index])
                swapIndex = leftChildIndex;
            //if (rightChildIndex < heapSize && input[rightChildIndex] > input[swapIndex])    //Revision 1
            //if (rightChildIndex < heapSize && input[rightChildIndex] >= input[swapIndex])   //Revision 2: additional edge case handling where let say we have a node 10 with child = (20,20) the original conditional logic will choose left child 20 instead of right child; the reason that we need this change is because by the nature of the heap the right side will most of the time had shorter path to the leaf than the left as new node will get appended to the left side first, so in prioritize in swapping to the right we have more or less avoided the swap that could affect a longest path to the leaf
            if (rightChildIndex < heapSize && (input[rightChildIndex] > input[swapIndex] || (input[rightChildIndex] == input[swapIndex] && swapIndex != index)))    //Revision 3: additional edge case handling where in Revision 2 let say we have a node 20 with child = (10,20) in Revision 1 logic the unneeded swap (between 20(parent) and 20(right child)) won't take place, but in Revision 2 logic the unneeded swap (between 20(parent) and 20(right child)) will taken place
                swapIndex = rightChildIndex;
            if (swapIndex != index)
            {
                Swap(ref input[swapIndex], ref input[index]);
#if LOG
                Console.WriteLine(DrawHeap(input, heapSize)); Console.ReadKey(false);
#endif
                RecursiveMaxBinaryHeapify(input, heapSize, swapIndex);
            }
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static int LeftChildIndex(int index) => 2 * index + 1;     //in one-based index the left child of binary heap is equal to 2*index (if index=2, left child will be 4); convert to zero-based index it is 2*(index+1)-1 = 2*index+1 (if index=1, left child will be 3)

        public static string DrawHeap(int[] input, int heapSize = 0)
        {
            if (heapSize == 0) heapSize = input.Length;
            int height = GetHeapHeight(heapSize);
            LineCollection lineCollection = new LineCollection(height);

            if (height > 1)
            {
                CreateLine(height, x => heapSize - 1);
                for (int i = height - 1; i > 1; i--)
                    CreateLine(i, x => (int)Math.Pow(2, x) - 2);
            }
            CreateRootLine();

            return lineCollection.ToString();

            void CreateLine(int level, Func<int, int> getLastNode)
            {
                int lastNodeOfLevel = getLastNode(level);
                int firstNodeOfLevel = GetFirstNodeOfLevel(level);
                //int slotsForFinalHeight = maxLength - minFirstNode;
                //int slotsUsed = arr.Length - minFirstNode;

                Line nodeLine = lineCollection.NodeLines[level - 1];
                Line linkLine = nodeLine.LinkLine;
                Line childLine = GetChildLine(level);

                for (int i = firstNodeOfLevel; i <= lastNodeOfLevel; i++)
                {
                    bool isRightChildOfParent = IsEven(i);
                    int parentIndex = (firstNodeOfLevel - 1) / 2;
                    string node = input[i].ToString();

                    nodeLine.Add(false, new string(' ', GetSpaceBeforeNode()));
                    nodeLine.Add(false, new string(' ', GetSpaceCenterSpaceBetweenLeftAndRightChild(childLine, i)));

                    if (isRightChildOfParent)
                    {
                        linkLine.Add(false, new string(' ', nodeLine.LastLength - linkLine.LastLength));
                        linkLine.Add(false, "\\");
                        nodeLine.Add(false, " ");
                    }

                    nodeLine.Add(true, node);

                    if (!isRightChildOfParent)
                    {
                        linkLine.Add(false, new string(' ', nodeLine.LastLength - linkLine.LastLength));
                        linkLine.Add(false, "/");
                        nodeLine.Add(false, " ");
                    }

                    int GetSpaceBeforeNode()
                    {
                        List<int> spaceCount = new List<int> { 0 };
                        int thisNodeLeftChildIndex = LeftChildIndex(i);
                        bool hasLeftChild = thisNodeLeftChildIndex < heapSize;
                        if (hasLeftChild)
                        {
                            var info = isRightChildOfParent ? childLine[thisNodeLeftChildIndex, SeekCondition.Itself] : childLine[thisNodeLeftChildIndex, SeekCondition.Trailing];
                            spaceCount.Add(info.CumulativeLength - nodeLine.LastLength);
                        }
                        if (isRightChildOfParent)
                        {
                            int parent = input[(i - 1) / 2];
                            spaceCount.Add(parent.ToString().Length);
                        }
                        if (i != firstNodeOfLevel)
                            spaceCount.Add(1);
                        return spaceCount.Max();
                    }
                }
            }
            void CreateRootLine()
            {
                Line nodeLine = lineCollection.NodeLines[0];
                const int leftChildIndex = 1;
                if (leftChildIndex < heapSize)
                {
                    Line childLine = GetChildLine(1);
                    int spaceCount = childLine[leftChildIndex, SeekCondition.Trailing].CumulativeLength - nodeLine.LastLength;
                    spaceCount += GetSpaceCenterSpaceBetweenLeftAndRightChild(childLine, 0);
                    nodeLine.Add(false, new string(' ', spaceCount));
                }
                nodeLine.Add(true, input[0].ToString());
            }
            int GetSpaceCenterSpaceBetweenLeftAndRightChild(Line _childLine, int index)
            {
                int spaceCount = 0;
                int thisNodeLeftChildIndex = LeftChildIndex(index);
                int thisNodeRightChildIndex = thisNodeLeftChildIndex + 1;
                bool hasLeftChild = thisNodeLeftChildIndex < heapSize;
                bool hasRightChild = thisNodeRightChildIndex < heapSize;
                string node = input[index].ToString();
                if (hasLeftChild && hasRightChild)
                {
                    int spaceCalculated = (_childLine[thisNodeRightChildIndex, SeekCondition.Leading].IndexStart ?? 0) - _childLine[thisNodeLeftChildIndex, SeekCondition.Trailing].CumulativeLength;

                    if (node.Length < spaceCalculated)
                    {
                        float centerPos = spaceCalculated / (float)2;
                        double mid = node.ToString().Length / (double)2;
                        spaceCount = (int)Math.Round(centerPos - mid);
                    }
                    else
                        spaceCount = 0;
                }
                return spaceCount;
            }
            Line GetChildLine(int level) => level < height ? lineCollection.NodeLines[level] : null;
        }

        static bool IsEven(int value) => value % 2 == 0;

        /// <summary>
        /// Get Heap height from array.Length
        /// </summary>
        /// <param name="arrayLength"></param>
        /// <returns></returns>
        static int GetHeapHeight(int arrayLength) => (int)Math.Floor(Math.Log(arrayLength, 2)) + 1;

        /// <summary>
        /// Get what is Heap level of given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        static int GetHeapLevel(int index) => GetHeapHeight(index + 1);

        static int GetFirstNodeOfLevel(int level) => (int)Math.Pow(2, level - 1) - 1;

        class LineCollection
        {
            public List<Line> Lines { get; private set; }
            public List<Line> NodeLines { get; private set; }
#if DEBUG
            string Debug { get => ToString(); }
#endif

            public LineCollection(int height)
            {
                var rootLine = new Line(null, 1);
                NodeLines = new List<Line>(height) { rootLine, };
                Lines = new List<Line>(2 * height - 1) { rootLine, };
                for (int i = 2; i <= height; i++)
                {
                    var linkLine = new Line(null, null);
                    var nodeLine = new Line(linkLine, i);

                    Lines.Add(linkLine);
                    Lines.Add(nodeLine);

                    NodeLines.Add(nodeLine);
                }
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                Lines.ForEach(x => sb.AppendLine(x.ToString()));
                return sb.ToString();
            }
        }

        enum SeekCondition
        {
            Itself = 0,
            Leading = 1,
            Trailing = 2,
        }

        class Line
        {
            int? pos;
            List<ContentInfo> contents;
            
            public readonly int Level;
            public readonly int FirstNodeOfLevel;
            public readonly Line LinkLine;

            public int? LastPos { get => pos; }
            public int LastLength { get => pos != null ? pos.Value + 1 : 0; }
            public bool IsLinkLine { get => Level != 1 && LinkLine == null; }

            public Line(Line relatedLinkLine, int? level)
            {
                contents = new List<ContentInfo>();
                if (level == 1 || relatedLinkLine != null)
                {
                    LinkLine = relatedLinkLine;
                    Level = (int)level;
                    FirstNodeOfLevel = GetFirstNodeOfLevel(Level);
                }
            }

            public ContentInfo this[int index, SeekCondition condition]
            {
                get
                {
                    List<ContentInfo> filtered = contents.FindAll(x => x.IsNode);
                    ContentInfo node = filtered[index - FirstNodeOfLevel];
                    if (condition != SeekCondition.Itself)
                    {
                        int internalIndex = contents.IndexOf(node) + (condition == SeekCondition.Trailing ? 1 : -1);
                        node = contents[internalIndex];
                    }
                    return node;
                }
            }

            public void Add(bool isNode, string text)
            {
                PositionInfo positionInfo = AdvancePosition(text);
                contents.Add(new ContentInfo(isNode, text, positionInfo.Start, positionInfo.End));
            }

            PositionInfo AdvancePosition(string text)
            {
                if (text.Length == 0)
                    return new PositionInfo(pos, pos);

                pos = pos != null ? pos + 1 : 0;
                int start = (int)pos;
                pos += text.Length - 1;
                return new PositionInfo(start, pos);
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                contents.ForEach(y => sb.Append(y.Text));
                return sb.ToString();
            }

            struct PositionInfo
            {
                public readonly int? Start;
                public readonly int? End;
                public PositionInfo(int? start, int? end)
                {
                    Start = start;
                    End = end;
                }
            }
        }

        class ContentInfo
        {
            public readonly bool IsNode;
            public readonly string Text;
            public readonly int? IndexStart;
            public readonly int? IndexEnd;
            public int Length { get => (IndexEnd ?? 0) - (IndexStart ?? 0); }
            public int CumulativeLength { get => IndexEnd != null ? IndexEnd.Value + 1 : 0; }

            public ContentInfo(bool node, string text, int? start, int? end)
            {
                IsNode = node;
                Text = text;
                IndexStart = start;
                IndexEnd = end;
            }
        }
    }
}
