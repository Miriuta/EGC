using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Miriuta
{
    class Window3D : GameWindow
    {
        Triangle tr;
        KeyboardState lastKeyPress;
        Randomizer r;
        Axes axes;
       
        public Window3D() : base(800, 600)
        {
            VSync = VSyncMode.On;

            r = new Randomizer();
            tr = new Triangle(r);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.Azure);

            //tr = new Triangle(r);

            axes = new Axes();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, this.Width, Height);

            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
            Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState keyboard = OpenTK.Input.Keyboard.GetState();
            
            if (keyboard[OpenTK.Input.Key.Escape])
            {
                Exit();
                return;
            }

            if (keyboard[Key.T] && !keyboard.Equals(lastKeyPress))
            {
                tr.DiscoMode();
                tr.ShowColors();

            }


                lastKeyPress = keyboard;
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Matrix4 lookat = Matrix4.LookAt(15, 50, 15, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
            

            axes.DrawMe();
            tr.Draw();

            SwapBuffers();
        }
        



    }
}
