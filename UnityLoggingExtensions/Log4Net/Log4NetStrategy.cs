namespace UnityLoggingExtensions.Log4Net
{
    using log4net;

    using Microsoft.Practices.ObjectBuilder2;

    using UnityLoggingExtensions.CreationStackTracker;

    public class Log4NetStrategy : BuilderStrategy
    {
        public override void PreBuildUp(IBuilderContext context)
        {
            var policy = context.Policies.Get<ICreationStackTrackerPolicy>(buildKey: null, localOnly: true);

            if (policy.TypeStack.Count > 2 && policy.TypeStack.Peek(0) == typeof(ILog))
            {
                context.Existing = LogManager.GetLogger(policy.TypeStack.Peek(1));
            }

            base.PreBuildUp(context);
        }
    }  
}