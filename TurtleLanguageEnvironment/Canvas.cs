using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TurtleLanguageEnvironment
{
    class Canvas
    {

        Graphics graphics;
        Pen pen;
        SolidBrush brush;
        GraphicsPath graphPath;
        int xPos, yPos;
        bool penDrawingsStatus;

        public Canvas(Graphics graphics)
        {
            this.graphics = graphics;
            this.graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphPath = new GraphicsPath();
            xPos = yPos = 0;
            penDrawingsStatus = true;
            pen = new Pen(Color.Black, 1);
            brush = new SolidBrush(Color.Black);
        }
        public void ResetPos()
        {
            xPos = yPos = 0;
        }
        public void MoveTo(int toX, int toY)
        {
            xPos = toX;
            yPos = toY;
        }
        public void DrawLine(int toX, int toY)
        {
            graphics.DrawLine(pen, xPos, yPos, toX, toY);
            xPos = toX;
            yPos = toY;
        }

        public void DrawSquare(int width)
        {
            graphics.DrawRectangle(pen, xPos, yPos, width, width);
        }

        public void DrawRectangle(int width, int height)
        {
            graphics.DrawRectangle(pen, xPos, yPos, width, height);
        }

        public void DrawCircle(int radius)
        {
            graphics.DrawEllipse(pen, xPos, yPos,radius*2,radius*2);
        }

        public void DrawTriangle(int length)
        {
            Point[] points =
            {
                new Point(xPos, yPos),
                new Point(xPos, yPos + length),
                new Point(xPos + length, yPos + (length/2))
            };
            graphPath.AddPolygon(points);
            graphics.DrawPath(pen, graphPath);
        }

        public void FillGeometry()
        {
            graphics.FillPath(brush, graphPath);
        }

        public void DisposePen()
        {
            penDrawingsStatus = false;
            pen.Dispose();
            brush.Dispose();
        }

        public void CallPen()
        {
            penDrawingsStatus = true;
            pen = new Pen(Color.Black, 1);
            brush = new SolidBrush(Color.Black);
        }

        public bool IsDrawing()
        {
            return penDrawingsStatus;
        }
    }
}
