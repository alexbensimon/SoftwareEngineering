using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareEngineeringProject
{
    public partial class UserChoiceForm : Form
    {
        public UserChoiceForm(string labeltext, string[] choices)
        {
            InitializeComponent();
            cmbBox.Items.Add(choices);
            lblMain.Text = labeltext;
        }

        public string GetCmbBoxSelectedContent()
        {
            return cmbBox.SelectedText;
        }
    }
}
