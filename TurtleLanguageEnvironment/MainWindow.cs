using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurtleLanguageEnvironment
{
    /// <summary>Class Form1.
    /// Implements the <see cref="System.Windows.Forms.Form" /></summary>
    public partial class MainWindow : Form
    {
        Turtle turtle;
        Bitmap turtleBitmap;
        Parser myCommands;
        Canvas myCanvas;
        SaveFileDialog saveFileDialog;
        OpenFileDialog openFileDialog;
        ErrorHandler errorHandler;
        /// <summary>Initializes a new instance of the <see cref="T:TurtleLanguageEnvironment.Form1" /> class.</summary>
        public MainWindow()
        {
            InitializeComponent();
            errorHandler = new ErrorHandler();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            myCanvas = new Canvas();
            myCommands = new Parser(myCanvas);
            turtleBitmap = new Bitmap(outputCanvas.Width, outputCanvas.Height);
            turtle = new Turtle(Graphics.FromImage(turtleBitmap));
        }

        /// <summary>Handles the KeyDown event of the commandLine control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void commandLine_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                Console.WriteLine("Enter was pressed");
                String cmdLine = commandLine.Text.ToLower().Trim();

                try
                {
                    // Handles code box commands
                    if (cmdLine.Equals("run"))
                    {
                        using (StringReader reader = new StringReader(codeBox.Text))
                        {
                            string line;
                            int lineNumber = 1;
                            while ((line = reader.ReadLine()) != null)
                            {
                                myCommands.ParseCommands(line, lineNumber, errorHandler);
                                lineNumber++;
                            }


                        }
                    }

                    // Handles command line commands
                    else
                    {
                        myCommands.ParseCommands(cmdLine, 0, errorHandler);
                    }
                    Refresh();
                    commandLine.Text = "";
                }
                finally
                {
                    if (errorHandler.GetErrorList().Length > 0)
                    {
                        ErrorPopup errorPopUp = new ErrorPopup(errorHandler.GetErrorList());
                        errorPopUp.Show();
                        errorHandler.Clear();
                    }
                }
            }

         }

        /// <summary>Handles the Paint event of the outputCanvas control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs" /> instance containing the event data.</param>
        private void outputCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImageUnscaled(myCanvas.getOutputBitmap(), 0, 0);
            turtle.Wake(myCanvas.GetX(), myCanvas.GetY());
            graphics.DrawImageUnscaled(turtleBitmap, 0, 0);
        }

        /// <summary>Handles the Click event of the newImageToolStripMenuItem control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void newImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myCanvas.ClearCanvas();
            myCanvas.ResetPos();
        }

        /// <summary>Handles the Click event of the saveImageToolStripMenuItem control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Images|*.jpeg";
            ImageFormat format = ImageFormat.Jpeg;
            saveFileDialog.RestoreDirectory = true;
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                myCanvas.getOutputBitmap().Save(saveFileDialog.FileName, format);
            }

        }

        /// <summary>Handles the Click event of the closeProgramToolStripMenuItem control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void closeProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>Handles the Click event of the newCodeToolStripMenuItem control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void newCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.codeBox.Clear();
        }

        /// <summary>Handles the Click event of the saveCodeToolStripMenuItem control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void saveCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text|*.txt";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.codeBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        /// <summary>Handles the Click event of the loadCodeToolStripMenuItem control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void loadCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text|*.txt";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.codeBox.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
            }

        }
    }

}
