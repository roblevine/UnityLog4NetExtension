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

using Microsoft.Practices.ObjectBuilder2;
using UnityLog4NetExtension.CreationStackTracker;

namespace UnityLog4NetExtension.CreationStackReporter
{
    /// <summary>
    /// </summary>
    public class UnityObjectCreationStackReporterStrategy : BuilderStrategy
    {
        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <param name="context">
        /// </param>
        public override void PreBuildUp(IBuilderContext context)
        {
            var policy = context.Policies.Get<ICreationStackTrackerPolicy>(buildKey: null, localOnly: true);

            if (policy.TypeStack.Count > 1 && policy.TypeStack.Peek(0) == typeof (UnityObjectCreationStack))
            {
                context.Existing = new UnityObjectCreationStack(policy.TypeStack.Items);
            }

            base.PreBuildUp(context);
        }

        #endregion
    }
}