#region Copyright & License

// This software is licensed under the MIT License
// 
// 
// Copyright (C) 2012-13, Rob Levine
// 
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy 
// of this software and associated documentation files (the "Software"), 
// to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the 
// Software is furnished to do so, subject to the following conditions:
// 
// 
// The above copyright notice and this permission notice shall be included in 
// all copies or substantial portions of the Software.
// 
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS 
// IN THE SOFTWARE.
// 
// [Source code: https://github.com/roblevine/UnityLoggingExtensions]

#endregion

using Machine.Specifications;
using Microsoft.Practices.Unity;
using UnityLog4NetExtension.CreationStackReporter;
using UnityLog4NetExtension.CreationStackTracker;

namespace UnityLog4NetExtension.Specs.CreationStackReporter
{
    [Subject(typeof (CreationStackReporterExtension))]
    public class when_a_class_with_a_single_ctor_param_of_UnityObjectCreationStack_is_constructed :
        CreationStackReporterSpecsContext
    {
        private Because because =
            () =>
            {
                classRequiringInterceptedDependency = unityContainer.Resolve<IClassWithUnityObjectCreationStack>();
            };

        private Establish establish =
            () =>
            {
                unityContainer.RegisterType<IClassWithUnityObjectCreationStack, ClassWithCtor_UnityObjectCreationStack>();
            };

        private It stack_should_not_be_null =
            () => classRequiringInterceptedDependency.UnityObjectCreationStack.ShouldNotBeNull();

        private It then_current_item_on_call_stack_should_be_the_UnityObjectCreationStack_class_being_createdd =
            () =>
                classRequiringInterceptedDependency.UnityObjectCreationStack.Peek(0)
                    .FullName.ShouldEqual(typeof (UnityObjectCreationStack).FullName);

        private It then_previous_item_on_call_stack_should_be_the_parent_class_requiring_this_dependency =
            () =>
                classRequiringInterceptedDependency.UnityObjectCreationStack.Peek(1)
                    .FullName.ShouldEqual(typeof (ClassWithCtor_UnityObjectCreationStack).FullName);
    }

    [Subject(typeof (CreationStackReporterExtension))]
    public class when_a_class_with_a_two_ctor_param_of_string_and_UnityObjectCreationStack__is_constructed :
        CreationStackReporterSpecsContext
    {
        private Because because =
            () =>
            {
                classRequiringInterceptedDependency = unityContainer.Resolve<IClassWithUnityObjectCreationStack>();
            };

        private Establish establish =
            () =>
            {
                unityContainer
                    .RegisterType
                    <IClassWithUnityObjectCreationStack, ClassWithCtor_SimpleDependency_UnityObjectCreationStack>();
            };

        private It then_current_item_on_call_stack_should_be_the_UnityObjectCreationStack_class_being_createdd =
            () =>
                classRequiringInterceptedDependency.UnityObjectCreationStack.Peek(0)
                    .FullName.ShouldEqual(typeof (UnityObjectCreationStack).FullName);

        private It then_previous_item_on_call_stack_should_be_the_parent_class_requiring_this_dependency =
            () =>
                classRequiringInterceptedDependency.UnityObjectCreationStack.Peek(1)
                    .FullName.ShouldEqual(typeof (ClassWithCtor_SimpleDependency_UnityObjectCreationStack).FullName);
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

    [Subject(typeof (CreationStackReporterExtension))]
    public class when_a_class_heirachy_is_created_with_monitoring_stack_dependency_at_depth_of_third_level
    {
        private static UnityContainer unityContainer;
        private static TopLevel topLevelClass;
        private static ThirdLevel thirdLevelClass;

        private Because because = () =>
        {
            topLevelClass = unityContainer.Resolve<TopLevel>();
            thirdLevelClass = topLevelClass.SecondLevel.ThirdLevel;
        };

        private It dependency_being_created_sees_its_immediate_parent_as_third_level_class =
            () => thirdLevelClass.UnityObjectCreationStack.Peek(1).FullName.ShouldEqual(typeof (ThirdLevel).FullName);

        private It dependency_being_created_sees_the_top_of_the_creation_stack_as_itself =
            () =>
                thirdLevelClass.UnityObjectCreationStack.Peek(0)
                    .FullName.ShouldEqual(typeof (UnityObjectCreationStack).FullName);

        private Establish establish = () =>
        {
            unityContainer = new UnityContainer();
            unityContainer.AddNewExtension<CreationStackReporterExtension>();
        };

        private It third_level_class_sees_its_grandparent_as_top_level_class =
            () => thirdLevelClass.UnityObjectCreationStack.Peek(3).FullName.ShouldEqual(typeof (TopLevel).FullName);

        private It third_level_class_sees_its_immediate_parent_as_second_level_class =
            () => thirdLevelClass.UnityObjectCreationStack.Peek(2).FullName.ShouldEqual(typeof (SecondLevel).FullName);
    }
}