namespace ConsoleMaze
{
    /// <summary>
    /// Represents a RecursiveDivision class that extends the MazeGenerator class.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the RecursiveDivision class with the specified Maze.
    /// </remarks>
    /// <param name="maze">The Maze object that the RecursiveDivision will operate on.</param>
    internal class RecursiveDivision(Maze maze) : MazeGenerator(maze)
    {
        /// <summary>
        /// Generates the maze using the recursive division algorithm.
        /// </summary>
        public override void Generate()
        {
            RecurDivision(1, 1, maze.Width - 2, maze.Height - 2);
        }

        /// <summary>
        /// Recursively divides the maze into smaller sections, creating walls and holes.
        /// </summary>
        /// <param name="topLeftX">The x-coordinate of the top left corner of the section.</param>
        /// <param name="topLeftY">The y-coordinate of the top left corner of the section.</param>
        /// <param name="bottomRightX">The x-coordinate of the bottom right corner of the section.</param>
        /// <param name="bottomRightY">The y-coordinate of the bottom right corner of the section.</param>
        private void RecurDivision(
        int topLeftX, 
        int topLeftY, 
        int bottomRightX,
        int bottomRightY)
        {
            // Implementation omitted for brevity
      
            if (bottomRightY - topLeftY < 2) return;
            if (bottomRightX - topLeftX < 2) return;
            // Select random even number
            Random rand = new Random();

            // Horizontal wall
            int wallH = rand.Next(topLeftY, bottomRightY);
            while (wallH % 2 != 0) wallH = rand.Next(topLeftY, bottomRightY);
            for (int col = topLeftX; col <= bottomRightX; col++)
            {
                maze[wallH, col] = true;
            }

            // Vertical wall
            int wallV = rand.Next(topLeftX, bottomRightX);
            while (wallV % 2 != 0) wallV = rand.Next(topLeftX, bottomRightX);
            for (int row = topLeftY; row <= bottomRightY; row++)
            {
                maze[row, wallV] = true;
            }

            // Hole above V-Wall
            int wallHHole = rand.Next(topLeftX, wallV);
            while (wallHHole % 2 != 1) wallHHole = rand.Next(topLeftX, wallV);
            maze[wallH, wallHHole] = false;

            // Hole below V-Wall
            wallHHole = rand.Next(wallV + 1, bottomRightX + 1);
            while (wallHHole % 2 != 1) wallHHole = rand.Next(wallV + 1, bottomRightX + 1);
            maze[wallH, wallHHole] = false;


            // Hole above H-Wall
            int wallVHole = rand.Next(topLeftY, wallH);
            while (wallVHole % 2 != 1) wallVHole = rand.Next(topLeftY, wallH);
            maze[wallVHole, wallV] = false;

            // Hole below H-Wall
            wallVHole = rand.Next(wallH + 1, bottomRightY + 1);
            while (wallVHole % 2 != 1) wallVHole = rand.Next(wallH + 1, bottomRightY + 1);
            maze[wallVHole, wallV] = false;

            // Do the same for each chamber
            // top left
            RecurDivision(topLeftX, topLeftY, wallV - 1, wallH - 1);
            //// top right
            RecurDivision(wallV + 1, topLeftY, bottomRightX, wallH - 1);
            //// bottom left
            RecurDivision(topLeftX, wallH + 1, wallV - 1, bottomRightY);
            //// bottom right
            RecurDivision(wallV + 1, wallH + 1, bottomRightX, bottomRightY);
        }
    }
}