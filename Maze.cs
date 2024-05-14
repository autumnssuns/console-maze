using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    internal class Maze
    {
        bool[,] maze;
        private int width;
        private int height;
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
        public void Generate()
        {
            RecurDivision(1, 1, width - 2, height - 2);
        }
        private void RecurDivision(
            int topLeftX, 
            int topLeftY, 
            int bottomRightX,
            int bottomRightY)
        {
            if (bottomRightY - topLeftY < 2) return;
            if (bottomRightX - topLeftX < 2) return;
            // Select random even number
            Random rand = new Random();

            // Horizontal wall
            int wallH = rand.Next(topLeftY, bottomRightY);
            int wallHHole = rand.Next(topLeftX, bottomRightX + 1);
            while (wallH % 2 != 0) wallH = rand.Next(topLeftY, bottomRightY);
            for (int col = topLeftX; col <= bottomRightX; col++)
            {
                maze[wallH, col] = col != wallHHole;
            }

            // Vertical wall
            int wallV = rand.Next(topLeftX, bottomRightX);
            while (wallV % 2 != 0) wallV = rand.Next(topLeftX, bottomRightX);

            for (int row = topLeftY; row <= bottomRightY; row++)
            {
                maze[row, wallV] = true;
            }

            // Hole above H-Wall
            int wallVHole = rand.Next(topLeftY, wallH);
            while (Math.Abs(wallVHole - wallH) <= 0) wallVHole = rand.Next(topLeftY, wallH);
            maze[wallVHole, wallV] = false;

            // Hole below H-Wall
            wallVHole = rand.Next(wallH + 1, bottomRightY + 1);
            while (Math.Abs(wallVHole - wallH) <= 0) wallVHole = rand.Next(topLeftY, wallH);
            maze[wallVHole, wallV] = false;

            // Do the same for each chamber
            // top left
            RecurDivision(topLeftX, topLeftY, wallV - 1, wallH - 1);
            // top right
            RecurDivision(wallV + 1, topLeftY, bottomRightX, wallH - 1);
            // bottom left
            RecurDivision(topLeftX, wallH + 1, wallV - 1, bottomRightY);
            // bottom right
            RecurDivision(wallV + 1, wallH + 1, bottomRightX, bottomRightY);
        }
        public void Print()
        {
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    string c = maze[row, col] ? "██" : "  ";
                    Console.Write(c);
                }
                Console.WriteLine();
            }
        }
    }
}
