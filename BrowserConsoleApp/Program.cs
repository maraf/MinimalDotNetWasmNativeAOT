using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;

Console.WriteLine("Hello, Console!");

Console.WriteLine($"Answer is '{MyClass.GetAnswer()}'");
Console.WriteLine($"Math result is '{MyClass.Math(1, 2, 3)}'");
Console.WriteLine($"Greet response is '{MyClass.Greet("Jon")}'");

return 42;

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

// namespace System.Runtime.InteropServices.JavaScript
// {
//     internal static partial class Interop
//     {
//         internal static unsafe partial class Runtime
//         {
//             [DllImport("*", EntryPoint = "mono_wasm_bind_js_function")]
//             public static extern unsafe void BindJSFunction(in string function_name, in string module_name, void* signature, out IntPtr bound_function_js_handle, out int is_exception, out object result);

//             [DllImport("*", EntryPoint = "mono_wasm_invoke_import")]
//             public static extern unsafe void InvokeImport(IntPtr fn_handle, void* data);

//             internal static unsafe JSFunctionBinding BindJSFunctionImpl(string functionName, string moduleName, ReadOnlySpan<JSMarshalerType> signatures)
//             {
//                 var signature = JSHostImplementation.GetMethodSignature(signatures);

//                 Interop.Runtime.BindJSFunction(functionName, moduleName, signature.Header, out IntPtr jsFunctionHandle, out int isException, out object exceptionMessage);
//                 if (isException != 0)
//                     throw new JSException((string)exceptionMessage);

//                 signature.FnHandle = jsFunctionHandle;

//                 JSHostImplementation.FreeMethodSignatureBuffer(signature);

//                 return signature;
//             }

//             // [MethodImpl(MethodImplOptions.AggressiveInlining)]
//             internal static unsafe void InvokeImportImpl(IntPtr fnHandle, Span<JSMarshalerArgument> arguments)
//             {
//                 fixed (JSMarshalerArgument* ptr = arguments)
//                 {
//                     Interop.Runtime.InvokeImport(fnHandle, ptr);
//                     ref JSMarshalerArgument exceptionArg = ref arguments[0];
//                     if (exceptionArg.slot.Type != MarshalerType.None)
//                     {
//                         JSHostImplementation.ThrowException(ref exceptionArg);
//                     }
//                 }
//             }
//         }
//     }
// }

// // GENERATED CODE
// public unsafe partial class MyClass
// {
//     [global::System.Diagnostics.DebuggerNonUserCode]
//     internal static partial int GetAnswer()
//     {
//         if (__signature_GetAnswer_642242616 == null)
//         {
//             __signature_GetAnswer_642242616 = global::System.Runtime.InteropServices.JavaScript.JSFunctionBinding.BindJSFunction("interop.getAnswer", "main.js", new global::System.Runtime.InteropServices.JavaScript.JSMarshalerType[] { global::System.Runtime.InteropServices.JavaScript.JSMarshalerType.Int32 });
//         }

//         global::System.Span<global::System.Runtime.InteropServices.JavaScript.JSMarshalerArgument> __arguments_buffer = stackalloc global::System.Runtime.InteropServices.JavaScript.JSMarshalerArgument[2];
//         ref global::System.Runtime.InteropServices.JavaScript.JSMarshalerArgument __arg_exception = ref __arguments_buffer[0];
//         __arg_exception.Initialize();
//         ref global::System.Runtime.InteropServices.JavaScript.JSMarshalerArgument __arg_return = ref __arguments_buffer[1];
//         __arg_return.Initialize();
//         int __retVal;
//         global::System.Runtime.InteropServices.JavaScript.JSFunctionBinding.InvokeJS(__signature_GetAnswer_642242616, __arguments_buffer);
//         // UnmarshalCapture - Capture the native data into marshaller instances in case conversion to managed data throws an exception.
//         __arg_return.ToManaged(out __retVal);
//         return __retVal;
//     }

//     [global::System.ThreadStaticAttribute]
//     static global::System.Runtime.InteropServices.JavaScript.JSFunctionBinding __signature_GetAnswer_642242616;
// }