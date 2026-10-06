using System;
using System.Collections.Generic;
using System.Text;

namespace The_Landers
{
    public abstract class EnemyTile : CharacterTile // ADDS HIT POINTS AND ATTACK POWER TO CHARCATER TILES
    {
        protected EnemyTile(Postion_class position, int hitpoints, int attackpower) // constructor that takes in position, hitpoints, and attackpower 
            : base(position, hitpoints, attackpower)
        {
        }
       public abstract bool GetMove(out Tile movetarget);

       public abstract CharacterTile[] GetTargets();
    }
}
