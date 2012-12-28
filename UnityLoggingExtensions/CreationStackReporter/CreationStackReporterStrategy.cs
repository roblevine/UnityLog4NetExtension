namespace UnityLoggingExtensions.CreationStackReporter
{
    using Microsoft.Practices.ObjectBuilder2;

    using UnityLoggingExtensions.CreationStackTracker;

    public class UnityObjectCreationStackReporterStrategy : BuilderStrategy
    {
        public override void PreBuildUp(IBuilderContext context)
        {
            var policy = context.Policies.Get<ICreationStackTrackerPolicy>(buildKey: null, localOnly: true);

            if (policy.TypeStack.Count > 1 && policy.TypeStack.Peek(0) == typeof(UnityObjectCreationStack))
            {
                context.Existing = new UnityObjectCreationStack(policy.TypeStack.Items);
            }

            base.PreBuildUp(context);
        }
    }

   
}