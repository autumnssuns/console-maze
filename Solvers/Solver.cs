namespace ConsoleMaze
{
    abstract class Solver : ISolver
    {
        protected Maze maze;
        public Point Start { get; }
        public Point End { get; }
        public Solver(Maze maze, Point start, Point end)
        {
            this.maze = maze;
            Start = start;
            End = end;
        }
        public IEnumerable<Point> GetNeighbors(Point point)
        {
            int[] dx = { 0, 0, 1, -1 };
            int[] dy = { 1, -1, 0, 0 };
            for (int i = 0; i < 4; i++)
            {
                Point neighbor = new Point(point.X + dx[i], point.Y + dy[i]);
                if (maze[neighbor.X, neighbor.Y] == false)
                {
                    yield return neighbor;
                }
            }
        }
        public abstract IEnumerable<Point> Solve();
    }
}