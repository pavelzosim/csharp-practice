using System;
using System.Security.Authentication;

namespace csharp_learn
{
    internal class Practice26_array
    {
        public static void Run()
        {
            int[] array = { 2, 3, 4, 7, 8 };
            int sum = 0;
            int maxElement;
            
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Element at index {i}: {array[i]}");
                
                
                
                sum += array[i];
            }

            Console.WriteLine($"Sum of array elements: {sum}");
        }
    }
}