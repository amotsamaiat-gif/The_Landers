using System;
using System.Collections.Generic;
using System.Text;

namespace The_Landers
{
    public class WarlockTile : EnemyTile
    {
        public WarlockTile(Postion_class postion, Level1 level) : base(postion, 10, 5, level)
        { 
        }

        public override char Display 
        { 
            get { return IsDead ? 'x': 'A'; }
        }

        public override bool GetMove(out Tile moveTarget)
        {
            moveTarget = null;
            return false;
        }

        public override CharacterTile[] GetTargets()
        {
            List<CharacterTile> targets = new List<CharacterTile>();

            for (int x = PositionX - 1; x >= PositionX + 1; x++)
            {
                for (int y = PositionY - 1; y >= PositionY + 1; y++)
                {
                    if (x == PositionX && y== PositionY)
                    {
                        continue;
                    }

                    if (x <0 || x >= level1.Width || y < 0 || y>= level1.Height)
                    {
                        continue;
                    }

                    if (level1.Tiles[x, y] is CharacterTile character)
                    {
                        targets.Add(character);
                    }
                }
            }

            return targets.ToArray();
        }
    }
}
