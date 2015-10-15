using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SoftwareEngineeringProject
{
    public partial class MainWindow : Form
    {
        private readonly int[,] _firstCoordinates = new int[21,2] { {38, 97}, {465, 54}, {964,66}, {434, 288}, {27, 696}, {534, 572}, {1282, 512}, {71, 1726}, {570, 1766}, {1132, 1636}, {1463, 975}, {216, 893}, {191, 1167}, {187, 1347}, {740, 1068}, {893, 1160}, {594, 1406}, {816, 1347}, {1021, 891}, {1249, 887}, {1209, 1401} };
        private readonly Label[] _labelTab = new Label[3];

        public MainWindow()
        {
            InitializeComponent();
            _labelTab[0] = player1;
            _labelTab[1] = player2;
            _labelTab[2] = player3;
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

        private void goToZone(int zoneId, int playerId)
        {
            //Initialize positions
            var xPos = _firstCoordinates[zoneId,0];
            var yPos = _firstCoordinates[zoneId,1];

            //Check how many player are in the room
            //And shift the player if there are already some players
            var numberOfPlayer = getNumberOfPlayerInTheZone(zoneId);
            xPos = xPos + numberOfPlayer * 55;

            _labelTab[playerId].Location = new Point(xPos, yPos); ;
        }

        private int getNumberOfPlayerInTheZone(int zoneId)
        {
            return GameEngine.PlayersList.Count(player => player.Position == zoneId);
        }
    }
}
