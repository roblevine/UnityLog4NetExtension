namespace UnityLoggingExtensions.CreationStackTracker
{
    using System;
    using System.Collections.Generic;

    public class UnityObjectCreationStack
    {
        private readonly List<Type> items;

        public UnityObjectCreationStack(IEnumerable<Type> stack)
        {
            this.items = new List<Type>(stack);
        }

        public IEnumerable<Type> Items
        {
            get
            {
                return this.items;
            }
        }

        public Type Peek(int peekBack = 0)
        {
            return this.items[this.items.Count - 1 - peekBack];
        }
    }
}