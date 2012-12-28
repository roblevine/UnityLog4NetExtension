namespace UnityLoggingExtensions.CreationStackTracker
{
    using System;

    using Microsoft.Practices.ObjectBuilder2;

    public interface ICreationStackTrackerPolicy : IBuilderPolicy
    {
        PeekableStack<Type> TypeStack { get; }
    }
}