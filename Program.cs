using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



// See https://aka.ms/new-console-template for more information

namespace HelloWorld
{

    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int [] arr = {1, 2, 3, 4, 5};
            Functions_class.add(arr);
        }
    }
    public class Functions_class
    {
        public static void add(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
