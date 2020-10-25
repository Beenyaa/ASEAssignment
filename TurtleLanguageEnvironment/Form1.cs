﻿using System;
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
        Bitmap outputBitmap = new Bitmap(640, 480);
        Canvas myCanvas;
        public Form1()
        {
            InitializeComponent();
            myCanvas = new Canvas(Graphics.FromImage(outputBitmap));
        }

        private void commandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Console.WriteLine("Enter was pressed");

                String command = commandLine.Text.Trim().ToLower();

                if (command.Equals("line") == true)
                {
                    myCanvas.DrawLine(160, 120);
                }
            }
        }

        private void outputCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImageUnscaled(outputBitmap, 0, 0);
        }
    }
}