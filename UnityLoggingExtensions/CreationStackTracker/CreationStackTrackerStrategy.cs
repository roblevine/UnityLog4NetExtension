namespace UnityLoggingExtensions.CreationStackTracker
{
    using System;
    using System.Linq;

    using Microsoft.Practices.ObjectBuilder2;

    public class CreationStackTrackerStrategy : BuilderStrategy
    {
        public override void PreBuildUp(IBuilderContext context)
        {
            var policy = context.Policies.Get<ICreationStackTrackerPolicy>(buildKey: null, localOnly: true);
            if (policy == null)
            {
                context.Policies.Set(typeof(ICreationStackTrackerPolicy), new CreationStackTrackerPolicy(), null);
                policy = context.Policies.Get<ICreationStackTrackerPolicy>(buildKey: null, localOnly: true);
            }

            policy.TypeStack.Push(context.BuildKey.Type);
            Console.WriteLine("PUSH: {0} [{1}]", context.BuildKey.Type, this.ReportStack(policy.TypeStack));

            base.PreBuildUp(context);
        }

        public override void PostBuildUp(IBuilderContext context)
        {
            var policy = context.Policies.Get<ICreationStackTrackerPolicy>(buildKey: null, localOnly: true);

            if (policy.TypeStack.Count > 0)
            {
                policy.TypeStack.Pop();
                Console.WriteLine("POP: {0} [{1}]", context.BuildKey.Type, this.ReportStack(policy.TypeStack));
            }

            base.PostBuildUp(context);
        }

        private object ReportStack(PeekableStack<Type> typeStack)
        {
            return string.Join(", ", typeStack.Items.Select(s => s.Name));
        }
    }
}