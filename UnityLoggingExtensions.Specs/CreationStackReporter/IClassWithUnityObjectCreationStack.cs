namespace UnityLoggingExtensions.Specs.CreationStackReporter
{
    using UnityLoggingExtensions.CreationStackTracker;

    public interface IClassWithUnityObjectCreationStack
    {
        UnityObjectCreationStack UnityObjectCreationStack { get; set; }
    }
}