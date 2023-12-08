# Support dotnet.js

```sh
cd DotnetJsHack
```

## Build

```sh
dotnet build -c Release -bl ..\BrowserConsoleApp\
```

## Copy output

```sh
cp -r ..\BrowserConsoleApp\bin\Release\net9.0\browser-wasm\publish\*.* .\
```

## Run

```sh
dotnet serve
```
