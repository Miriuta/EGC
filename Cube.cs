using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Miriuta
{
    class Cube

    {

        private bool visibility = true;
        Color[] color = new Color[12];
        private int nrVertex = 24;
        Randomizer r = new Randomizer();
        
        Vector3[] coord = new Vector3[24];
        String fileName;

        public Cube()
        {
            this.fileName = @"D:\EGC\Laborator\L2\Miriuta\TextFile1.txt";
            CitireFisier();
            for (int i = 0; i < 12; i++)
                color[i] = r.GetRandomColor();


        }
        public void InitializarePoint(int x, int y, int z, int i)
        {
            coord[i] = new Vector3(x, y, z);

        }
        //citirea coordonatelor cubului din fisier
        public void CitireFisier()
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);
                int[] cuvinte;
                int i = 0;
                foreach (string line in lines)
                {
                    cuvinte = line.Split(' ').Select(int.Parse).ToArray();
                    InitializarePoint(cuvinte[0], cuvinte[1], cuvinte[2], i);
                    i++;
                }

            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
        }


        
        //codul pentru desenarea cubului format din patrate
        public void DrawCube()
        {
            if (!visibility)
            {
                return;
            }
            for (int i = 0; i < nrVertex; i = i + 4)
            {
                GL.Begin(PrimitiveType.Quads);
                GL.Color3(color[i / 4]);
                GL.Vertex3(coord[i]);
                GL.Vertex3(coord[i + 1]);
                GL.Vertex3(coord[i + 2]);
                GL.Vertex3(coord[i + 3]);
                GL.End();
            }
        }

        //codul pentru desenarea cubului format din triunghiuri
        public void DrawCubeTriangle()
        {
            if (!visibility)
            {
                return;
            }
            for (int i = 0; i < nrVertex; i = i + 4)
            {
                GL.Begin(PrimitiveType.Triangles);
                GL.Color3(color[i / 4]);
                GL.Vertex3(coord[i]);
                GL.Vertex3(coord[i + 1]);
                GL.Vertex3(coord[i + 2]);
                GL.Color3(color[i / 4 + 6]);
                GL.Vertex3(coord[i]);
                GL.Vertex3(coord[i + 2]);
                GL.Vertex3(coord[i + 3]);
                GL.End();
            }
        }
        //schimbarea culorilor pentru vertex
        public void ToggleColor(Randomizer rando, int i)
        {
            color[i] = rando.GetRandomColor();
        }

        public void ShowColors()
        {
            Console.WriteLine("Valorile RGB pentru cub:");
            for (int i = 0; i < 12; i++)
                Console.WriteLine( color[i]);

        }



    }
}
