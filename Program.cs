using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

const int arraySize = 64;
IntPtr src = Marshal.AllocHGlobal(arraySize * sizeof(int));
unsafe
{
    new Span<int>(src.ToPointer(), arraySize).Fill(42);
}
var dst = new int[arraySize];
Vortice.Interop.Read(src, dst);
unsafe
{
    Debug.Assert(new Span<int>(src.ToPointer(), arraySize).SequenceEqual(dst));
}
