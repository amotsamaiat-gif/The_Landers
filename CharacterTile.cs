using System;
using System.Collections.Generic;
using System.Text;

namespace The_Landers
{
    public abstract class CharacterTile : Tile
    {
        private int HitPoints; //  the hit points of the character tile
        private int MaxHitPoints; // the max hit points of the character tile
        private int AttackPower; // the attack power of the character tile
        private Tile[] Vision;
        protected CharacterTile(Postion_class position) : base(position)
        {
            this.HitPoints = HitPoints; // default hit points
            this.MaxHitPoints = MaxHitPoints; // default max hit points
            this.AttackPower = AttackPower; // default attack power
            Vision = new Tile[4];
        }
        public int hitPoints
        {
            get { return HitPoints; }
           
        }
        public int maxHitPoints
        {
            get { return MaxHitPoints; }
            
        }
        public int attackPower
        {
            get { return AttackPower; }
        }

        public Tile[] vision
        {
            get { return Vision; }
           
        }
    }
}
