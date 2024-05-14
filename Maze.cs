namespace ConsoleMaze
{
    /// <summary>
    /// Represents a Maze class.
    /// </summary>
    internal class Maze
    {
        bool[,] maze;
        private int width;
        private int height;

        /// <summary>
        /// Gets or sets the value of the maze at the specified coordinates.
        /// </summary>
        public bool this[int x, int y]
        {
            get
            {
                return maze[x, y];
            }
            set
            {
                maze[x, y] = value;
            }
        }

        /// <summary>
        /// Gets the width of the maze.
        /// </summary>
        public int Width => width;

        /// <summary>
        /// Gets the height of the maze.
        /// </summary>
        public int Height => height;

        /// <summary>
        /// Initializes a new instance of the Maze class with the specified width and height.
        /// </summary>
        public Maze(int width, int height)
        {
            maze = new bool[width, height];
            this.width = width;
            this.height = height;
            // Four walls around
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                maze[row, 0] = true;
                maze[row, width - 1] = true;
            }
            for (int col = 0; col < maze.GetLength(0); col++)
            {
                maze[0, col] = true;
                maze[height - 1, col] = true;
            }
        }

        /// <summary>
        /// Prints the maze to the console.
        /// </summary>
        public void Print(IEnumerable<Point>? path = null)
        {
            Console.Clear();
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    string c = maze[row, col] ? "██" : "  ";
                    if (path != null && path.Contains(new Point(row, col)))
                    {
                        c = "░░";
                    }
                    Console.Write(c);
                }
                Console.WriteLine();
            }
        }
    }
}