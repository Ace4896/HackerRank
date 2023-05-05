namespace HackerRank.OneWeek
{
    using System;
    using System.Collections.Generic;

    // https://www.hackerrank.com/challenges/one-week-preparation-kit-queue-using-two-stacks/problem
    // NOTE: Zero skeleton code was provided
    //
    // While we can implement queues using a single array, this one specifically wanted two stacks
    // - Enqueuing is done as normal - add to the stack
    // - Dequeuing requires inverting the stack, removing the first element, then inverting the stack to get the new queue
    // - Printing / peeking the element at the top of the stack - we can avoid inverting in this scenario by keeping track of the top element
    //
    // To help with runtime, we can minimise the number of times we invert the stack by optimising for consecutive enqueues / dequeues
    // Unfortunately, this still times out...
    public partial class Result
    {
        class Queue
        {
            private Stack<int> _values = new();
            private Stack<int> _buffer = new();
            
            public int? HeadValue { get; private set; }

            public void Enqueue(int value)
            {
                // Set head value
                if (_values.Count == 0 && _buffer.Count == 0)
                {
                    HeadValue = value;
                }

                // Invert stacks if last operation was dequeue
                if (_values.Count == 0 && _buffer.Count > 0)
                {
                    while (_buffer.Count > 0)
                    {
                        _values.Push(_buffer.Pop());
                    }
                }

                // Enqueue value
                _values.Push(value);
            }

            public int? Dequeue()
            {
                if (_values.Count == 0 && _buffer.Count == 0)
                {
                    return null;
                }

                // Invert stacks if last operation was enqueue
                if (_values.Count > 0 && _buffer.Count == 0)
                {
                    while (_values.Count > 0)
                    {
                        _buffer.Push(_values.Pop());
                    }
                }

                int dequeuedValue = _buffer.Pop();
                HeadValue = _buffer.TryPeek(out int newHeadValue) ? newHeadValue : null;

                return dequeuedValue;
            }
        }

        public static void QueueTwoStacksMain(string[] args)
        {
            int queries = int.Parse(Console.ReadLine()!);
            Queue queue = new Queue();

            for (int i = 0; i < queries; i++)
            {
                string[] query = Console.ReadLine()!.Split(' ');
                switch (query[0])
                {
                    case "1":
                        // Enqueue query[1]
                        queue.Enqueue(int.Parse(query[1]));
                        break;

                    case "2":
                        // Dequeue
                        queue.Dequeue();
                        break;

                    case "3":
                        // Print Head Value
                        Console.WriteLine(queue.HeadValue);
                        break;
                }
            }
        }
    }
}
