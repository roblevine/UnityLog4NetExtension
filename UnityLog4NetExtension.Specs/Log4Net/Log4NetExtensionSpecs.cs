#region Copyright & License

// This software is licensed under the MIT License
// 
// Copyright (C) 2012, Rob Levine
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy 
// of this software and associated documentation files (the "Software"), 
// to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the 
// Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in 
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS 
// IN THE SOFTWARE.
#endregion

namespace UnityLog4NetExtension.Specs.Log4Net
{
    using Machine.Specifications;

    using Microsoft.Practices.Unity;

    using UnityLog4NetExtension.CreationStackReporter;
    using UnityLog4NetExtension.Log4Net;

    [Subject(typeof(Log4NetExtension))]
    public class when_a_class_taking_a_single_ILog_dependency_is_created_via_unity
    {
        private static IUnityContainer container;

        private static ClassWithSingleILogDependency classWithDependency;

        private Establish establish = () =>
            {
                container = new UnityContainer();
                container.AddNewExtension<Log4NetExtension>();
            };

        private Because because = () => classWithDependency = container.Resolve<ClassWithSingleILogDependency>();

        private It the_injected_logger_is_not_null = () => classWithDependency.Logger.ShouldNotBeNull();

        private It the_injected_logger_has_a_name_corresponding_to_the_type_it_is_being_injected_into = () => classWithDependency.Logger.Logger.Name.ShouldEqual(typeof(ClassWithSingleILogDependency).FullName);
    }

    [Subject(typeof(Log4NetExtension))]
    public class when_a_class_taking_SimpleClass_and_ILog_as_dependencies_is_created_via_unity
    {
        private static IUnityContainer container;

        private static ClassWithTwoDependencies_SimpleClass_and_ILog classWithDependency;

        private Establish establish = () =>
        {
            container = new UnityContainer();
            container.AddNewExtension<Log4NetExtension>();
        };

        private Because because = () => classWithDependency = container.Resolve<ClassWithTwoDependencies_SimpleClass_and_ILog>();

        private It the_injected_logger_is_not_null = () => classWithDependency.Logger.ShouldNotBeNull();

        private It the_injected_logger_has_a_name_corresponding_to_the_type_it_is_being_injected_into = () => classWithDependency.Logger.Logger.Name.ShouldEqual(typeof(ClassWithTwoDependencies_SimpleClass_and_ILog).FullName);
    }

    [Subject(typeof(Log4NetExtension))]
    public class when_a_three_level_class_heirarchy_is_created_with_the_third_level_class_taking_an_ILog_as_a_dependency
    {
        private static IUnityContainer container;

        private static TopLevel classWithDependency;

        private Establish establish = () =>
        {
            container = new UnityContainer();
            container.AddNewExtension<Log4NetExtension>();
        };

        private Because because = () => classWithDependency = container.Resolve<TopLevel>();

        private It the_injected_logger_is_not_null = () => classWithDependency.SecondLevel.ThirdLevel.Logger.ShouldNotBeNull();

        private It the_injected_logger_has_a_name_corresponding_to_the_type_it_is_being_injected_into = () => classWithDependency.SecondLevel.ThirdLevel.Logger.Logger.Name.ShouldEqual(typeof(ThirdLevel).FullName);
    }
}
