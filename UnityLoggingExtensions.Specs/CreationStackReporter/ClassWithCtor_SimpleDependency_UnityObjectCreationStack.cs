namespace UnityLoggingExtensions.Specs.CreationStackReporter
{
    using System;

    using UnityLoggingExtensions.CreationStackTracker;

    public class ClassWithCtor_SimpleDependency_UnityObjectCreationStack : IClassWithUnityObjectCreationStack
    {
        public ClassWithCtor_SimpleDependency_UnityObjectCreationStack(SimpleClass simpleClass, UnityObjectCreationStack unityObjectCreationStack)
        {
            Console.WriteLine("Ctor: ClassWithCtor_SimpleDependency_UnityObjectCreationStack");
            this.UnityObjectCreationStack = unityObjectCreationStack;
        }

        public UnityObjectCreationStack UnityObjectCreationStack { get; set; }
    }
}