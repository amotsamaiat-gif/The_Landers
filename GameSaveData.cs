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

        public GameSaveData(int numberOfLevels, int currentLevelNumber, Level1 currentLevel)
        {
            NumberOfLevels = numberOfLevels;
            CurrentLevelNumber = currentLevelNumber;
            CurrentLevel = currentLevel;
        }
    }
}
