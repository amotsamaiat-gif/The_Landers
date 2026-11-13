using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Net.Sockets;
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

    
    private bool locked = true;

        public bool Locked
        {
            get { return locked; }
        }

        public void Unlock()
        {
            locked = false;
        }
    }
}



