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
    public partial class Form1 : Form
    {
        Commands myCommands;
        Canvas myCanvas;
        Bitmap outputBitmap = new Bitmap(640, 480);
        SaveFileDialog saveFileDialog;
        public Form1()
        {
            InitializeComponent();
            myCanvas = new Canvas(Graphics.FromImage(outputBitmap));
            myCommands = new Commands(myCanvas);

        }

        private void commandLine_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                Console.WriteLine("Enter was pressed");
                String cmdLine = commandLine.Text.ToLower().Trim();

                // Handles code box commands
                if (cmdLine.Equals("run"))
                {
                    using (StringReader reader = new StringReader(codeBox.Text))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            myCommands.ParseCommands(line);
                        }
                    }
                }

                // Handles command line commands
                else
                {
                    myCommands.ParseCommands(cmdLine);
                }

                Refresh();
                commandLine.Text = "";
            }

         }

        private void outputCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImageUnscaled(outputBitmap, 0, 0);
        }

        private void newImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myCanvas.ClearCanvas();

        }

        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("wow");
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Images|*.jpeg";
            ImageFormat format = ImageFormat.Jpeg;
            saveFileDialog.RestoreDirectory = true;
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("wtf");
                this.outputCanvas.Image.Save(saveFileDialog.FileName, format);
            }

        }
    }

}
