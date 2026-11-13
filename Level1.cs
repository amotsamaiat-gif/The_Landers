using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace The_Landers
{
    public class Level1
    {
        public enum TileType // types of tiles we can ask the level to create or have.
        {
            Empty,
            wall,
            hero,
            exit,
            
            Enemy
        }

        private Tile[,] tiles;
        public int Width;
        public int Height;

    
        public Tile[,] Tiles // fills the array size with the tiles it generates 
        {
            get { return tiles; }
            set { tiles = value; }
        }

        public Level1(int width, int height, int numberOfEnemies)
        {
            this.Width = width;
            this.Height = height;
            tiles = new Tile[width, height];
            InitialiseTiles();

            Postion_class heroPosition = GetRandomEmptyPosition();
            playerTile = (PlayerTile) CreateTile(TileType.hero, heroPosition);
            playerTile.UpdateVision(this);

            Postion_class exitPosition = GetRandomEmptyPosition();
            exitTile = (ExitTile)CreateTile(TileType.exit, exitPosition);

            enemies = new EnemyTile[numberOfEnemies];
            for (int i = 0; i < numberOfEnemies; i++)
            {
                Postion_class enemyPosition = GetRandomEmptyPosition();
                enemies[i] = (EnemyTile)CreateTile(TileType.Enemy, enemyPosition);
                
            }

        }

        public override string ToString()
        {
            string result = "";
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    result += tiles[x, y].Display;
                }
                result += "\n";
            }
            return result;
        }

        private PlayerTile playerTile;
        public PlayerTile PlayerTile
        {
            get { return playerTile; }
        }

        private ExitTile exitTile;
        public ExitTile ExitTile
        {
            get { return exitTile; }
        }
        private Random random = new Random();
        private EnemyTile[] enemies;
        public EnemyTile[] Enemies
        {
            get { return enemies; }
            
        }

        private Tile CreateTile(TileType type, Postion_class position) //builds tile type based on eneum type and position 
        {
            Tile tile;
            switch (type) // add later content for the game 
            {
                case TileType.wall:
                    tile = new WallTile(position);
                    break;
                case TileType.hero:
                    tile = new PlayerTile(position);
                    break;
                case TileType.exit:
                    tile = new ExitTile(position);
                    break;
                case TileType.Enemy:
                    tile = CreateEnemyTile(type,position);
                    break;
                case TileType.Empty:
                default:
                    tile = new EmptyTile(position);
                    break;
   
            }

            tiles[position.postionX, position.postionY] = tile;
            return tile; //create the tile, it also places it into the grid at its own position. Then it returns the tile too,
        }

        private Tile CreateTile(TileType type, int x, int y) // calls the create tile mrthod with numbers instead of creating a postion 
        {
            return CreateTile(type, new Postion_class(x, y));

        }
        // picks a random enemy type: 50% grunt, 30% warlock, 20% tyrant
        private EnemyTile CreateEnemyTile(TileType type, Postion_class position)
        {
            int roll = random.Next(100);// a number from 0 to 99

            if (roll < 50)
            {
                return new GruntTile(position, this);
            }
            else if (roll < 80)
            {
                return new WarlockTile(position, this);
            }
            else
            {
                return new TyrantTile(position, this);
            }

        }
        
        private void InitialiseTiles() // creates the grid of tiles for the level 
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    bool isBoundary = (x == 0 || x == Width - 1 || y == 0 || y == Height - 1);
                    if (isBoundary)
                    
                    {
                        CreateTile(TileType.wall, x, y);
                    }
                    else
                    {
                        CreateTile(TileType.Empty, x, y);
                    }
                }
            }

        }

        public void SwapTiles(Tile tileA, Tile tileB) // swaps the tiles in the grid 
        {
            Postion_class positionA = new Postion_class(tileA.Position.postionX, tileA.Position.postionY);
            Postion_class positionB = new Postion_class(tileB.Position.postionX, tileB.Position.postionY);

            tileA.Position = positionB;
            tileB.Position = positionA;

            tiles[tileA.Position.postionX, tileA.Position.postionY] = tileA;
            tiles[tileB.Position.postionX, tileB.Position.postionY] = tileB;
        }

        public void updateVision() // updates the vision of the player and all enemies 
        {
            playerTile.UpdateVision(this);

            foreach (EnemyTile enemy in enemies)
            {
                enemy.UpdateVision(this);
            }
        }

        public void UpdateExit() // unlocks the exit once the level is dead 
        {
            foreach (EnemyTile enemy in enemies)
            {
                if (!enemy.IsDead)
                {
                    return; // an enemy is still alive, so the exit stays locked
                }

            }
        } 


        private Postion_class GetRandomEmptyPosition() // gets a random position for the player to spawn in 
        {
            Random random = new Random();
            int x, y;
            do
            {
                x = random.Next(1, Width - 1);
                y = random.Next(1, Height - 1);
            } while (!(tiles[x, y] is EmptyTile)); // keep generating new positions until we find an empty one
            return new Postion_class(x, y);
        }




        


    }
}
