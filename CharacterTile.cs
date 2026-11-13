using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Reflection.Metadata.Ecma335;
using System.Text;



namespace The_Landers
{

    public abstract class CharacterTile : Tile
    {
        private int hitPoints;
        private int maxHitPoints;
        private int attackPower;
        private Tile[] vision;

        private int doubleDamageCount;

        protected CharacterTile(Postion_class position, int hitPoints, int attackPower) : base(position)
        {
            this.hitPoints = hitPoints;
            this.maxHitPoints = hitPoints;
            this.attackPower = attackPower;
            vision = new Tile[4];
        }

        public int HitPoints { get { return hitPoints; } }
        public int MaxHitPoints { get { return maxHitPoints; } }
        public int AttackPower { get { return attackPower; } }
        public Tile[] Vision { get { return vision; } }

        public void UpdateVision(Level1 level)
        {
            Tile[,] levelTiles = level.Tiles;
            vision[(int)Direction.Up] = GetTileAt(levelTiles, level, PositionX, PositionY - 1);
            vision[(int)Direction.Right] = GetTileAt(levelTiles, level, PositionX + 1, PositionY);
            vision[(int)Direction.Down] = GetTileAt(levelTiles, level, PositionX, PositionY + 1);
            vision[(int)Direction.Left] = GetTileAt(levelTiles, level, PositionX - 1, PositionY);
        }

        private Tile GetTileAt(Tile[,] levelTiles, Level1 level, int x, int y)
        {
            if (x < 0 || x >= level.Width || y < 0 || y >= level.Height) return null;
            return levelTiles[x, y];
        }

        public void TakeDamage(int damage) { hitPoints -= damage; if (hitPoints < 0) hitPoints = 0; }

        // Restores hit points which is used by pickups.
        public void Heal(int amount)
        {
            hitPoints += amount;
            if (hitPoints > maxHitPoints)

            { 
              hitPoints = maxHitPoints;
            }
        }

        public void SetDoubleDamage(int count)
        {
            doubleDamageCount += count;
            
        }

        public void Attack(CharacterTile target) 
        { 
            if (doubleDamageCount > 0)
            {
                target.TakeDamage(attackPower * 2);
                doubleDamageCount--;
            }
            else
            {
                target.TakeDamage(attackPower);
            }

        }

        public void SetHitpoints(int value)
        { 
            hitPoints = Math.Max(0, Math.Min(value, maxHitPoints));
        }

        public bool IsDead { get { return !(hitPoints > 0); } }
    }
}



