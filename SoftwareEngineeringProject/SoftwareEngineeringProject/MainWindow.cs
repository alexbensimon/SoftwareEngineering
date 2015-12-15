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
        private int _numberOfMoves;
        private int _indexOfCardDisplayed;

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

            if(playerId == 0) UpdateListboxDisplay(roomId);
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
            // Draw card.
            player.DrawCard();

            // Move between 0 and 3 times.
            var numberOfMoves = new Random().Next(4);
            for (int i = 0; i < numberOfMoves; i++)
            {
                var randomDestinationId = _gameEngine.RoomsAvailable[player.Position]
                [new Random().Next(_gameEngine.RoomsAvailable[player.Position].Count)];
                GoToARoom(_gameEngine.PlayersList.IndexOf(player), randomDestinationId);
            }

            var position = player.Position;

            // Play a random card.
            var randomCardIndex = new Random().Next(player.Hand.Count);
            var success = player.PlayCard(randomCardIndex);
            UpdateCurrentPlayPanel(_gameEngine.PlayersList.IndexOf(player), player.Hand.ElementAt(randomCardIndex), success);

            // Remove the card from the hand.
            player.Hand.RemoveAt(randomCardIndex);

            var newPosition = player.Position;
            if (newPosition != position) GoToARoom(_gameEngine.PlayersList.IndexOf(player), newPosition);

            while (player.Hand.Count > 7) player.LoseCard();

            if (_gameEngine.CurrentYear == 1) _gameEngine.PassToSophomoreYearIfNeeded();
            _gameEngine.ApplyQpStep(player);
            if (_gameEngine.IsGameOver()) EndGame();
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

            UpdateInformationPanel();
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
            }
            _numberOfMoves++;
            if (_numberOfMoves == 3) buttonMove.Enabled = false;
            UpdateInformationPanel();
        }

        private void buttonPlayCard_Click(object sender, EventArgs e)
        {
            var player = _gameEngine.PlayersList[0];
            var position = player.Position;
            // Play the card.
            var cardPlayed =_gameEngine.PlayersList[0].Hand.ElementAt(_indexOfCardDisplayed);
            var success = player.PlayCard(_indexOfCardDisplayed);

            // Remove the card from the Hand and update the display.
            player.Hand.Remove(cardPlayed);
            _indexOfCardDisplayed = 0;
            ChangePictureBoxCardDisplay();

            UpdateCurrentPlayPanel(0, cardPlayed, success);

            // Update position if needed.
            var newPosition = player.Position;
            if (newPosition != position) GoToARoom(0, newPosition);

            buttonPlayCard.Enabled = false;
            if (buttonMove.Enabled) buttonMove.Enabled = false;

            UpdateInformationPanel();

            while (player.Hand.Count > 7)
            {
                var cardDiscarded = player.DiscardCard(null);
                var cardDisplayed = player.Hand.ElementAt(_indexOfCardDisplayed);
                if (cardDisplayed.Equals(cardDiscarded))
                {
                    _indexOfCardDisplayed = 0;
                    ChangePictureBoxCardDisplay();
                }
                UpdateInformationPanel();
            }

            if (_gameEngine.CurrentYear == 1)
                if (_gameEngine.PassToSophomoreYearIfNeeded())
                {
                    _indexOfCardDisplayed = 0;
                    ChangePictureBoxCardDisplay();
                }
            _gameEngine.ApplyQpStep(player);
            if (_gameEngine.IsGameOver()) EndGame();

            UpdateInformationPanel();

            // Each AI plays.
            PlayComputer(_gameEngine.PlayersList[1]);
            PlayComputer(_gameEngine.PlayersList[2]);

            // New turn.
            UpdateInformationPanel();
            buttonDrawCard.Enabled = true;
            _numberOfMoves = 0;
        }

        private void UpdateCurrentPlayPanel(int playerIndex, Card cardPlayed, int success)
        {
            // Display the card played in the Current Play panel.
            var previousText = textBoxCurrentPlay.Text;
            textBoxCurrentPlay.Text = _gameEngine.PlayersList[playerIndex].Name + " played \"" +
                                       cardPlayed.Name;
            if (success == 0) textBoxCurrentPlay.Text += "\" in the wrong room" + "\r\n";
            else if (success == 1) textBoxCurrentPlay.Text += "\" but failed" + "\r\n";
            else if (success == 2) textBoxCurrentPlay.Text += "\" for " + cardPlayed.Reward + "\r\n";
            textBoxCurrentPlay.Text += previousText;
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
            var card = _gameEngine.PlayersList[0].Hand.ElementAt(_indexOfCardDisplayed);
            var cardName = card.GetType().Name;
            string year = null;
            if (card.Year == 1) year = "Freshman";
            else if (card.Year == 2) year = "Sophomore";
            pictureBoxCard.Image = Image.FromFile(@"..\..\Pictures\Cards\" + year + @"\" + cardName + ".png");
        }

        private void UpdateInformationPanel()
        {
            var playersList = _gameEngine.PlayersList;
            var player1 = playersList[0];
            var player2 = playersList[1];
            var player3 = playersList[2];
            textBoxInformationPanel.Text =
                "\t\tLearning\t\tCraft\t\tIntegrity\t\tQualityPoints\r\n" +
                player1.Name + "\t" + player1.LearningChips + "\t\t" + player1.CraftChips + "\t\t" +
                player1.IntegrityChips +
                "\t\t" + player1.QualityPoints + "\r\n" +
                player2.Name + "\t\t" + player2.LearningChips + "\t\t" + player2.CraftChips + "\t\t" +
                player2.IntegrityChips +
                "\t\t" + player2.QualityPoints + "\r\n" +
                player3.Name + "\t\t" + player3.LearningChips + "\t\t" + player3.CraftChips + "\t\t" +
                player3.IntegrityChips +
                "\t\t" + player3.QualityPoints + "\r\n" +
                "\r\n\r\n" +
                "Cards in deck: " + _gameEngine.Deck.Count + "\tDiscards out of play: " +
                _gameEngine.DiscardedDeck.Count + "\r\n\r\n" +
                "You are " + player1.Name + " and you are in " + _gameEngine.RoomNames[player1.Position] + "\r\n" +
                player2.Name + " is in " + _gameEngine.RoomNames[player2.Position] + "\r\n" +
                player3.Name + " is in " + _gameEngine.RoomNames[player3.Position];
        }

        private void EndGame()
        {
            if (MessageBox.Show(_gameEngine.Winner.Name + " has won!", "Game over", MessageBoxButtons.OK,
                MessageBoxIcon.Information) == DialogResult.OK)
                Application.Exit();
        }
    }
}
