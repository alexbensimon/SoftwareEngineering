using System;
using System.Windows.Forms;

namespace SoftwareEngineeringProject
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            TopMost = true;
            //FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            listBox1.Items.Add("Room example 1");
            listBox1.Items.Add("Room example 2");
            listBox1.Items.Add("Room example 3");
            listBox1.Items.Add("Room example 4");
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
