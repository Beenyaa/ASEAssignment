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
        String[] strParams;
        Canvas myCanvas;
        int[] intParams;

        public Commands(Canvas passedCanvas)
        {
            this.myCanvas = passedCanvas;
            intParams = new int[2];

        }

        public void ParseCommands(String line)
        {

            line = line.ToLower().Trim();
            splitLine = line.Split(' ');

            command = splitLine[0];
            if (splitLine.Length > 1)
            {
                strParams = splitLine[1].Split(',');

                if (int.Parse(strParams[0]).GetType() == typeof(int))
                { 
                    for (int i = 0 ; i < strParams.Length; i++)
                    {
                        intParams[i] = int.Parse(strParams[i]);
                    }
                }
            }

            if (command.Equals("color") == true || command.Equals("colour") == true)
            {
                Console.WriteLine("Colour was changed");
                if (strParams[0].Equals("red"))
                {
                    myCanvas.PenColour(Color.Red);
                }
                if (strParams[0].Equals("green"))
                {
                    myCanvas.PenColour(Color.DarkGreen);
                }
                if (strParams[0].Equals("blue"))
                {
                    myCanvas.PenColour(Color.Blue);
                }
            }

            if (command.Equals("clear") == true)
            {
                Console.WriteLine("Canvas cleared");
                myCanvas.ClearCanvas();
            }

            if (command.Equals("moveto") == true)
            {
                Console.WriteLine("Turtle travelled");
                myCanvas.MoveTo(intParams[0], intParams[1]);
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

                if (command.Equals("drawto") == true)
                {
                    Console.WriteLine("Line was drawn");
                    myCanvas.DrawLine(intParams[0], intParams[1]);
                }

                if (command.Equals("square") == true)
                {
                    Console.WriteLine("Square was drawn");
                    myCanvas.DrawSquare(intParams[0]);
                }

                if (command.Equals("rectangle") == true)
                {
                    Console.WriteLine("Rectangle was drawn");
                    myCanvas.DrawRectangle(intParams[0], intParams[1]);
                }

                if (command.Equals("circle") == true)
                {
                    Console.WriteLine("Circle was drawn");
                    myCanvas.DrawCircle(intParams[0]);
                }

                if (command.Equals("triangle") == true)
                {
                    Console.WriteLine("Triangle was drawn");
                    myCanvas.DrawTriangle(intParams[0]);
                }


            }

        }
    }
}
