using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SoftwareEngineeringProject
{
    public class Player
    {
        public string Name { get; }

        // The position of the player is a room id.
        public int Position { get; set; }

        public int LearningChips { get; set; }
        public int CraftChips { get; set; }
        public int IntegrityChips { get; set; }
        public int QualityPoints { get; set; }

        public List<Card> Hand = new List<Card>();

        private readonly GameEngine _gameEngine;

        public Player(string name, GameEngine gameEngine)
        {
            Name = name;
            _gameEngine = gameEngine;
        }

        public Card DiscardCard(Card parent)
        {
            if (Name == "Human Player")
            {
                Card cardToRemove = null;
                var cardNames = parent == null ? new string[Hand.Count] : new string[Hand.Count - 1];
                var counter = 0;
                foreach (var card in Hand)
                {
                    if (!card.Equals(parent))
                    {
                        cardNames[counter] = card.Name;
                        counter++;
                    }
                }
                var form = new UserChoiceForm("Choose the card you want to discard", cardNames);
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    cardToRemove = Hand.ElementAt(form.GetCmbBoxSelectedId());
                    Hand.Remove(cardToRemove);
                    _gameEngine.DiscardedDeck.Add(cardToRemove);
                }
                return cardToRemove;
            }
            LoseCard();
            return null;
        }

        public void LoseCard()
        {
            var card = Hand.ElementAt(new Random().Next(Hand.Count));
            Hand.Remove(card);
            _gameEngine.DiscardedDeck.Add(card);
        }

        public void DrawCard()
        {
            Hand.Add(_gameEngine.Deck.First());
            _gameEngine.Deck.Remove(_gameEngine.Deck.First());
            _gameEngine.VerifyIfDeckEmpty();
        }

        public void GetAChipOfHisChoice()
        {
            if (Equals(_gameEngine.PlayersList[0]))
            {
                var form = new UserChoiceForm("Select the chip you want",
                    new[] { "Learning Chip", "Craft Chip", "Integrity Chip" });
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    switch (form.GetCmbBoxSelectedContent())
                    {
                        case "Learning Chip":
                            LearningChips++;
                            break;
                        case "Craft Chip":
                            CraftChips++;
                            break;
                        case "Integrity Chip":
                            IntegrityChips++;
                            break;
                    }
                }
            }
            else
            {
                // If the player is AI, do it randomly.
                var bonus = new Random().Next(3);
                switch (bonus)
                {
                    case 0:
                        LearningChips++;
                        break;
                    case 1:
                        CraftChips++;
                        break;
                    case 2:
                        IntegrityChips++;
                        break;
                }
            }
        }

        public int PlayCard(int indexCardInHand)
        {
            var success = 0;
            var card = Hand.ElementAt(indexCardInHand);
            _gameEngine.DiscardedDeck.Add(card);
            if (card.CorrectRooms.Contains(Position))
            {
                success = 1;
                if (card.Play(this)) return 2;
            }
            QualityPoints -= 2;
            return success;
        }
    }
}
