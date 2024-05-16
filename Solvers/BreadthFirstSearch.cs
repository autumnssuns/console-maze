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
            Begin();
            queue.Enqueue(Start);
            cameFrom[Start] = null;
            Visit(Start);
            int count = 0;
            while (queue.Count > 0)
            {
                Point current = queue.Dequeue();
                visited.Add(current);
                count++;
                Visit(current);

                if (current == End)
                {
                    Console.WriteLine(count);
                    return ReconstructPath(current);
                }
                IEnumerable<Point> neighbors = GetNeighbors(current);

                foreach (Point neighbor in neighbors)
                {
                    if (visited.Any(p => p.X == neighbor.X && p.Y == neighbor.Y)) continue;
                    visited.Add(neighbor);
                    Probe(neighbor);
                    queue.Enqueue(neighbor);
                    cameFrom[neighbor] = current;
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
                Backtrack(current);
                current = cameFrom[current];
            }
            path.Reverse();
            return path;
        }
    }
}