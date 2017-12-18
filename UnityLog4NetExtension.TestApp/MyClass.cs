using log4net;

namespace UnityLog4NetExtension.TestApp
{
    public class MyClass
    {
        private readonly ILog _logger;

        public MyClass(ILog logger)
        {
            _logger = logger;
        }

        public void Test()
        {
            _logger.Info("HELLO WORLD!");
        }
    }
}