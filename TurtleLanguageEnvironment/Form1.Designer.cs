namespace TurtleLanguageEnvironment
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.outputCanvas = new System.Windows.Forms.PictureBox();
            this.codeBox = new System.Windows.Forms.RichTextBox();
            this.commandLine = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.outputCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // outputCanvas
            // 
            this.outputCanvas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.outputCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputCanvas.Location = new System.Drawing.Point(401, 13);
            this.outputCanvas.Name = "outputCanvas";
            this.outputCanvas.Size = new System.Drawing.Size(387, 425);
            this.outputCanvas.TabIndex = 0;
            this.outputCanvas.TabStop = false;
            this.outputCanvas.Paint += this.outputCanvas_Paint;
            // 
            // codeBox
            // 
            this.codeBox.Location = new System.Drawing.Point(13, 13);
            this.codeBox.Name = "codeBox";
            this.codeBox.Size = new System.Drawing.Size(360, 395);
            this.codeBox.TabIndex = 1;
            this.codeBox.Text = "";
            // 
            // commandLine
            // 
            this.commandLine.Location = new System.Drawing.Point(12, 414);
            this.commandLine.Name = "commandLine";
            this.commandLine.Size = new System.Drawing.Size(361, 20);
            this.commandLine.TabIndex = 2;
            this.commandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commandLine_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.commandLine);
            this.Controls.Add(this.codeBox);
            this.Controls.Add(this.outputCanvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.outputCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void OutputCanvas_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.PictureBox outputCanvas;
        private System.Windows.Forms.RichTextBox codeBox;
        private System.Windows.Forms.TextBox commandLine;
    }
}

