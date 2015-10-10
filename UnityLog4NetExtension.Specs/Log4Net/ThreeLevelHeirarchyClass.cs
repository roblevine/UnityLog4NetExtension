#region Copyright & Licence
// This software is licensed under the MIT License
// 
// 
// Copyright (C) 2012-15, Rob Levine
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
using log4net;

namespace UnityLog4NetExtension.Specs.Log4Net
{
    public class TopLevel
    {
        private readonly SecondLevel secondLevel;

        public TopLevel(SimpleClass c1, SecondLevel secondLevel, SimpleClass c3)
        {
            this.secondLevel = secondLevel;
        }

        public SecondLevel SecondLevel
        {
            get { return secondLevel; }
        }
    }

    public class SecondLevel
    {
        private readonly ThirdLevel thirdLevel;

        public SecondLevel(SimpleClass c1, ThirdLevel thirdLevel, SimpleClass c3)
        {
            this.thirdLevel = thirdLevel;
        }

        public ThirdLevel ThirdLevel
        {
            get { return thirdLevel; }
        }
    }

    public class ThirdLevel
    {
        private readonly ILog logger;

        public ThirdLevel(SimpleClass c1, ILog logger, SimpleClass c3)
        {
            this.logger = logger;
        }

        public ILog Logger
        {
            get { return logger; }
        }
    }
}