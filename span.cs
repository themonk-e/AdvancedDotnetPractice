 using System;
public static class SpanExplanation
{
    public static void printSpanTaskOutputs()
    {

        //span
        // task 1
        string input = "John,David,Michael,Sara";
        ReadOnlySpan<char> slice = input.AsSpan(0, 6);
        Console.WriteLine(slice.ToString());

        //task 2
        //span
        // Mutable struct that represents a slice of contiguous memory.
        // Can be used on the stack (very fast, but limited to the lifetime of the method).
        // Works with arrays, stackalloc memory, strings (via .AsSpan()).

        //ReadOnlySpan
        //Immutable version of Span<T>.
        // You can read from it but not write.
        // Useful for safely exposing memory without allowing modifications.
        // Commonly used with strings since strings are immutable.

        Span<int> numbers = new int[] { 1, 2, 3, 4, 5, 6 };
        ReadOnlySpan<int> slicedArr = numbers.Slice(0, 4);
        foreach (int nums in slicedArr)
        {
            Console.WriteLine(nums);
        }
        Console.WriteLine();

        //task 3
        // Memory<T>
        // Similar to Span<T>, but can be stored in fields and async methods.
        // Span<T> can only live on the stack → so you cannot store it in fields or use across await.
        // Memory<T> works on the heap → safer for long-lived objects.
        Memory<int> newNums = new int[] { 1, 2, 3, 4, 5 };
        Memory<int> mid = newNums.Slice(4);
        foreach (int nums in mid.ToArray())
        {
            Console.WriteLine(nums);
        }

        Console.WriteLine();
        //task 4
        // ReadOnlyMemory<T>
        // Just like Memory<T>, but immutable.
        // Often used for APIs that need to return data without letting consumers modify it.

        string name = "SuperMan";
        ReadOnlyMemory<char> memory = name.AsMemory(5);
        Console.WriteLine(memory);
    }
}