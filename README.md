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
    
There has been some discussion online as to how best to acheive this:

http://stackoverflow.com/questions/6846342/how-to-inject-log4net-ilog-implementations-using-unity-2-0
http://davidkeaveny.blogspot.co.uk/2011/03/unity-and-log4net.html
http://blog.baltrinic.com/software-development/dotnet/log4net-integration-with-unity-ioc-container

The solutions discussed and presented in these articles (in particular the last one), inspired me to write this extension as an improvement over Kenneth Baltrinic's documented solution. Although his suggested solution works - it involves some stack walking to identify the `Type` of the logger to create. I felt that this should be available from within Unity itself without the need to resort to handling `StackTrace`/`StackFrame` classes.

In order to acheive the desired end result, three extensions have been written. Two are directly related to this, and one to help with testing:

**CreationStackTrackerExtension**
This extension is responsible for mainting a stack of the type creation heirarchy. At the creation of any given type via unity, the stack provided by this extension will show the parent class, grandparent, etc.

**Log4NetExtension**
Relying on the extension above, this intercepts any request for an `ILog` instance and creates an `ILog` instance by calling `LogManager.GetLogger(Type t)` using the type of the parent class (ie the class the logger is being injected into)

This can be registered as follows:

    var container = new UnityContainer();
    container.AddNewExtension<Log4NetExtension>();

Once registered, any `ILog` dependencies will resolve to a log4net logger with a type name matching the type it will be injected into.

**CreationStackReporterExtension**
Relying on the _CreationStackTrackerExtension_ extension above, this extension will resolve any dependency of type `UnityObjectCreationStack`, and inject an instance that has a copy of the object creation stack, as maintained by _CreationStackTrackerExtension_.

    var container = new UnityContainer();
    container.AddNewExtension<CreationStackReporterExtension>();

Once registered, any `UnityObjectCreationStack` dependencies will resolve to an instance that contains the type creation stack

    public class MyClass
    {
        public MyClass(UnityObjectCreationStack unityObjectCreationStack)
        {

        }
    }
    
See http://blog.roblevine.co.uk/net/using-log4net-with-unity/ for more info.

NOTE: This is now available as a NuGet package: 
https://www.nuget.org/packages/UnityLog4NetExtension/

NOTE: Tests are written using Machine Specifications [https://github.com/machine/machine.specifications]. If you are using ReSharper as your test runner, you'll need to run the following batch file to get MSpec to work with the ReSharper runner:

`UnityLoggingExtensions\packages\Machine.Specifications.0.5.10\tools\InstallResharperRunner.x.x.bat`
