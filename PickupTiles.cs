using System;
using System.Collections.Generic;
using System.Text;

namespace The_Landers
{
    // Base class for any item the hero can go on and walk over and also collect.
   
    public abstract class PickupTiles : Tile
    {
        protected PickupTiles(Postion_class position) : base(position)// position of healthpickup of hero 

        {
        }
        public abstract void ActivatePickup(CharacterTile hero);
    }
}
    

