using System;
using System.Collections.Generic;
using System.Text;

namespace The_Landers
{
    [Serializable]
    public class PlayerTile : CharacterTile
    {
        public PlayerTile(Postion_class position) : base(position, 40, 5) { }


        public override char Display
        {
            get { return IsDead ? '☠' : '⚔'; }
        }
    }
}
