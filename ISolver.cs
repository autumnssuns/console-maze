namespace ConsoleMaze
{
    /// <summary>
    /// Represents an interface for a solver.
    /// </summary>
    internal interface ISolver
    {
        Point Start { get; }
        Point End { get; }
        /// <summary>
        /// Solves the maze.
        /// </summary>
        IEnumerable<Point> Solve();
    }
}