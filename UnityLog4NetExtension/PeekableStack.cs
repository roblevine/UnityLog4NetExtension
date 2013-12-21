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

using System.Collections.Generic;

namespace UnityLog4NetExtension
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class PeekableStack<T>
    {
        #region Fields

        /// <summary>
        /// </summary>
        private readonly List<T> list;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// </summary>
        public PeekableStack()
        {
            list = new List<T>();
        }

        /// <summary>
        /// </summary>
        /// <param name="initialItems">
        /// </param>
        public PeekableStack(IEnumerable<T> initialItems)
        {
            list = new List<T>(initialItems);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// </summary>
        public int Count
        {
            get { return list.Count; }
        }

        /// <summary>
        /// </summary>
        public IEnumerable<T> Items
        {
            get { return list.ToArray(); }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <param name="depth">
        /// </param>
        /// <returns>
        /// </returns>
        public T Peek(int depth)
        {
            var index = list.Count - 1 - depth;
            return list[index];
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public T Pop()
        {
            var index = list.Count - 1;
            T ret = list[index];
            list.RemoveAt(index);
            return ret;
        }

        /// <summary>
        /// </summary>
        /// <param name="obj">
        /// </param>
        public void Push(T obj)
        {
            list.Add(obj);
        }

        #endregion
    }
}