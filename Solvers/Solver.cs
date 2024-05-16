namespace ConsoleMaze
{
    abstract class Solver : ISolver
    {
        protected Maze maze;
        public Point Start { get; }
        public Point End { get; }
        protected readonly HashSet<Format> formats = new HashSet<Format>();
        public Solver(Maze maze, Point start, Point end)
        {
            this.maze = maze;
            Start = start;
            End = end;
        }
        public IEnumerable<Point> GetNeighbors(Point point)
        {
            List<Point> neighbors = new List<Point>();
            int[] dx = { 0, 0, 1, -1 };
            int[] dy = { 1, -1, 0, 0 };
            for (int i = 0; i < 4; i++)
            {
                Point neighbor = new Point(point.X + dx[i], point.Y + dy[i]);
                if (!maze[neighbor.Y, neighbor.X])
                {
                    neighbors.Add(neighbor);
                }
            }
            return neighbors.ToArray();
        }
        public abstract IEnumerable<Point> Solve();
        protected void Begin()
        {
            Console.Clear();
            maze.Print();
            Console.CursorVisible = false;
        }
        protected void Snapshot()
        {
            foreach (Format format in formats)
            {
                Console.SetCursorPosition(format.Column * 2, format.Row);
                Console.BackgroundColor = format.Background;
                Console.ForegroundColor = format.Foreground;
                Console.Write(format.Symbol);
                Console.ResetColor();
            }
            //Console.ReadKey();
        }
        protected void Probe(Point point)
        {
            formats.RemoveWhere(item => item.Row == point.Y && item.Column == point.X);
            formats.Add(new Format(point.Y, point.X, "▒▒", ConsoleColor.Yellow));
            Snapshot();
        }
        protected void Visit(Point point)
        {
            formats.RemoveWhere(item => item.Row == point.Y && item.Column == point.X);
            formats.Add(new Format(point.Y, point.X, "▒▒", ConsoleColor.Cyan));
            Snapshot();
        }
        protected void Backtrack(Point point)
        {
            formats.RemoveWhere(item => item.Row == point.Y && item.Column == point.X);
            formats.Add(new Format(point.Y, point.X, "▒▒", ConsoleColor.Green));
            Snapshot();
        }
    }
}