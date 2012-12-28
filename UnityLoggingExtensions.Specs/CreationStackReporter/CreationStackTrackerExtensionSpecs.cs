namespace UnityLoggingExtensions.Specs.CreationStackReporter
{
    using Machine.Specifications;

    using Microsoft.Practices.Unity;

    using UnityLoggingExtensions.CreationStackReporter;
    using UnityLoggingExtensions.CreationStackTracker;

    public class when_a_class_with_a_single_ctor_param_of_UnityObjectCreationStack_is_constructed : CreationStackReporterSpecsContext
    {
        private Establish establish = () =>
            {
                unityContainer.RegisterType<IClassWithUnityObjectCreationStack, ClassWithCtor_UnityObjectCreationStack>();
            };

        private Because because = () => { classRequiringInterceptedDependency = unityContainer.Resolve<IClassWithUnityObjectCreationStack>(); };

        private It stack_should_not_be_null = () => classRequiringInterceptedDependency.UnityObjectCreationStack.ShouldNotBeNull();

        private It then_current_item_on_call_stack_should_be_the_UnityObjectCreationStack_class_being_createdd = () => classRequiringInterceptedDependency.UnityObjectCreationStack.Peek(0).FullName.ShouldEqual(typeof(UnityObjectCreationStack).FullName);

        private It then_previous_item_on_call_stack_should_be_the_parent_class_requiring_this_dependency = () => classRequiringInterceptedDependency.UnityObjectCreationStack.Peek(1).FullName.ShouldEqual(typeof(ClassWithCtor_UnityObjectCreationStack).FullName);
    }

    public class when_a_class_with_a_two_ctor_param_of_string_and_UnityObjectCreationStack__is_constructed : CreationStackReporterSpecsContext
    {
        private Establish establish = () =>
        {
            unityContainer.RegisterType<IClassWithUnityObjectCreationStack, ClassWithCtor_SimpleDependency_UnityObjectCreationStack>();
        };

        private Because because = () => { classRequiringInterceptedDependency = unityContainer.Resolve<IClassWithUnityObjectCreationStack>(); };

        private It then_current_item_on_call_stack_should_be_the_UnityObjectCreationStack_class_being_createdd = () => classRequiringInterceptedDependency.UnityObjectCreationStack.Peek(0).FullName.ShouldEqual(typeof(UnityObjectCreationStack).FullName);

        private It then_previous_item_on_call_stack_should_be_the_parent_class_requiring_this_dependency = () => classRequiringInterceptedDependency.UnityObjectCreationStack.Peek(1).FullName.ShouldEqual(typeof(ClassWithCtor_SimpleDependency_UnityObjectCreationStack).FullName);
    }

    public class CreationStackReporterSpecsContext
    {
        protected static UnityContainer unityContainer;

        protected static CreationStackTrackerExtension subject;

        protected static IClassWithUnityObjectCreationStack classRequiringInterceptedDependency;

        protected Establish establish = () =>
        {
            unityContainer = new UnityContainer();
            unityContainer.AddNewExtension<CreationStackReporterExtension>();
        };
    }

    public class when_a_class_heirachy_is_created_with_monitoring_stack_dependency_at_depth_of_third_level
    {
        private static UnityContainer unityContainer;
        private static TopLevel topLevelClass;
        private static ThirdLevel thirdLevelClass;

        private Establish establish = () =>
        {
            unityContainer = new UnityContainer();
            unityContainer.AddNewExtension<CreationStackReporterExtension>();
        };

        private Because because = () =>
            {
                topLevelClass = unityContainer.Resolve<TopLevel>();
                thirdLevelClass = topLevelClass.SecondLevel.ThirdLevel;
            };

        private It dependency_being_created_sees_the_top_of_the_creation_stack_as_itself = () => thirdLevelClass.UnityObjectCreationStack.Peek(0).FullName.ShouldEqual(typeof(UnityObjectCreationStack).FullName);

        private It dependency_being_created_sees_its_immediate_parent_as_third_level_class = () => thirdLevelClass.UnityObjectCreationStack.Peek(1).FullName.ShouldEqual(typeof(ThirdLevel).FullName);

        private It third_level_class_sees_its_immediate_parent_as_second_level_class = () => thirdLevelClass.UnityObjectCreationStack.Peek(2).FullName.ShouldEqual(typeof(SecondLevel).FullName);

        private It third_level_class_sees_its_grandparent_as_top_level_class = () => thirdLevelClass.UnityObjectCreationStack.Peek(3).FullName.ShouldEqual(typeof(TopLevel).FullName);
    }
}
