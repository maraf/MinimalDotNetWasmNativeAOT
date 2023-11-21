using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;

Console.WriteLine("Hello, Console!");

foreach (var arg in args)
{
    Console.WriteLine($"Arg: '{arg}'");
}

// await Task.Delay(10);

Console.WriteLine($"Answer is '{MyClass.GetAnswer()}'");
Console.WriteLine($"Math result is '{MyClass.Math(1, 2, 3)}'");
Console.WriteLine($"Greet response is '{MyClass.Greet("Jon")}'");

return 0;

public partial class MyClass
{
    [JSExport]
    internal static int Greeting()
    {
        Console.WriteLine($"Hello, World! The answer is {GetAnswer()}");
        return 44;
    }

    [JSImport("interop.getAnswer", "main.js")]
    internal static partial int GetAnswer();

    [JSImport("interop.math", "main.js")]
    internal static partial int Math(int a, int b, int c);

    [JSImport("interop.greet", "main.js")]
    internal static partial string Greet(string name);

    [UnmanagedCallersOnly(EntryPoint = "BrowserConsoleApp_MyClass_GetAnswer2")]
    internal static int GetAnswer2() => 42;
}
