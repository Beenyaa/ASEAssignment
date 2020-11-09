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
    public partial class ErrorPopup : Form
    {
        String[] errorList;
        public ErrorPopup(String[] errorList)
        {
            InitializeComponent();
            this.errorList = errorList;
        }

        private void ErrorPopup_Load(object sender, EventArgs e)
        {
            foreach (string error in errorList) 
            {
                errorBox.AppendText(error+"\n");
            }
        }
    }
}
