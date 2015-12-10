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
        private int _numberOfMoves = 0;
        private int _indexOfCardDisplayed = 0;

        public MainWindow()
        {
            InitializeComponent();

            _gameEngine = new GameEngine();

            _labels[0] = labelPlayer1;
            _labels[1] = labelPlayer2;
            _labels[2] = labelPlayer3;

            // Set label names.
            for (var i = 0; i < _labels.Count(); i++)
            {
                _labels[i].Text = _gameEngine.PlayersList[i].Name;
                _labels[i].Parent = pictureBoxMap;
            }

            // Start in ECS 308.
            UpdateListboxDisplay(17);

            UpdateInformationPanel();

            buttonDrawCard.Enabled = true;
            buttonMove.Enabled = false;
            buttonPlayCard.Enabled = false;

            var cardName = _gameEngine.PlayersList[0].Hand.First().GetType().Name;
            pictureBoxCard.Image = Image.FromFile(@"..\..\Pictures\Cards\Freshman\" + cardName + ".png");
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                Close();
            }
        }

        private void GoToARoom(int playerId, int roomId)
        {
            // Initialize positions.
            var xPos = _gameEngine.RoomCoordinates[roomId, 0];
            var yPos = _gameEngine.RoomCoordinates[roomId, 1];

            // Check how many player are in the room and shift the player if there are already some players.
            var numberOfPlayer = GetNumberOfPlayerInTheRoom(roomId);
            yPos = yPos + numberOfPlayer * 40;

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

        // TODO: Pourquoi les 2 IA vont au meme endroit ?
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

        private void buttonDrawCard_Click(object sender, EventArgs e)
        {
            _gameEngine.PlayersList[0].DrawCard();

            _indexOfCardDisplayed = _gameEngine.PlayersList[0].Hand.Count - 1;
            ChangePictureBoxCardDisplay();

            buttonDrawCard.Enabled = false;
            buttonMove.Enabled = true;
            buttonPlayCard.Enabled = true;
        }

        private void buttonMove_Click(object sender, EventArgs e)
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

                UpdateListboxDisplay(destinationId);
            }
            _numberOfMoves++;
            if (_numberOfMoves == 3) buttonMove.Enabled = false;
        }

        private void buttonPlayCard_Click(object sender, EventArgs e)
        {
            // Play the card.
            var success = _gameEngine.PlayersList[0].PlayCard(_indexOfCardDisplayed);

            UpdateCurrentPlayPanel(0, _indexOfCardDisplayed, success);

            buttonPlayCard.Enabled = false;
            if (buttonMove.Enabled) buttonMove.Enabled = false;

            // Each AI plays.
            PlayComputer(_gameEngine.PlayersList[1]);
            PlayComputer(_gameEngine.PlayersList[2]);

            // New turn.
            UpdateInformationPanel();
            buttonDrawCard.Enabled = true;
        }

        private void UpdateCurrentPlayPanel(int playerIndex, int cardIndexInHand, bool success)
        {
            // Display the card played in the Current Play panel.
            var cardPlayed = _gameEngine.PlayersList[playerIndex].Hand.ElementAt(cardIndexInHand);
            textBoxCurrentPlay.Text += _gameEngine.PlayersList[playerIndex].Name + " played " +
                                       cardPlayed.Name;
            if (success) textBoxCurrentPlay.Text += " for " + cardPlayed.Reward + "\r\n";
            else textBoxCurrentPlay.Text += " but failed" + "\r\n";
        }

        private void pictureBoxCard_Click(object sender, EventArgs e)
        {
            if (_indexOfCardDisplayed < _gameEngine.PlayersList[0].Hand.Count - 1)
                _indexOfCardDisplayed++;
            else _indexOfCardDisplayed = 0;
            ChangePictureBoxCardDisplay();
        }

        private void ChangePictureBoxCardDisplay()
        {
            var cardName = _gameEngine.PlayersList[0].Hand.ElementAt(_indexOfCardDisplayed).GetType().Name;
            pictureBoxCard.Image = Image.FromFile(@"..\..\Pictures\Cards\Freshman\" + cardName + ".png");
        }

        private void UpdateInformationPanel()
        {
            var playersList = _gameEngine.PlayersList;
            var player1 = playersList[0];
            var player2 = playersList[1];
            var player3 = playersList[2];
            textBoxInformationPanel.Text =
                "\t\tLearning\t\tCraft\t\tIntegrity\t\tQualityPoints\r\n" +
                player1.Name + "\t" + player1.LearningChips + "\t\t" + player1.CraftChips + "\t\t" + player1.IntegrityChips +
                "\t\t" + player1.QualityPoints + "\r\n" +
                player2.Name + "\t\t" + player2.LearningChips + "\t\t" + player2.CraftChips + "\t\t" + player2.IntegrityChips +
                "\t\t" + player2.QualityPoints + "\r\n" +
                player3.Name + "\t\t" + player3.LearningChips + "\t\t" + player3.CraftChips + "\t\t" + player3.IntegrityChips +
                "\t\t" + player3.QualityPoints + "\r\n" +
                "\r\n\r\n" +
                "Cards in deck: " + _gameEngine.Deck.Count + "\tDiscards out of play: " +
                _gameEngine.DiscardedDeck.Count + "\r\n\r\n" +
                "You are " + player1.Name + " and you are in " + _gameEngine.RoomNames[player1.Position];
        }
    }
}
