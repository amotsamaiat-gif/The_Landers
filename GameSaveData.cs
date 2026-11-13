using System;
using System.Collections.Generic;
using System.Text;

namespace The_Landers
{
    [Serializable]
    public class GameSaveData
    {
        public int NumberOfLevels;
        public int CurrentLevelNumber;

        public Level1 CurrentLevel;

        public GameSaveData(int numberofLevels, int currentLevelNumber,Level1 currentLevel) 
        {
            NumberOfLevels = numberofLevels;
            CurrentLevelNumber = currentLevelNumber;
            CurrentLevel = currentLevel;


        }
    }
}
