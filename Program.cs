using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Spark.Sql;
using static Microsoft.Spark.Sql.Functions;




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
            spark_program.spark_funct();
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
    class spark_program
    {
        public static void spark_funct()
        {
            // Create a Spark session.
            SparkSession spark = SparkSession.Builder().AppName("word_count_sample").GetOrCreate();
            
            // Create initial DataFrame.
            DataFrame dataFrame = spark.Read().Text("input.txt");
            
            // Count words.
            DataFrame words = dataFrame.Select(Functions.Split(Functions.Col("value"), " ").Alias("words"))
                .Select(Functions.Explode(Functions .Col("words"))
                .Alias("word"))
                .GroupBy("word")
                .Count()
                .OrderBy(Functions.Col("count").Desc());
            
            // Show results.
            words.Show();
            
            // Stop Spark session.
            spark.Stop();
        }
    }
}
