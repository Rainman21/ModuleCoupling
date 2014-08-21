using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicCsharpWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            this.propertyGrid1.SelectedObject = BasicCsharpClassLibrary.EmployeeModule.CreateEmployee("Ted", "Frankenstein", new DateTime(1999, 3, 29));
        }
    }
}
