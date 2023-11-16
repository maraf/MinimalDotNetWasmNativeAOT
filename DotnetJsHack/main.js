// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

import { dotnet, exit } from './dotnet.js'

dotnet.withConfig({
    resources: {
        jsModuleNative: { "dotnet.native.js": "" },
        jsModuleRuntime: { "dotnet.runtime.js": "" },
        wasmNative: { "BrowserConsoleApp.wasm": "" }
    }
});

const { setModuleImports, getAssemblyExports, getConfig } = await dotnet.create()

setModuleImports('main.js', {
    interop: {
        getAnswer: () => 42,
        math: (a, b, c) => a + b * c,
        greet: name => `Hello, ${name}`
    }
});

var result = await dotnet.run();
console.log(`Exit code ${result}`);