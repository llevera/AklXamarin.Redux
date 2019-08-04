using System;

namespace Redux.Props
{
    public struct Colour
    {
        public Colour(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        public int R;
        public int G;
        public int B;
    }
}