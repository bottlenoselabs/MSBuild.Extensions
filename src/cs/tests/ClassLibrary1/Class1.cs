// Copyright (c) Bottlenose Labs Inc. (https://github.com/bottlenoselabs). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

namespace ClassLibrary1;

public class Class1
{
    private readonly string _x;

    public Class1(string x)
    {
        _x = x;
    }

    public void X()
    {
        Console.Write(_x);
    }
}
