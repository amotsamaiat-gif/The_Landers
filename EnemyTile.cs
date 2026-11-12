using System;
using System.Collections.Generic;
using System.Text;

namespace The_Landers
{
    public abstract class EnemyTile : CharacterTile // ADDS HIT POINTS AND ATTACK POWER TO CHARCATER TILES
    {
        protected Level1 level1;
        protected EnemyTile(Postion_class position, int hitpoints, int attackpower, Level1 level1) // constructor that takes in position, hitpoints, and attackpower 
            : base(position, hitpoints, attackpower)
        {
            this.level1 = level1;
        }
       public abstract bool GetMove(out Tile movetarget);

       public abstract CharacterTile[] GetTargets();
    }
}
