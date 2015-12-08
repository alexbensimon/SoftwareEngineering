using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SoftwareEngineeringProject
{
    public partial class MainWindow : Form
    {
        private readonly GameEngine _gameEngine;

        private readonly Label[] _labels = new Label[3];

        public MainWindow()
        {
            InitializeComponent();

            _gameEngine = new GameEngine();

            _labels[0] = player1;
            _labels[1] = player2;
            _labels[2] = player3;

            // Set label names.
            for (var i = 0; i < _labels.Count(); i++)
            {
                _labels[i].Text = _gameEngine.PlayersList[i].Name;
                _labels[i].Parent = pictureBox1;
            }

            // Start in ECS 308.
            UpdateListboxDisplay(17);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //TopMost = true;
            //FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
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
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Select a room!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var destinationName = listBox1.SelectedItem.ToString();
                var destinationId = _gameEngine.RoomNames.IndexOf(destinationName);
                GoToARoom(0, destinationId);

                // Move each AI.
                PlayComputer(_gameEngine.PlayersList[1]);
                PlayComputer(_gameEngine.PlayersList[2]);

                UpdateListboxDisplay(destinationId);
            }            
        }

        private void GoToARoom(int playerId, int roomId)
        {
            // Initialize positions.
            var xPos = _gameEngine.RoomCoordinates[roomId, 0];
            var yPos = _gameEngine.RoomCoordinates[roomId, 1];

            // Check how many player are in the room and shift the player if there are already some players.
            var numberOfPlayer = GetNumberOfPlayerInTheRoom(roomId);
            yPos = yPos + numberOfPlayer * 20;

            _labels[playerId].Location = new Point(xPos, yPos);

            // Update position.
            _gameEngine.PlayersList[playerId].Position = roomId;
        }

        private int GetNumberOfPlayerInTheRoom(int roomId)
        {
            var count = 0;
            foreach (var player in _gameEngine.PlayersList)
            {
                if (player.Position == roomId) count++;
            }
            return count;
        }

        private void PlayComputer(Player player)
        {
            var randomDestinationId = _gameEngine.RoomsAvailable[player.Position]
                [new Random().Next(_gameEngine.RoomsAvailable[player.Position].Count)];
            GoToARoom(_gameEngine.PlayersList.IndexOf(player), randomDestinationId);
        }

        private void UpdateListboxDisplay(int roomId)
        {
            listBox1.Items.Clear();

            foreach (var roomAvailable in _gameEngine.RoomsAvailable[roomId])
            {
                var roomName = _gameEngine.RoomNames[roomAvailable];
                listBox1.Items.Add(roomName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _gameEngine.PlayersList[0].DiscardCard();
        }
    }
}
