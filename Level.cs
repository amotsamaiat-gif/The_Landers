using System;
using System.Collections.Generic;
using System.Text;

namespace The_Landers
{
    public class Level1
    {
        public enum TileType // types of tiles we can ask the level to create or have.
        {
            Empty,
            wall,
        }

        private Tile[,] tiles;
        public int Width;
        public int Height;

        public int width // check level size and grid for level 
        {
            get { return width; }
            set { width = value; }
        }

        public int height
        {
            get { return height; }
            set { height = value; }
        }

        public Tile[,] Tiles // fills the array size with the tiles it generates 
        {
            get { return tiles; }
            set { tiles = value; }
        }

        public Level1(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            tiles = new Tile[width, height];
            InitialiseTiles();

        }


        private Tile CreateTile(TileType type, Postion_class position) //builds tile type based on eneum type and position 
        {
            Tile tile;
            switch (type) // add later content for the game 
            {
                case TileType.wall:
                    tile = new WallTile(position);
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
        }

        public override string ToString()
        {
            string result = "";
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    result += tiles[x, y].Display;
                }
                result += "\n";

            }
            return result;
        }


    }
}
