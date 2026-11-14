using System;
using System.Collections.Generic;
using System.Text;

namespace The_Landers
{
    [Serializable]
    public class GruntTile : EnemyTile
    {
        // Random can't be saved to a file, so it's left out of the save
        [NonSerialized]
        private Random random;

        public GruntTile(Postion_class position, Level1 level) : base(position, 10, 1, level)
        {
            random = new Random();
        }

        public override char Display
        {
            get { return IsDead ? 'x' : 'X'; }
        }

        // picks a random empty tile from the grunt's vision
        public override bool GetMove(out Tile moveTarget)
        {
            // after a game is loaded this is empty, so make a new one
            if (random == null)
            {
                random = new Random();
            }

            List<Tile> emptyTiles = new List<Tile>();

            foreach (Tile tile in Vision)
            {
                if (tile is EmptyTile)
                {
                    emptyTiles.Add(tile);
                }
            }

            if (emptyTiles.Count == 0)
            {
                moveTarget = null;
                return false;
            }

            moveTarget = emptyTiles[random.Next(emptyTiles.Count)];
            return true;
        }

        // the hero is a target if it's in the grunt's vision
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