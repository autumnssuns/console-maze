using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Maze maze = new Maze(9, 9);
            maze.Generate();
            maze.Print();
        }
        static void Print<T>(T[] arr)
        {
            Console.WriteLine($"[{string.Join(", ", arr.Select(elem => $"'{elem}'"))}]");
        }
    }
}
