using System;

namespace StringTask
{
    class StringTest
    {
        static void Main(string[] args)
        {
            StringHandler test = new StringHandler();
            Console.WriteLine(test.StrEnd("ancd", "cd"));
            Console.WriteLine(test.StrEnd("ancdx", "cd"));
        }
    }
}
