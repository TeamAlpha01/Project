using System;

class Program
{
    static void Main (string[]args)
    {
        Console.WriteLine("Hello World");
        int yy = Add(4,5);
        Console.WriteLine(yy);
    } 
    public static int Add(int x, int y)
    {
        return (x+y);
    }
    public static int Sub(int x, int y)
    {
        return (x-y);
    }
}