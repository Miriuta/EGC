using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Miriuta
{
     class Randomizer
    {

        private const int MIN = 0;
        private const int MAX = 255;
        private Random r;
        public Randomizer()
        {
            r = new Random();
        }
        public Color GetRandomColor()
        {
            int genR = r.Next(MIN, MAX);
            int genG = r.Next(MIN, MAX);
            int genB = r.Next(MIN, MAX);
            Color clr = Color.FromArgb(genR, genG, genB);
            return clr;
        }

    }
}