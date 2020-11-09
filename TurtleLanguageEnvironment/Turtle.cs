using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TurtleLanguageEnvironment
{
    /// <summary>Class Turtle.</summary>
    class Turtle
    {
        Graphics graphics;
        Pen turtleOutside;

        /// <summary>Initializes a new instance of the <see cref="T:TurtleLanguageEnvironment.Turtle" /> class.</summary>
        /// <param name="graphics">The graphics.</param>
        public Turtle(Graphics graphics)
        {
            this.graphics = graphics;
        }

        /// <summary>Wakes the turtle at specified current x and y positions.</summary>
        /// <param name="currentX">The current x.</param>
        /// <param name="currentY">The current y.</param>
        public void Wake(int currentX, int currentY)
        {
            this.graphics.Clear(Color.Transparent);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            turtleOutside = new Pen(Color.DarkSeaGreen, 4);
            graphics.DrawEllipse(turtleOutside, currentX-2, currentY-2, 4, 4);
        }
    }
}
