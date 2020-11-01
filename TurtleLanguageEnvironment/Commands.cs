using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurtleLanguageEnvironment
{
    class Commands
    {
        String[] splitLine;
        String command;
        String[] parameters;
        Canvas myCanvas;
        int param1, param2;

        public Commands(Canvas passedCanvas)
        {
            this.myCanvas = passedCanvas;
        }

        public void ParseCommands(String line)
        {

            line = line.ToLower().Trim();
            splitLine = line.Split(' ');

            command = splitLine[0];
            if (splitLine.Length > 1)
            {
                parameters = splitLine[1].Split(',');
                param1 = int.Parse(parameters[0]);
                param2 = int.Parse(parameters[1]);
            }

            if (command.Equals("penup") == true)
            {
                Console.WriteLine("Pen was lifted");
                myCanvas.DisposePen();
            }

            if (command.Equals("pendown") == true)
            {
                Console.WriteLine("pen was lowered");
                myCanvas.CallPen();
            }

            if (myCanvas.IsDrawing() == true)
            {
                if (command.Equals("moveto") == true)
                {
                    Console.WriteLine("turtle travelled");
                    myCanvas.MoveTo(param1, param2);
                }

                if (command.Equals("drawto") == true)
                {
                    Console.WriteLine("Line was drawn");
                    myCanvas.DrawLine(param1, param2);
                }

                if (command.Equals("square") == true)
                {
                    Console.WriteLine("Square was drawn");
                    myCanvas.DrawSquare(param1);
                }

                if (command.Equals("rectangle") == true)
                {
                    Console.WriteLine("Rectangle was drawn");
                    myCanvas.DrawRectangle(param1, param2);
                }

                if (command.Equals("circle") == true)
                {
                    Console.WriteLine("Circle was drawn");
                    myCanvas.DrawCircle(param1);
                }

                if (command.Equals("triangle") == true)
                {
                    Console.WriteLine("Triangle was drawn");
                    myCanvas.DrawTriangle(param2);
                }

            }

        }
    }
}
