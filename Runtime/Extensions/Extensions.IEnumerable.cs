using System;
using System.Collections.Generic;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static IEnumerable<LinkedListNode<T>> EnumerateNodes<T>(this LinkedList<T> list)
        {
            var node = list.First;
            while (node != null)
            {
                yield return node;
                node = node.Next;
            }
        }

        public static CustomEnumerator GetEnumerator(this Range range)
        {
            if (range.End.IsFromEnd)
                throw new NotSupportedException("Range without end value is not supported");

            return new CustomEnumerator(range);
        }

        public static CustomEnumerator GetEnumerator(this int number)
        {
            if (number <= 0)
                throw new NotSupportedException("Number should be greater than 0");

            return new CustomEnumerator(0..number);
        }

        public ref struct CustomEnumerator
        {
            private int _current;
            private readonly int _end;

            public CustomEnumerator(Range range)
            {
                _current = range.Start.Value - 1;
                _end = range.End.Value;
            }

            public readonly int Current => _current;

            public bool MoveNext()
            {
                _current++;
                return _current <= _end;
            }
        }
    }
}
