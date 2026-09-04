using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace The_Landers
{
    public abstract class CharacterTile : Tile
    {
        private int HitPoints; //  the hit points of the character tile
        private int MaxHitPoints; // the max hit points of the character tile
        private int AttackPower; // the attack power of the character tile
        private Tile[] Vision;
        protected CharacterTile(Postion_class position) : base(position)
        {
            this.HitPoints = HitPoints; // default hit points
            this.MaxHitPoints = MaxHitPoints; // default max hit points
            this.AttackPower = AttackPower; // default attack power
            Vision = new Tile[4];
        }
        public int hitPoints
        {
            get { return HitPoints; }

        }
        public int maxHitPoints
        {
            get { return MaxHitPoints; }

        }
        public int attackPower
        {
            get { return AttackPower; }
        }

        public Tile[] vision
        {
            get { return Vision; }

        }
        public void UpdateVision( Level1 Level)
        {
            Tile[,] levelTiles = Level.Tiles;
            Vision[(int)Direction.Up] = GetTileAt(levelTiles, Level, PositionX, PositionY - 1);
            vision[(int)Direction.Right] = GetTileAt(levelTiles, Level, PositionX + 1, PositionY);
            vision[(int)Direction.Down] = GetTileAt(levelTiles, Level, PositionX, PositionY + 1);
            Vision[(int)Direction.Left] = GetTileAt(levelTiles, Level, PositionX, PositionY - 1);

        }
        private Tile GetTileAt(Tile[,] levelTiles, Level1 level, int x, int y)
        {
            if (x < 0 || x >= level.width || y < 0 || y >= level.Height)
                return null;

            return levelTiles[x, y];
        }

        

         
    }
}
    


