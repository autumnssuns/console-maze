using System.Linq;

namespace ConsoleMaze
{
    internal record Format(int row, int col, string symbol, ConsoleColor fg = ConsoleColor.White, ConsoleColor bg = ConsoleColor.Black)
    {
        public int Row { get; private set; } = row;
        public int Column { get; private set; } = col;
        public string Symbol { get; private set; } = symbol;
        public ConsoleColor Foreground { get; private set; } = fg;
        public ConsoleColor Background { get; private set; } = bg;
        public const ConsoleColor DEFAULT_BG = ConsoleColor.Black;
        public const ConsoleColor DEFAULT_FG = ConsoleColor.White;
    }

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
        public void Print(IEnumerable<Format>? formats = null)
        {
            Console.Clear();
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    string c = maze[row, col] ? "██" : "  ";
                    Format? format = formats?.FirstOrDefault(f => f?.Row == row && f?.Column == col, null);
                    string symbol = format?.Symbol ?? c;
                    Console.BackgroundColor = format?.Background ?? Format.DEFAULT_BG;
                    Console.ForegroundColor = format?.Foreground ?? Format.DEFAULT_FG;
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
        }
    }
}