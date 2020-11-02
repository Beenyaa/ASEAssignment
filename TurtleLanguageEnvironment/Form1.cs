using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

                String line = commandLine.Text;
                myCommands.ParseCommands(line);

                Refresh();
                commandLine.Text = "";
            }

         }

        private void outputCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImageUnscaled(outputBitmap, 0, 0);
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

}
