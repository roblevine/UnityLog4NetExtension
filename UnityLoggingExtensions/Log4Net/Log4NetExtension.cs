namespace UnityLoggingExtensions.Log4Net
{
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.ObjectBuilder;

    using UnityLoggingExtensions.CreationStackTracker;

    public class CreationStackReporterExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            this.Context.Strategies.AddNew<CreationStackTrackerStrategy>(UnityBuildStage.TypeMapping);
            this.Context.Strategies.AddNew<Log4NetStrategy>(UnityBuildStage.TypeMapping);
        }
    }
}