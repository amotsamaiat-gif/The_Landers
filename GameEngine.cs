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

        private GameState gamestate;

        private int currentlevelnumber = 1; // current level number
        public int CurrentLevelNumber 
        { 
            get { return currentlevelnumber; } 
        }

        public string Herostats
        {
            get { return currentLevel.PlayerTile.HitPoints + "/" + currentLevel.PlayerTile.MaxHitPoints; }
        }

        private int successfulMoves;

        // constants that never change for the minimum and maximum size of the level
        private const int MIN_Size = 10;
        private const int MAX_Size = 20;

        //
        public GameEngine(int numberoflevel1s)
        {
            this.numberoflevel1s = numberoflevel1s;
            random = new Random();
            currentlevelnumber = 1;
            gamestate = GameState.InProgress;

            int width = random.Next(MIN_Size, MAX_Size + 1);
            int height = random.Next(MIN_Size, MAX_Size + 1);
            currentLevel = new Level1(width, height, currentlevelnumber);

            currentlevelnumber = 1;
            gamestate = GameState.InProgress;
        }

        public override string ToString()
        {
            if (gamestate == GameState.Complete)
            {
                return "You have completed the game!";
            }
            else if (gamestate == GameState.InProgress)
            {
                return currentLevel.ToString();
            }

            return currentLevel.ToString();
        }

        private void NextLevel()
        {
            if (currentlevelnumber < numberoflevel1s)
            {
                currentlevelnumber++;
                int width = random.Next(MIN_Size, MAX_Size + 1);
                int height = random.Next(MIN_Size, MAX_Size + 1);
                currentLevel = new Level1(width, height, currentlevelnumber);
            }
            
        }

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
            if (gamestate == GameState.Complete)
            {
                return;
            }

            bool attackSuccessful = HeroAttack(direction);

            if (attackSuccessful)
            {
                MoveEnemies();

                if (currentLevel.PlayerTile.IsDead)
                {
                    gamestate = GameState.Complete;
                }
            }
        }

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

            if (targetTile is ExitTile)
            {
                if (currentlevelnumber >= numberoflevel1s)
                {
                    gamestate = GameState.Complete;
                    return false;
                }
                NextLevel();
                return true;

            }

            if (!(targetTile is EmptyTile))
            {
                // Perform the move
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
            if (gamestate == GameState.Complete)
            {
                return false;
            }
            return MovePlayer(direction);
        }

    }
}
