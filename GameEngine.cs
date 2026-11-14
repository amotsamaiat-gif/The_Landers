using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace The_Landers
{
    public class GameEngine
    {
        private Level1 currentLevel; // level played 
        private int numberoflevel1s; // number of levels to be played
        private Random random;// random number generator for level size

        private GameState gamestate;

        private int currentlevelnumber = 1; // current level number
        public int CurrentLevelNumber
        {
            get { return currentlevelnumber; }
        }

        // Returns the hero's hit points as a string, e.g. 35/40
        public string Herostats
        {
            get { return currentLevel.PlayerTile.HitPoints + "/" + currentLevel.PlayerTile.MaxHitPoints; }
        }

        // enemies only move once for every 2 successful hero moves
        private int successfulMoves;

        private const string SaveFileName = "GameSaveData.dat";

        // constants that never change for the minimum and maximum size of the level
        private const int MIN_Size = 10;
        private const int MAX_Size = 20;

        public GameEngine(int numberoflevel1s)
        {
            this.numberoflevel1s = numberoflevel1s;
            random = new Random();
            currentlevelnumber = 1;
            gamestate = GameState.InProgress;

            int width = random.Next(MIN_Size, MAX_Size + 1);
            int height = random.Next(MIN_Size, MAX_Size + 1);
            currentLevel = new Level1(width, height, currentlevelnumber, 1);
        }

        public override string ToString()
        {
            if (gamestate == GameState.Complete)
            {
                return "You have completed the game!";
            }
            else if (gamestate == GameState.GameOver)
            {
                return "Game Over!";
            }

            return currentLevel.ToString();
        }

        // new random sized level, one more enemy each time, same hero carried over
        private void NextLevel()
        {
            if (currentlevelnumber < numberoflevel1s)
            {
                currentlevelnumber++;
                int width = random.Next(MIN_Size, MAX_Size + 1);
                int height = random.Next(MIN_Size, MAX_Size + 1);
                currentLevel = new Level1(width, height, currentlevelnumber, 1);
            }
        }

        // every living enemy tries to move using its own GetMove
        private void MoveEnemies()
        {
            foreach (EnemyTile enemy in currentLevel.Enemies)
            {
                if (enemy.IsDead)
                {
                    continue;
                }

                Tile moveTarget;
                bool hasmove = enemy.GetMove(out moveTarget);

                if (!hasmove)
                {
                    continue;
                }

                currentLevel.SwapTiles(enemy, moveTarget);
                currentLevel.updateVision();
            }
        }

        // attacks whatever character is in that direction, false if nothing was hit
        private bool HeroAttack(Direction direction)
        {
            PlayerTile hero = currentLevel.PlayerTile;
            Tile targetTile = hero.Vision[(int)direction];

            if (targetTile is CharacterTile targetCharacter)
            {
                hero.Attack(targetCharacter);
                return true;
            }

            return false;
        }

        public void TriggerHeroAttack(Direction direction)
        {
            // guard clause, nothing happens once the game is over or won
            if (gamestate == GameState.GameOver || gamestate == GameState.Complete)
            {
                return;
            }

            bool attackSuccessful = HeroAttack(direction);

            if (attackSuccessful)
            {
                EnemiesAttack();

                if (currentLevel.PlayerTile.IsDead)
                {
                    gamestate = GameState.GameOver;
                }
            }

            // unlock the exit if that attack killed the last enemy
            currentLevel.UpdateExit();
        }

        // every living enemy attacks all of its targets
        private void EnemiesAttack()
        {
            foreach (EnemyTile enemy in currentLevel.Enemies)
            {
                if (enemy.IsDead)
                {
                    continue;
                }

                CharacterTile[] targets = enemy.GetTargets();
                foreach (CharacterTile target in targets)
                {
                    enemy.Attack(target);
                }
            }
        }

        private bool MovePlayer(Direction direction)
        {
            PlayerTile hero = currentLevel.PlayerTile;
            Tile targetTile = hero.Vision[(int)direction];

            if (targetTile is ExitTile exit)
            {
                // can't go through until every enemy is dead
                if (exit.Locked)
                {
                    return false;
                }

                if (currentlevelnumber >= numberoflevel1s)
                {
                    gamestate = GameState.Complete;
                    return false;
                }
                NextLevel();
                return true;
            }

            if (targetTile is PickupTiles pickup)
            {
                pickup.ActivatePickup(hero);
                currentLevel.SwapTiles(hero, targetTile);

                // the pickup is now on the tile the hero left, so swap it for an empty tile
                currentLevel.Tiles[targetTile.PositionX, targetTile.PositionY] =
                    new EmptyTile(new Postion_class(targetTile.PositionX, targetTile.PositionY));

                currentLevel.updateVision();
                successfulMoves++;

                if (successfulMoves % 2 == 0)
                {
                    MoveEnemies();
                }
                return true;
            }

            if (!(targetTile is EmptyTile))
            {
                return false;
            }

            currentLevel.SwapTiles(hero, targetTile);
            currentLevel.updateVision();
            successfulMoves++;

            if (successfulMoves % 2 == 0)
            {
                MoveEnemies();
            }

            return true;
        }

        public bool ActivateMovement(Direction direction)
        {
            // guard clause, no moving once the game is over or won
            if (gamestate == GameState.GameOver || gamestate == GameState.Complete)
            {
                return false;
            }
            return MovePlayer(direction);
        }

        // saves the number of levels, the current level number and the level to a binary file
        public void SaveGame()
        {
            GameSaveData data = new GameSaveData(numberoflevel1s, currentlevelnumber, currentLevel);

            using (FileStream stream = new FileStream(SaveFileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, data);
            }
        }

        // reads the binary file and puts the saved values back into the game
        public bool LoadGame()
        {
            // nothing to load if the player never saved
            if (!File.Exists(SaveFileName))
            {
                return false;
            }

            using (FileStream stream = new FileStream(SaveFileName, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                GameSaveData data = (GameSaveData)formatter.Deserialize(stream);

                numberoflevel1s = data.NumberOfLevels;
                currentlevelnumber = data.CurrentLevelNumber;
                currentLevel = data.CurrentLevel;
            }

            // a loaded game is always in progress, even if you saved before dying
            gamestate = GameState.InProgress;
            return true;
        }
    }
}