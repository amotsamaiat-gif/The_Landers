using System;
using System.Collections.Generic;
using System.Text;

namespace The_Landers
{
    //The first pickup type restores hit points to whoever players walks over it
    public class HealthPickUpTile : PickupTiles
    {
        public HealthPickUpTile(Postion_class position) : base(position)
        {
        }
        // Heals the hero by 10 hit points which is also at max HP inside the heal itself
        public override void ActivatePickup(CharacterTile hero)
        {
            hero.Heal(10);
        }
        //Shown as '+' in the level. puplic override char display 
        public override char Display
        {
            get { return '+'; }
        }
    }
}
