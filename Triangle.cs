using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using System.IO;
using System.Linq;


namespace Miriuta
{
    class Triangle
    {
        private const int MIN = 0;
        private const int MAX = 255;
        private Vector3 pointA;
        private Vector3 pointB;
        private Vector3 pointC;
        private bool visibility = true;
        private Randomizer r;
        string fileName;

        Color color1, color2, color3;

        public Triangle(Randomizer _r)
        {
            this.fileName = @"D:\EGC\Laborator\L2\Miriuta\TextFile1.txt";
           this. r = _r;
            initialize();


        }

        private void initialize()
        {
            
            color1 = Color.FromArgb(MAX, MIN, MIN);
            color2 = Color.FromArgb(MIN, MAX, MIN);
            color3 = Color.FromArgb(MIN, MIN, MAX);
            string[] str = File.ReadAllLines(fileName);
            for (int i = 0; i < str.Length; i++)
            {
                int[] v = str[i].Split(' ').Select(int.Parse).ToArray();
                if (i == 0)
                    pointA = new Vector3(v[0], v[1], v[2]);
                if (i == 1)
                    pointB = new Vector3(v[0], v[1], v[2]);
                if (i == 2)
                    pointC = new Vector3(v[0], v[1], v[2]);

            }
        }

        public void Draw()
        {
            if (visibility)
            {

                GL.Begin(PrimitiveType.Triangles);
                GL.Color4(color1);
                GL.Vertex3(pointA);
                GL.Color4(color2);
                GL.Vertex3(pointB);
                GL.Color4(color3);
                GL.Vertex3(pointC);
                GL.End();

            }
        }

        public void DiscoMode()
        {

            color1 = r.GetRandomColor();
            color2 = r.GetRandomColor();
            color3 = r.GetRandomColor();

        }

        public void ShowColors()
        {
            Console.WriteLine("Valorile RGB:");
            Console.WriteLine("Punctul A: " + color1);
            Console.WriteLine("Punctul B: " + color2);
            Console.WriteLine("Punctul C: " + color3);
        }

        public void TColor()
        {
            color1 = Color.FromArgb(MIN, MAX, MIN, MIN);
            color2 = Color.FromArgb(MIN, MIN, MAX, MIN);
            color3 = Color.FromArgb(MIN, MIN, MIN, MAX);

        }


    }
}
