namespace UnityLoggingExtensions.Specs.CreationStackReporter
{
    using System;

    using UnityLoggingExtensions.CreationStackTracker;

    public class ClassWithCtor_UnityObjectCreationStack : IClassWithUnityObjectCreationStack
    {
        public ClassWithCtor_UnityObjectCreationStack(UnityObjectCreationStack unityObjectCreationStack)
        {
            Console.WriteLine("Ctor: ClassWithCtor_UnityObjectCreationStack");
            this.UnityObjectCreationStack = unityObjectCreationStack;
        }

        public UnityObjectCreationStack UnityObjectCreationStack { get; set; }
    }
}