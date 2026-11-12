using System;
using System.Collections.Generic;
using System.Text;

namespace The_Landers
{
    public class TyrantTile : EnemyTile
    {
        public TyrantTile(Postion_class postion, Level1 level) : base (postion, 15, 5, level)
        { 
        }

        public override char Display
        {
            get { return IsDead ? 'x' : '§'; }
        }

        public override bool GetMove(out Tile moveTarget)
        {
            int distx = level1.PlayerTile.PositionX - PositionX;
            int disty = level1.PlayerTile.PositionY - PositionY;

            Tile horizontal = null;
            Tile vertical = null;

            if (distx != 0)
            {
                horizontal = level1.Tiles[PositionX + Math.Sign(distx), PositionY];
            }
            if (disty != 0)
            {
                vertical = level1.Tiles[PositionX, PositionY + Math.Sign(disty)];
            }

            Tile first;
            Tile second;
            if (Math.Abs(distx) >= Math.Abs(disty))
            {
                first = horizontal;
                second = vertical;
            }
            else
            {
                first = vertical;
                second = horizontal;
            }

            if (first is EmptyTile)
            {
                moveTarget = first;
                return true;
            }
             if (second is EmptyTile)
            {
                moveTarget = second;
                return true;
            }
            
            {
                moveTarget = null;
                return false;
            }
        }

        public override CharacterTile[] GetTargets()
        {
            List<CharacterTile> targets = new List<CharacterTile>();

            for (int x = 0; x < level1.Width; x++)
            {
               if (x != PositionX && level1.Tiles[x, PositionY] is CharacterTile inRow)
                {
                    targets.Add(inRow);
                }
            }

            for (int y = 0; y < level1.Height; y++)
            {
                if (y != PositionY && level1.Tiles[PositionX, y] is CharacterTile inColumn)
                {
                    targets.Add(inColumn);
                }
            }

            return targets.ToArray();
        }
    }
}
