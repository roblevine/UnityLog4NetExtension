namespace UnityLoggingExtensions.CreationStackTracker
{
    using System;

    public class CreationStackTrackerPolicy : ICreationStackTrackerPolicy
    {
        private readonly PeekableStack<Type> typeStack = new PeekableStack<Type>();

        public PeekableStack<Type> TypeStack
        {
            get
            {
                return this.typeStack; 
            }
        }
    }
}