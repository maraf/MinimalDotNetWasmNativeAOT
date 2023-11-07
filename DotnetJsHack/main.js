// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

import { dotnet, exit } from './dotnet.js'

try {
    dotnet.withConfig({
        resources: {
            jsModuleNative: { "dotnet.native.js": "" },
            jsModuleRuntime: { "dotnet.runtime.js": "" },
            wasmNative: { "BrowserConsoleApp.wasm": ""}
        }
    })
    await dotnet.run();
}
catch (err) {
    exit(2, err);
}