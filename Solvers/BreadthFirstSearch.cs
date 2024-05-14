namespace ConsoleMaze
{
    /// <summary>
    /// Represents a breadth-first search solver.
    /// </summary>
    internal class BreadthFirstSearch(Maze maze, Point start, Point end) : Solver(maze, start, end)
    {
        private readonly Queue<Point> queue = new Queue<Point>();
        private readonly Dictionary<Point, Point> cameFrom = new Dictionary<Point, Point>();
        private readonly HashSet<Point> visited = new HashSet<Point>();

        public override IEnumerable<Point> Solve()
        {
            queue.Enqueue(Start);
            cameFrom[Start] = null;

            while (queue.Count > 0)
            {
                Point current = queue.Dequeue();
                visited.Add(current);

                if (current == End)
                {
                    return ReconstructPath(current);
                }

                foreach (Point neighbor in GetNeighbors(current))
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        cameFrom[neighbor] = current;
                    }
                }
            }

            return Enumerable.Empty<Point>();
        }

        private IEnumerable<Point> ReconstructPath(Point current)
        {
            List<Point> path = new List<Point>();
            while (current != null)
            {
                path.Add(current);
                current = cameFrom[current];
            }
            path.Reverse();
            return path;
        }
    }
}