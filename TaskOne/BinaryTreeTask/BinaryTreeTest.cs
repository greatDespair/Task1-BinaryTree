using System;

namespace BinaryTreeTask
{
    class BinaryTreeTest
    {
        static void Main(string[] args)
        {
            SearchBinaryTreePrimes test = new SearchBinaryTreePrimes();
            test.GenerateTree(1000);

            int[] timeResults = test.GetTimeStats();

            Console.WriteLine("Симметричный обход в глубину занял: " + timeResults[0] + " тиков.");
            Console.WriteLine("Прямой обход в глубину занял: " + timeResults[1] + " тиков.");
            Console.WriteLine("Обход в ширину занял: " + timeResults[2] + " тиков.");

            JsonTreeWriter treeWriter = new JsonTreeWriter();
            treeWriter.WriteTreeToFile(test);
            Console.WriteLine(test.GetStringPrimes());
        }
    }
}
