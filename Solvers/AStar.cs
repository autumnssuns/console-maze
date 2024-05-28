using System.Reflection.Metadata.Ecma335;

namespace ConsoleMaze
{


    /// <summary>
    /// Represents a breadth-first search solver.
    /// </summary>
    internal class AStar(Maze maze, Point start, Point end) : Solver(maze, start, end)
    {
        private readonly Dictionary<Point, Point> cameFrom = new Dictionary<Point, Point>();
        private int Heuristic(Point node) {
            // Manhattan distance
            return Math.Abs(End.X - node.X) + Math.Abs(End.Y - node.Y);
        }

        // A* Algorithm (source: https://en.wikipedia.org/wiki/A*_search_algorithm)
        public override IEnumerable<Point> Solve()
        {
            PriorityQueue<Point, int> open = new();
            Dictionary<Point, int> gScore = new();
            Dictionary<Point, int> fScore = new();
            Begin();
            gScore[Start] = 0;
            fScore[Start] = Heuristic(Start);
            cameFrom[Start] = null;
            open.Enqueue(Start, fScore[Start]);
            Visit(start);
            while (open.Count > 0) {
                Point current = open.Dequeue();
                Visit(current);
                if (current == End) return ReconstructPath(current);
                foreach (Point neighbour in GetNeighbors(current)) {
                    int tempScore = gScore[current] + 1;
                    if (tempScore < gScore.GetValueOrDefault(neighbour, int.MaxValue)) {
                        cameFrom[neighbour] = current;
                        gScore[neighbour] = tempScore;
                        fScore[neighbour] = tempScore + Heuristic(neighbour);
                        open.Enqueue(neighbour, fScore[neighbour]);
                        Probe(neighbour);
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
                Backtrack(current);
                current = cameFrom[current];
            }
            path.Reverse();
            return path;
        }
    }
}