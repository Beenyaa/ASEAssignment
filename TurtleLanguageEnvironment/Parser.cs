using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurtleLanguageEnvironment
{
    /// <summary>Class Parser.</summary>
    public class Parser
    {
        String[] splitLine;
        String command;
        String[] parameters;
        Canvas myCanvas;
        

        /// <summary>Initializes a new instance of the <see cref="T:TurtleLanguageEnvironment.Parser" /> class.</summary>
        /// <param name="passedCanvas">The passed canvas.</param>
        public Parser(Canvas passedCanvas)
        {
            this.myCanvas = passedCanvas;
            

        }

        /// <summary>Parses the commands.</summary>
        /// <param name="line">The line.</param>
        public void ParseCommands(String line, int lineNumber, ErrorHandler errorHandler)
        {
            try
            {
                line = line.ToLower().Trim();
                splitLine = line.Split(' ');

                command = splitLine[0];
                if (splitLine.Length>1)
                {
                    parameters = splitLine[1].Split(',');
                }
      
                if (command.Equals("color") == true || command.Equals("colour") == true)
                {
                    if (parameters[0].Equals("red"))
                    {
                        Console.WriteLine("Colour was changed");
                        myCanvas.PenColour(Color.Red);
                    }
                    else if (parameters[0].Equals("pink"))
                    {
                        Console.WriteLine("Colour was changed");
                        myCanvas.PenColour(Color.DeepPink);
                    }
                    else if (parameters[0].Equals("blue"))
                    {
                        Console.WriteLine("Colour was changed");
                        myCanvas.PenColour(Color.Blue);
                    }

                    else if (parameters[0].Equals("black"))
                    {
                        Console.WriteLine("Colour was changed");
                        myCanvas.PenColour(Color.Black);
                    }

                    else
                    {
                        throw new ArgumentException("Invalid colour at line: " + lineNumber.ToString());
                    }
                }
            
                else if (command.Equals("clear") == true)
                {
                    Console.WriteLine("Canvas cleared");
                    myCanvas.ClearCanvas();
                }

                else if (command.Equals("reset") == true)
                {
                    Console.WriteLine("reset");
                    myCanvas.ResetPos();
                }

                else if (command.Equals("moveto") == true)
                {
                    Console.WriteLine("Turtle travelled");
                    if (parameters[0].Equals(null) || parameters[1].Equals(null))
                    {
                        throw new ArgumentNullException("Missing parameter at line: " + lineNumber);
                    }
                    if (int.TryParse(parameters[0], out int x) && int.TryParse(parameters[1], out int y))
                    {
                        myCanvas.MoveTo(x, y);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid parameter at line: " + lineNumber);
                    }

                }

                else if (command.Equals("penup") == true)
                {
                    Console.WriteLine("Pen was lifted");
                    myCanvas.DisposePen();
                }

                else if (command.Equals("pendown") == true)
                {
                    Console.WriteLine("pen was lowered");
                    myCanvas.CallPen();
                }

                else if (command.Equals("fill") == true)
                {
                    Console.WriteLine("fill status changed");
                    if (parameters[0].Equals("on"))
                    {
                        myCanvas.SetFill(true);
                    }
                    else if (parameters[0].Equals("off"))
                    {
                        myCanvas.SetFill(false);
                    }

                    else
                    {
                        throw new ArgumentException("Invalid parameter at line: " + lineNumber);
                    }
                }

                else if (myCanvas.IsDrawing() == true)
                {

                    if (command.Equals("drawto") == true)
                    {
                        Console.WriteLine("Line was drawn");
                        if (parameters[0].Equals(null) || parameters[1].Equals(null))
                        {
                            throw new ArgumentNullException("Missing parameter at line: " + lineNumber);
                        }
                        if (int.TryParse(parameters[0], out int x) && int.TryParse(parameters[1], out int y))
                        {
                            myCanvas.DrawLine(x, y);
                        }

                        else
                        {
                            throw new ArgumentException("Invalid parameter at line: " + lineNumber);
                        }
                    }

                    if (command.Equals("square") == true)
                    {
                        Console.WriteLine("Square was drawn");
                        if (parameters[0].Equals(null))
                        {
                            throw new ArgumentNullException("Missing parameter at line: " + lineNumber);
                        }
                        if (int.TryParse(parameters[0], out int size))
                        {
                            myCanvas.DrawSquare(size);
                        }

                        else
                        {
                            throw new ArgumentException("Invalid parameter at line: " + lineNumber);
                        }
                    }

                    if (command.Equals("rectangle") == true)
                    {
                        Console.WriteLine("Rectangle was drawn");
                        if (parameters[0].Equals(null)||parameters[1].Equals(null))
                        {
                            throw new ArgumentNullException("Missing parameter at line: " + lineNumber);
                        }
                        if (int.TryParse(parameters[0], out int width) && int.TryParse(parameters[1], out int height))
                        {
                            myCanvas.DrawRectangle(width, height);
                        }

                        else
                        {
                            throw new ArgumentException("Invalid parameter at line: " + lineNumber);
                        }
                    }

                    if (command.Equals("circle") == true)
                    {
                        Console.WriteLine("Circle was drawn");
                        if (parameters[0].Equals(null))
                        {
                            throw new ArgumentNullException("Missing parameter at line: " + lineNumber);
                        }
                        if (int.TryParse(parameters[0], out int radius))
                        {
                            myCanvas.DrawCircle(radius);
                        }

                        else
                        {
                            throw new ArgumentException("Invalid parameter at line: " + lineNumber);
                        }
                    }

                    if (command.Equals("triangle") == true)
                    {
                        Console.WriteLine("Triangle was drawn");
                        if (parameters[0].Equals(null))
                        {
                            throw new ArgumentNullException("Missing parameter at line: " + lineNumber);
                        }
                        if (int.TryParse(parameters[0], out int size))
                        {
                            myCanvas.DrawTriangle(size);
                        }

                        else
                        {
                            throw new ArgumentException("Invalid parameter at line: " + lineNumber);
                        }
                    }

                }
                else
                {
                    throw new ArgumentException("Unknown command at line: " + lineNumber);
                }
            }

            catch (ArgumentException ex)
            {
                string error = ex.Message;
                errorHandler.AddError(error);
                Console.WriteLine(errorHandler.GetErrorList()[0]);
            }


        }
    }
}
