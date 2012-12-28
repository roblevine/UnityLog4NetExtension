namespace UnityLoggingExtensions.Specs.CreationStackReporter
{
    using System;

    using UnityLoggingExtensions.CreationStackTracker;

    public class TopLevel
    {
        private readonly SecondLevel secondLevel;

        public TopLevel(SimpleClass c1, SecondLevel secondLevel, SimpleClass c3)
        {
            this.secondLevel = secondLevel;
        }

        public SecondLevel SecondLevel
        {
            get
            {
                return this.secondLevel;
            }
        }
    }

    public class SecondLevel
    {
        private readonly ThirdLevel thirdLevel;

        public SecondLevel(SimpleClass c1, ThirdLevel thirdLevel, SimpleClass c3)
        {
            this.thirdLevel = thirdLevel;
        }

        public ThirdLevel ThirdLevel
        {
            get
            {
                return this.thirdLevel;
            }
        }
    }

    public class ThirdLevel
    {
        private readonly PeekableStack<Type> unityObjectCreationStack;

        public ThirdLevel(SimpleClass c1, UnityObjectCreationStack unityObjectCreationStack, SimpleClass c3)
        {
            this.unityObjectCreationStack = new PeekableStack<Type>(unityObjectCreationStack.Items);
        }

        public PeekableStack<Type> UnityObjectCreationStack
        {
            get
            {
                return this.unityObjectCreationStack;
            }
        }
    }
}
