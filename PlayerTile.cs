using System;
using System.Collections.Generic;
using System.Text;

namespace The_Landers
{
    public class PlayerTile : CharacterTile
    {
        public PlayerTile(Postion_class position) : base(position, 40, 5) { }


        public override char Display
        {
            get { return IsDead ? '☠' : '⚔'; }
        }
    }
}
