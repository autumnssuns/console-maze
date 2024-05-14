namespace ConsoleMaze 
{
    /// <summary>
    /// Represents an abstract MazeGenerator class that implements the IGenerator interface.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the MazeGenerator class with the specified Maze.
    /// </remarks>
    /// <param name="maze">The Maze object that the MazeGenerator will operate on.</param>
    abstract class MazeGenerator(Maze maze) : IGenerator
    {
        /// <summary>
        /// The Maze object that the MazeGenerator will operate on.
        /// </summary>
        protected Maze maze = maze;

        /// <summary>
        /// An abstract method for generating the maze.
        /// </summary>
        public abstract void Generate();
    }
}