namespace ConsoleMaze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Maze maze = new Maze(55, 55);
            new RecursiveDivision(maze).Generate();
            Point start = new Point(1, 1);
            Point end = new Point(maze.Width - 2, maze.Height - 2);
            Console.WriteLine($"Start: {start}");
            Console.WriteLine($"End: {end}");
            IEnumerable<Point> path = new BreadthFirstSearch(maze, start, end).Solve();
            maze.Print(path);
        }
        static void Print<T>(T[] arr)
        {
            Console.WriteLine($"[{string.Join(", ", arr.Select(elem => $"'{elem}'"))}]");
        }
    }
}