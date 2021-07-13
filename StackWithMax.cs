
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackWithMaximumMaintaiance
{
    class ListNode
    {      
        internal ListNode PreviousNode;
        internal int Value { get; set; }

        internal ListNode(ListNode PreviousNode = null, int value = 0)
        {
            this.PreviousNode = PreviousNode;
            this.Value = value;
        }
    }

    class Stack
    {
        private ListNode Top;
        private ListNode Bottom;
        private int theNumberOfElements;

        public Stack() 
        {
            theNumberOfElements = 0;
            Bottom = new ListNode(); 
            Top = Bottom;
        }

        public void Push (int Key)
        {
            Top = new ListNode(Top, Key);
            theNumberOfElements += 1;
        }

        public int GetTop()
        {
            return Top.Value;
        }

        public int Pop()
        {
            if (!IsEmpty())
            {
                int value = Top.Value;
                Top = Top.PreviousNode;
                theNumberOfElements -= 1;
                return value;
            }

            else
                throw new Exception("The Stack is empty.");
            
        }

        public bool IsEmpty()
        {
            return theNumberOfElements == 0;
        }

    }
 
    class StackWithMaximum
    {
        Stack numbers;
        Stack maximums;

        public StackWithMaximum()
        {
            numbers = new Stack();
            maximums = new Stack();
        }

        public void Push(int Key)
        {
            numbers.Push(Key);
            int currentMaximum = Key >= maximums.GetTop() ? Key : maximums.GetTop();
            maximums.Push(currentMaximum);
        }

        public int Pop()
        {
            maximums.Pop();
            return numbers.Pop();
        }      

        public int GetMaximum()
        {
            return maximums.GetTop();
        }

        public bool IsEmpty()
        {
            return numbers.IsEmpty();
        }
    }

    class QueueWithMaximum
    {
        Stack ToPushStack;
        StackWithMaximum ToRemoveStack;
        int maxInToPushStack;
        const int verySmallNumber = -1000000000;

        public QueueWithMaximum()
        {
            ToPushStack = new Stack();
            ToRemoveStack = new StackWithMaximum();
            maxInToPushStack = verySmallNumber;
        }

        public void Enqueue (int Key)
        {
            ToPushStack.Push(Key);
            if (Key >= maxInToPushStack)
                maxInToPushStack = Key;
        }

        public int Dequeue()
        {
            if (ToRemoveStack.IsEmpty())
            {
                if (ToPushStack.IsEmpty())
                    throw new Exception("The queue is empty.");
                else
                {
                    int value;
                    while (!(ToPushStack.IsEmpty()))
                    {
                        value = ToPushStack.Pop();
                        ToRemoveStack.Push(value);
                    }
                    maxInToPushStack = verySmallNumber;
                }
                
            }

            return ToRemoveStack.Pop();
        }

        public int GetMaximum()
        {
            int maximum;
            if (ToRemoveStack.IsEmpty())
                maximum = maxInToPushStack;
            else            
                maximum = ToRemoveStack.GetMaximum() >= maxInToPushStack ?
                    ToRemoveStack.GetMaximum() : maxInToPushStack;
            return maximum;                           
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            int theNumberOfElements = int.Parse(Console.ReadLine());
            string[] elements = Console.ReadLine().Split();
            int windowSize = int.Parse(Console.ReadLine());

            QueueWithMaximum window = new QueueWithMaximum();
            int currentElement;
            int currentMaximum;
            StringBuilder maximums = new StringBuilder();

            for (int i = 0; i < windowSize; i++)
            {
                currentElement = int.Parse(elements[i]);
                window.Enqueue(currentElement);            
            }

            currentMaximum = window.GetMaximum();
            maximums.Append(currentMaximum + " ");


            for (int i = windowSize; i < theNumberOfElements; i++) 
            {
                currentElement = int.Parse(elements[i]);                
                window.Dequeue();
                window.Enqueue(currentElement);

                currentMaximum = window.GetMaximum();
                maximums.Append(currentMaximum + " ");
            }

            Console.WriteLine(maximums);
            Console.ReadLine();
        }
    }
}
