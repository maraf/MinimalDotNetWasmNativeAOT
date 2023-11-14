# Hacking dotnet.js

```sh
cd DotnetJsHack
```

## Build

```sh
C:\Bin\dotnet-sdk-8.0.100-rc.2.23502.2-win-x64\dotnet.exe build -c Release -p:NativeDebugSymbols=false -bl ..\BrowserConsoleApp\
```

## Copy output

```sh
cp -r ..\BrowserConsoleApp\bin\Release\net8.0\browser-wasm\publish\*.* .\
```

## Run

```sh
dotnet serve
```
