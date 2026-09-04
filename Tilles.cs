using System;
using System.Collections.Generic;
using System.Text;

namespace The_Landers
{
    public abstract class Tile // the base class for all tile types
    {
        private Postion_class position; // stores the position of the tile on the game

        protected Tile(Postion_class position) // constructor accepts a object that has x and y values rather than accepting seperate integers
        {
            this.position = position;
        }


        public int PositionX
        {
            get { return position.postionX; }
            set { position.postionX = value; }
        }
        public int PositionY
        {
            get { return position.postionY; }
            set { position.postionY = value; }
        }

        public int position_class
        {
            get { return position_class; }
            set { position_class = value; }
        }
        public abstract char Display { get; } // this makes sure that every tile will have a display
    }
}
