using System;
using System.Collections.Generic;
using System.Text;

namespace The_Landers
{
    internal class WallTile : Tile // extends tile inherits from the tile class
    {
        public WallTile(Postion_class position) : base(position)
        {
        }
        public override char Display //this sets it so that every tile must repsond to display and return a char
        {
            get { return '#'; }
        }
    }
}
