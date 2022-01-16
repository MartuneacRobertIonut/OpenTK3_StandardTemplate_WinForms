using System;
using System.IO;
using System.Collections;
using System.Drawing;

using OpenTK.Graphics.OpenGL;

using OpenTK3_StandardTemplate_WinForms.helpers;
namespace OpenTK3_StandardTemplate_WinForms.objects
{
    class Cube
    {
        private ArrayList coordonates;
        private ArrayList colors;
        private PolygonMode currentPolygonState = PolygonMode.Fill;
        private bool visibility;
        private int Translate = 20;

        public Cube()
        {
            coordonates = new ArrayList();
            colors = new ArrayList();
            Culoare();
            ReadFromFile();
            visibility = false;
        }
        public void ReadFromFile()
        {
            String[] str = File.ReadAllLines(@"C:\Users\Robert\Downloads\test\OpenTK3_StandardTemplate_WinForms\helpers\TextFile1.txt");
            foreach(String strFile in str)
            {
                String[] file;
                file = strFile.Split(' ');
                coordonates.Add(new Coords(Convert.ToInt32(file[0])+Translate, Convert.ToInt32(file[1])+Translate,Convert.ToInt32(file[2])+Translate));
            }
        }
        public void Culoare()
        {
            for (int i = 0; i < 6; i++)
            {
                colors.Add(Randomizer.GetRandomColor());
            }
        }

        public bool GetVisibility()
        {
            return visibility;
        }

        public void SetVisibility(bool _visibility)
        {
            visibility = _visibility;
        }

        public void Show()
        {
            visibility = true;
        }

        public void Hide()
        {
            visibility = false;
        }

        public void ToggleVisibility()
        {
            visibility = !visibility;
        }

        public void PolygonDrawingStyle(String style)
        {
            if (style == "line")
            {
                currentPolygonState = PolygonMode.Line;
                return;
            }

            if (style == "surface")
            {
                currentPolygonState = PolygonMode.Fill;
                return;
            }

        }

        public void Draw()
        {
            if (!visibility)
            {
                return;
            }
            int j = 0;
            GL.PolygonMode(MaterialFace.FrontAndBack, currentPolygonState);
            GL.Begin(PrimitiveType.Quads);
            for (int i = 0; i < 6; i++)
            {
                GL.Color3((Color)colors[i]);
                GL.Vertex3(((Coords)coordonates[j]).X, ((Coords)coordonates[j]).Y, ((Coords)coordonates[j++]).Z);
                GL.Vertex3(((Coords)coordonates[j]).X, ((Coords)coordonates[j]).Y, ((Coords)coordonates[j++]).Z);
                GL.Vertex3(((Coords)coordonates[j]).X, ((Coords)coordonates[j]).Y, ((Coords)coordonates[j++]).Z);
                GL.Vertex3(((Coords)coordonates[j]).X, ((Coords)coordonates[j]).Y, ((Coords)coordonates[j++]).Z);

            }
            GL.End();
        }
    }
}

