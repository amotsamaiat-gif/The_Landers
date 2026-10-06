using System;
using System.Collections.Generic;
using System.Text;

namespace The_Landers
{
    public class Postion_class
    {
        //Two private fields to store the actual coordinate values. private means nothing outside this class can access x or y
        private int x;
        private int y;

        public Postion_class(int x, int y) // takes two integers x and y and store the value in the fields
        {
            this.x = x;
            this.y = y;
        }

        public int postionX{  get { return x; }set { x = value; }}

        public int postionY { get { return y; }set { y = value; }}


    }
}
