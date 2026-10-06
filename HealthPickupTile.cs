using System;
using System.Collections.Generic;
using System.Text;

namespace The_Landers
{
    public class HealthPickUpTile : PickupTiles
    {
        public HealthPickUpTile(Postion_class position) : base(position)
        {
        }
        public override void ActivatePickup(CharacterTile hero)
        {
            hero.Heal(10);
        }

        public override char Display
        {
            get { return '+'; }
        }
    }
}
