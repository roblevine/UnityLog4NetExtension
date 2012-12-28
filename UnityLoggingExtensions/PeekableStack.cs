namespace UnityLoggingExtensions
{
    using System.Collections.Generic;

    public class PeekableStack<T>
    {
        private readonly List<T> list;

        public PeekableStack()
        {
            this.list = new List<T>();
        }

        public PeekableStack(IEnumerable<T> initialItems)
        {
            this.list = new List<T>(initialItems);
        }

        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }

        public IEnumerable<T> Items
        {
            get
            {
                return this.list.ToArray();
            }
        }

        public void Push(T obj)
        {
            this.list.Add(obj);
        }

        public T Pop()
        {
            var index = this.list.Count - 1;
            T ret = this.list[index];
            this.list.RemoveAt(index);
            return ret;
        }

        public T Peek(int depth)
        {
            var index = this.list.Count - 1 - depth;
            return this.list[index];
        }
    }
}
