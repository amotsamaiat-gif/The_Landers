using System;
using System.Collections.Generic;
using System.Text;

namespace The_Landers
{
    public class ExitTile : Tile
    {
        public ExitTile(Postion_class position) : base(position) { }

        public override char Display
        {
            get { return '░'; }
        }

    }
}
