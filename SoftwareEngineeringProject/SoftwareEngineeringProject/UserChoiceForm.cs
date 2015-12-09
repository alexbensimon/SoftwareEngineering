using System.Windows.Forms;

namespace SoftwareEngineeringProject
{
    public partial class UserChoiceForm : Form
    {
        public UserChoiceForm(string labeltext, string[] choices)
        {
            InitializeComponent();
            foreach (var choice in choices)
            {
                cmbBox.Items.Add(choice);
            }
            lblMain.Text = labeltext;
        }

        public string GetCmbBoxSelectedContent()
        {
            return cmbBox.SelectedText;
        }

        public int GetCmbBoxSelectedId()
        {
            return cmbBox.SelectedIndex;
        }
    }
}
