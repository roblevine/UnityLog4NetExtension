// -----------------------------------------------------------------------
// <copyright file="LoggingBuilderStrategy.cs" company="INEX Solutions Ltd">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace UnityExtensions.ObjectCreationStackTracking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Practices.ObjectBuilder2;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.ObjectBuilder;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class LoggingBuilderStrategy : BuilderStrategy
    {
        private readonly UnityBuildStage unityBuildStage;

        public LoggingBuilderStrategy(UnityBuildStage unityBuildStage)
        {
            this.unityBuildStage = unityBuildStage;
        }

        public UnityBuildStage Stage
        {
            get
            {
                return this.unityBuildStage;
            }
        }

        public override void PreBuildUp(IBuilderContext context)
        {
            Console.WriteLine("UnityBuildStage: {0}, {1}", this.unityBuildStage, "PreBuildUp");
            base.PreBuildUp(context);
        }

        public override void PostBuildUp(IBuilderContext context)
        {
            Console.WriteLine("UnityBuildStage: {0}, {1}", this.unityBuildStage, "PostBuildUp");
            base.PostBuildUp(context);
        }

        public override void PreTearDown(IBuilderContext context)
        {
            Console.WriteLine("UnityBuildStage: {0}, {1}", this.unityBuildStage, "PreTearDown");
            base.PreTearDown(context);
        }

        public override void PostTearDown(IBuilderContext context)
        {
            Console.WriteLine("UnityBuildStage: {0}, {1}", this.unityBuildStage, "PostTearDown");
            base.PostTearDown(context);
        }
    }

    public class LoggingBuilderExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            var builder = new LoggingBuilderStrategy(UnityBuildStage.Creation);
            this.Context.Strategies.Add(builder, builder.Stage);

            builder = new LoggingBuilderStrategy(UnityBuildStage.Initialization);
            this.Context.Strategies.Add(builder, builder.Stage);

            builder = new LoggingBuilderStrategy(UnityBuildStage.Lifetime);
            this.Context.Strategies.Add(builder, builder.Stage);

            builder = new LoggingBuilderStrategy(UnityBuildStage.PostInitialization);
            this.Context.Strategies.Add(builder, builder.Stage);

            builder = new LoggingBuilderStrategy(UnityBuildStage.PreCreation);
            this.Context.Strategies.Add(builder, builder.Stage);

            builder = new LoggingBuilderStrategy(UnityBuildStage.Setup);
            this.Context.Strategies.Add(builder, builder.Stage);

            builder = new LoggingBuilderStrategy(UnityBuildStage.TypeMapping);
            this.Context.Strategies.Add(builder, builder.Stage);
        }
    }
}
