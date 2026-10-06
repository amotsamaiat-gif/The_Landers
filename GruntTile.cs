using System;
using System.Collections.Generic;
using System.Text;

namespace The_Landers
{
    public class GruntTile : EnemyTile
    {
        private Random random;
        public GruntTile(Postion_class position) : base(position, 10, 1)
        {
            random = new Random();
        }
        public override char Display
        {
            get { return IsDead ? 'x' : 'X'; }
        }
        public override bool GetMove(out Tile movetarget)
        {
            var emptyTiles = new System.Collections.Generic.List<Tile>();

            foreach (Tile tile in Vision)
            {
                if (tile is EmptyTile)
                {
                    emptyTiles.Add(tile);
                }
            }

            if (emptyTiles.Count == 0)
            {
                movetarget = null;
                return false;
            }

            movetarget = emptyTiles[random.Next(emptyTiles.Count)];
            return true;
        }

        public override CharacterTile[] GetTargets()
        {
            
            foreach (Tile tile in Vision)
            {
                if (tile is PlayerTile playerTile)
                {
                    return new CharacterTile[] { playerTile };
                }
            }
            return new CharacterTile[0];
        }



    }
    
        
    
}
