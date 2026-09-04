using System;
using System.Collections.Generic;
using System.Text;

namespace The_Landers
{
    public class GameEngine
    {
        private Level1 currentLevel; // level played 
        private int numberoflevel1s; // number of levels to be played
        private Random random;// random number generator for level size

        // constants that never change for the minimum and maximum size of the level
        private const int MIN_Size = 10;
        private const int MAX_Size = 20;

        //
        public GameEngine(int numberoflevel1s)
        {
            this.numberoflevel1s = numberoflevel1s;
            random = new Random();

            int width = random.Next(MIN_Size, MAX_Size + 1);
            int height = random.Next(MIN_Size, MAX_Size + 1);
            currentLevel = new Level1(width, height);
        }
        
        public override string ToString()
        {
            return currentLevel.ToString();
        }
    }
}
