// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

import { dotnet, exit } from './dotnet.js'

dotnet.withConfig({
    resources: {
        jsModuleRuntime: { "dotnet.runtime.js": "" },
        jsModuleNative: { "dotnet.native.js": "" },
        wasmNative: { "dotnet.native.wasm": "" }
    }
}).withApplicationArguments("A", "B", "C");

const { setModuleImports, getAssemblyExports, runMain, getConfig } = await dotnet.create();

setModuleImports('main.js', {
    interop: {
        getAnswer: () => 42,
        math: (a, b, c) => a + b * c,
        greet: name => `Hello, ${name}`
    }
});

// const exports = await getAssemblyExports('BrowserConsoleApp.dll');
// console.log(`The result of Greeting is ${exports.Xyz.Interop.MyClass.Greeting()}`);

var result = await runMain(getConfig().mainAssemblyName);
console.log(`Exit code ${result}`);
