using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapBuilder
{
    class Program
    {
        static StringBuilder swaps = new StringBuilder();
        static int swapsNumber = 0;

        static void Main(string[] args)
        {
            int sizeOfTheArray = int.Parse(Console.ReadLine());
            int[] nums = new int[sizeOfTheArray];
            int index = 0;
            foreach(string s in Console.ReadLine().Split())
            {
                nums[index] = int.Parse(s);
                index += 1;
            }

            BuildHeap(nums);
            Console.WriteLine(swapsNumber);
            if (swapsNumber != 0)
                Console.WriteLine(swaps);                
            Console.ReadLine();
        }

        static int LeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        static int RightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        static void Swap(int[] array, int firstIndex, int secondIndex)
        {
            int temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
            swapsNumber += 1;
            swaps.Append(String.Format("{0} {1}\n", firstIndex, secondIndex));
        }

        static void SiftDown(int[] array, int index)
        {
            int minValue = array[index];
            int swapIndex = index;

            int leftChildIndex = LeftChildIndex(index);
            if (leftChildIndex < array.Length && minValue >= array[leftChildIndex])
            {
                swapIndex = leftChildIndex;
                minValue = array[leftChildIndex];
            }               

            int rightChildIndex = RightChildIndex(index);
            if (rightChildIndex < array.Length && minValue >= array[rightChildIndex])
                swapIndex = rightChildIndex;

            if (swapIndex != index)
            {
                Swap(array, index, swapIndex);
                SiftDown(array, swapIndex);
            }
                
        }

        static void BuildHeap(int[] array)
        {
            for (int index = array.Length / 2; index >= 0; index--)
            {
                SiftDown(array, index);
            }
        }
    }
}
