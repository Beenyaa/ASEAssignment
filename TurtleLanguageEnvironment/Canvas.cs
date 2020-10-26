using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TurtleLanguageEnvironment
{
    class Canvas
    {

        Graphics graphics;
        Pen pen;
        int xPos, yPos;

        public Canvas(Graphics graphics)
        {
            this.graphics = graphics;
            this.graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 1);
        }

        public void DrawLine(int toX, int toY)
        {
            graphics.DrawLine(pen, xPos, yPos, toX, toY);
            xPos = toX;
            yPos = toY;
        }

        public void DrawSquare(int width)
        {
            graphics.DrawRectangle(pen, xPos, yPos, xPos + width, yPos + width);
        }
    }
}
