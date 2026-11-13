using System;
using System.Collections.Generic;
using System.Text;

namespace The_Landers
{
    public class ExitTile : Tile
    {
       private bool locked = true;
        public bool Locked
        {
            get { return locked; }
            set { locked = value; }
        }

        public ExitTile(Postion_class position) : base(position)
        {

        }

        public override char Display
        {
            get { return locked ? '▓' : '▒'; }
        }

    }
}
