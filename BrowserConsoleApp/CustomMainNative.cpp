// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#include <stdio.h>
#include <stdint.h>

extern "C" int __managed__Main(int argc, char* argv[]);

int main(int argc, char* argv[])
{
    puts("hello from native main");
    return __managed__Main(argc, argv);
}
