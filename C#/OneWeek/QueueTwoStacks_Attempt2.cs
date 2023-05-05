namespace HackerRank.OneWeek
{
    using System;
    using System.Collections.Generic;

    // https://www.hackerrank.com/challenges/one-week-preparation-kit-queue-using-two-stacks/problem
    // NOTE: Zero skeleton code was provided
    //
    // There was a trick to the runtime issue - one stack was used for O(1) pushes, other stack was used for O(n) dequeue
    // Essentially, the enqueued values were pushed as normal
    // Whenever we dequeue, if there's nothing in the buffer, we invert the stack onto the buffer and pop the top element
    // This minimises how often we have to invert the stack, and is good when we have consecutive enqueues/dequeues
    public partial class Result
    {
        class Queue2
        {
            private Stack<int> _values = new();
            private Stack<int> _buffer = new();

            public void Enqueue(int value)
            {
                _values.Push(value);
            }

            public int? Dequeue()
            {
                if (_buffer.Count == 0 && _values.Count == 0)
                {
                    return null;
                }

                if (_buffer.Count == 0)
                {
                    while (_values.Count > 0)
                    {
                        _buffer.Push(_values.Pop());
                    }
                }

                return _buffer.Pop();
            }

            public int? Peek()
            {
                int? dequeuedValue = Dequeue();

                if (dequeuedValue.HasValue)
                {
                    _buffer.Push(dequeuedValue.Value);
                }

                return dequeuedValue;
            }
        }

        public static void QueueTwoStacksMain2(string[] args)
        {
            int queries = int.Parse(Console.ReadLine()!);
            Queue2 queue = new Queue2();

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
                        Console.WriteLine(queue.Peek());
                        break;
                }
            }
        }
    }
}
