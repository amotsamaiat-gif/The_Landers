using System;
using System.Collections.Generic;
using System.Text;

namespace The_Landers
{
    [Serializable]
    public class AttackBuffPickUpTiles : PickupTiles
    {
        public AttackBuffPickUpTiles(Postion_class position) : base(position)
        {

        }

        public override void ActivatePickup(CharacterTile hero)
        {
            hero.SetDoubleDamage(3);
        }

        public override char Display 
        {
           get { return '*'; }
        }

    }
    
}
