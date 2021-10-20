using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Miriuta
{
    class Window3D : GameWindow
    {
        bool showCube = true;
        KeyboardState lastKeyPress;
        float X = 0, Y = 0;
        public Window3D() : base(800, 400)
        {
            VSync = VSyncMode.On;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.Black);
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
            MouseState mouse = OpenTK.Input.Mouse.GetState();
            if (keyboard[OpenTK.Input.Key.Escape])
            {
                Exit();
                return;
            } //rezolvare problema 2 din laboratorul 2
            else if (keyboard[OpenTK.Input.Key.A] && keyboard[OpenTK.Input.Key.D] && !keyboard.Equals(lastKeyPress)) // tastele A & D
            {
                if (showCube == true)
                {
                    showCube = false;
                }
                else
                {
                    showCube = true;
                }
            }
            else if (mouse.X != X && mouse.Y != Y)//mouse
            {
                showCube = false;
                X = mouse.X;
                Y = mouse.Y;
            }
            else
            {
                showCube = true;
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
            if (showCube == true)
            {
                DrawCube();

            }

            SwapBuffers();
        }
        private void DrawCube()
        {
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(Color.AliceBlue);
            GL.Vertex3(-2.0f, -2.0f, -2.0f);
            GL.Vertex3(-2.0f, 2.0f, -2.0f);
            GL.Vertex3(2.0f, 2.0f, -2.0f);
            GL.Vertex3(2.0f, -2.0f, -2.0f);

            GL.Color3(Color.Honeydew);
            GL.Vertex3(-2.0f, -2.0f, -2.0f);
            GL.Vertex3(2.0f, -2.0f, -2.0f);
            GL.Vertex3(2.0f, -2.0f, 2.0f);
            GL.Vertex3(-2.0f, -2.0f, 2.0f);

            GL.Color3(Color.Moccasin);

            GL.Vertex3(-2.0f, -2.0f, -2.0f);
            GL.Vertex3(-2.0f, -2.0f, 2.0f);
            GL.Vertex3(-2.0f, 2.0f, 2.0f);
            GL.Vertex3(-2.0f, 2.0f, -2.0f);

            GL.Color3(Color.IndianRed);
            GL.Vertex3(-2.0f, -2.0f, 2.0f);
            GL.Vertex3(2.0f, -2.0f, 2.0f);
            GL.Vertex3(2.0f, 2.0f, 2.0f);
            GL.Vertex3(-2.0f, 2.0f, 2.0f);

            GL.Color3(Color.Azure);
            GL.Vertex3(-2.0f, 2.0f, -2.0f);
            GL.Vertex3(-2.0f, 2.0f, 2.0f);
            GL.Vertex3(2.0f, 2.0f, 2.0f);
            GL.Vertex3(2.0f, 2.0f, -2.0f);

            GL.Color3(Color.Aquamarine);
            GL.Vertex3(2.0f, -2.0f, -2.0f);
            GL.Vertex3(2.0f, 2.0f, -2.0f);
            GL.Vertex3(2.0f, 2.0f, 2.0f);
            GL.Vertex3(2.0f, -2.0f, 2.0f);

            GL.End();
        }



    }
}
