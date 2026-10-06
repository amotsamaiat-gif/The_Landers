using System;
using System.Collections.Generic;
using System.Text;

namespace The_Landers
{
    public abstract class PickupTiles : Tile
    {
        protected PickupTiles(Postion_class position) : base(position)// constructor that takes in position

        {
        }
        public abstract void ActivatePickup(CharacterTile hero);
    }
}
    

