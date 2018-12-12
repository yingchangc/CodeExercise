using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.OOD
{
    class DesignSnakeGame
    {
        public class Loc
        {
            public int x;
            public int y;
            public Loc(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }


        LinkedList<Loc> deq;
        HashSet<int> visited;

        int width;
        int height;

        int score;

        Queue<Loc> foodQ;

        /** Initialize your data structure here.
            @param width - screen width
            @param height - screen height 
            @param food - A list of food positions
            E.g food = [[1,1], [1,0]] means the first food is positioned at [1,1], the second is at [1,0]. */
        public DesignSnakeGame(int width, int height, int[,] food)
        {
            this.width = width;
            this.height = height;
            this.score = 0;

            deq = new LinkedList<Loc>();
            deq.AddFirst(new Loc(0, 0));  // w:0  h:0
            visited = new HashSet<int>();
            visited.Add(0);  // 0*width + 0

            foodQ = new Queue<Loc>();
            int foodCount = food.GetLength(0);
            for (int i = 0; i < foodCount; i++)
            {
                int tx = food[i, 1];
                int ty = food[i, 0];
                foodQ.Enqueue(new Loc(tx, ty));
            }
        }

        /** Moves the snake.
            @param direction - 'U' = Up, 'L' = Left, 'R' = Right, 'D' = Down 
            @return The game's score after the move. Return -1 if game over. 
            Game over when snake crosses the screen boundary or bites its body. */
        public int Move(string direction)
        {
            int deltaX = 0;
            int deltaY = 0;

            if (direction == "U")
            {
                deltaY = -1;
            }
            else if (direction == "D")
            {
                deltaY = 1;
            }
            else if (direction == "L")
            {
                deltaX = -1;
            }
            else if (direction == "R")
            {
                deltaX = 1;
            }

            int nx = deq.First().x + deltaX;
            int ny = deq.First().y + deltaY;

            // out bound
            if (nx < 0 || nx >= width || ny < 0 || ny >= height)
            {
                return -1;
            }


            // check if hit target
            if (foodQ.Count > 0)
            {
                var target = foodQ.Peek();
                if (nx == target.x && ny == target.y)
                {
                    score++;
                    foodQ.Dequeue();

                    // add Head , no need to move tail
                    int headEncode = ny * this.width + nx;
                    visited.Add(headEncode);
                    deq.AddFirst(new Loc(nx, ny));
                    return score;
                }
            }

            // move tail
            var tail = deq.Last();
            deq.RemoveLast();
            var tailEncode = tail.y * width + tail.x;
            visited.Remove(tailEncode);

            // check new head collision
            int locEncode = ny * this.width + nx;
            if (visited.Contains(locEncode))
            {
                return -1;
            }

            // can move head
            visited.Add(locEncode);
            deq.AddFirst(new Loc(nx, ny));


            return score;

        }
    }
}
