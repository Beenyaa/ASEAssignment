using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TurtleLanguageEnvironment
{
    /// <summary>Class Canvas.</summary>
    public class Canvas
    {
        Graphics graphics;
        Pen pen;
        SolidBrush brush;
        GraphicsPath graphPath;
        int xPos, yPos;
        bool penDrawingsStatus;
        bool fillShape;
        Bitmap outputBitmap;

        /// <summary>Initializes a new instance of the <see cref="T:TurtleLanguageEnvironment.Canvas" /> class.</summary>
        /// <param name="graphics">The graphics.</param>
        public Canvas()
        {

            outputBitmap = new Bitmap(387, 425);

            graphics = Graphics.FromImage(outputBitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphPath = new GraphicsPath();
            xPos = yPos = 0;
            penDrawingsStatus = true;
            fillShape = false;
            pen = new Pen(Color.Black, 1);
            brush = new SolidBrush(Color.Black);

        }
        /// <summary>Clears the canvas.</summary>
        public void ClearCanvas()
        {
            graphics.Clear(Color.White);
        }
        /// <summary>Resets the position.</summary>
        public void ResetPos()
        {
            xPos = yPos = 0;
        }
        /// <summary>Moves to.</summary>
        /// <param name="toX">To x.</param>
        /// <param name="toY">To y.</param>
        public void MoveTo(int toX, int toY)
        {
            xPos = toX;
            yPos = toY;
        }
        /// <summary>Draws the line.</summary>
        /// <param name="toX">To x.</param>
        /// <param name="toY">To y.</param>
        public void DrawLine(int toX, int toY)
        {
            graphics.DrawLine(pen, xPos, yPos, toX, toY);
            xPos = toX;
            yPos = toY;
        }

        /// <summary>Draws the square.</summary>
        /// <param name="width">The width.</param>
        public void DrawSquare(int width)
        {
            graphics.DrawRectangle(pen, xPos, yPos, width, width);

            if (fillShape == true)
            {
                graphics.FillRectangle(brush, xPos, yPos, width , width);
            }
        }

        /// <summary>Draws the rectangle.</summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public void DrawRectangle(int width, int height)
        {
            graphics.DrawRectangle(pen, xPos, yPos, width, height);

            if (fillShape == true)
            {
                graphics.FillRectangle(brush, xPos, yPos, width, height);
            }
        }

        /// <summary>Draws the circle.</summary>
        /// <param name="radius">The radius.</param>
        public void DrawCircle(int radius)
        {
            graphics.DrawEllipse(pen, xPos - radius, yPos - radius ,radius*2,radius*2);

            if (fillShape == true)
            {
                graphics.FillEllipse(brush, xPos - radius, yPos - radius, radius*2, radius*2);
            }
        }

        /// <summary>Draws the triangle.</summary>
        /// <param name="length">The length.</param>
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

            if (fillShape == true)
            {
                graphics.FillPath(brush, graphPath);
            }
        }

        /// <summary>Disposes the pen.</summary>
        public void DisposePen()
        {
            penDrawingsStatus = false;
            pen.Dispose();
            brush.Dispose();
        }

        /// <summary>Calls the pen.</summary>
        public void CallPen()
        {
            penDrawingsStatus = true;
            pen = new Pen(Color.Black, 1);
            brush = new SolidBrush(Color.Black);
        }

        /// <summary>Determines whether this instance is drawing.</summary>
        /// <returns>
        ///   <c>true</c> if this instance is drawing; otherwise, <c>false</c>.</returns>
        public bool IsDrawing()
        {
            return penDrawingsStatus;
        }

        /// <summary>Sets the fill.</summary>
        /// <param name="onOrOff">if set to <c>true</c> [on or off].</param>
        public void SetFill(bool onOrOff)
        {
            fillShape = onOrOff;
        }

        /// <summary>Pens the colour.</summary>
        /// <param name="penColour">The pen colour.</param>
        public void PenColour(Color penColour)
        {
            pen.Color = penColour;
            brush.Color = penColour;
        }

        /// <summary>Gets the x.</summary>
        /// <returns>System.Int32.</returns>
        public int GetX()
        {
            return xPos;
        }

        /// <summary>Gets the y.</summary>
        /// <returns>System.Int32.</returns>
        public int GetY()
        {
            return yPos;
        }

        public Bitmap getOutputBitmap()
        {
            return outputBitmap;
        }

    }
}
