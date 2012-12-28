**UnityLoggingExtensions**

This library was born out of a desire to have a simple extension to Unity that would enable log4net `ILog` dependencies to be injected into consuming classes, with the ILog instance being the configured as the correct logger for the consuming class.

A fairly standard pattern for declaring a log4net logger in a class is:

    public class MyClass
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(MyClass));
    }
    
I want to acheive a similarly configured logger, but have it passed in at construction time:

    public class MyClass
    {
        private readonly ILog logger;
        
        public MyClass(ILog logger)
        {
            this.logger = logger;
        }
    }
    
In order to acheive this, three extensions have been written. Two are directly related to this, and one to help with testing.

