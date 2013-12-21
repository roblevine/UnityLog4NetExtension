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

namespace UnityLog4NetExtension.CreationStackTracker
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// </summary>
    public class UnityObjectCreationStack
    {
        #region Fields

        /// <summary>
        /// </summary>
        private readonly List<Type> items;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// </summary>
        /// <param name="stack">
        /// </param>
        public UnityObjectCreationStack(IEnumerable<Type> stack)
        {
            this.items = new List<Type>(stack);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// </summary>
        public IEnumerable<Type> Items
        {
            get
            {
                return this.items;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <param name="peekBack">
        /// </param>
        /// <returns>
        /// </returns>
        public Type Peek(int peekBack = 0)
        {
            return this.items[this.items.Count - 1 - peekBack];
        }

        #endregion
    }
}