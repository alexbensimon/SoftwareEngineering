﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SoftwareEngineeringProject
{
    public class Player
    {
        public string Name { get; set; }

        // The position of the player is a room id.
        public int Position { get; set; }

        public int QualityPoints { get; set; }
        public int LearningChips { get; set; }
        public int CraftChips { get; set; }
        public int IntegrityChips { get; set; }

        public List<Card> Hand = new List<Card>();

        public void DiscardCard()
        {
            var cardNames = new string[Hand.Count];
            var counter = 0;

            foreach (var card in Hand)
            {
                cardNames[counter] = card.GetType().Name;
                counter++;
            }
            var form = new UserChoiceForm("Choose the card you want to discard", cardNames);

            DialogResult result;
            do
            {
                result = form.ShowDialog();
            } while (result != DialogResult.OK);

            var cardToRemove = Hand.ElementAt(form.GetCmbBoxSelectedId());
            Hand.Remove(cardToRemove);
            GameEngine.DiscardedDeck.Add(cardToRemove);
        }

        public void LoseCard()
        {
            var rnd = new Random();
            var card = Hand.ElementAt(rnd.Next());
            Hand.Remove(card);
            GameEngine.DiscardedDeck.Add(card);
        }

        public void DrawCard()
        {
            Hand.Add(GameEngine.Deck.First());
            GameEngine.Deck.Remove(GameEngine.Deck.First());
        }

        public void MovePlayer(int roomId)
        {

        }

        public void GetAChipOfHisChoice()
        {
            var form = new UserChoiceForm("Select the chip you want", new[] { "Learning Chip", "Craft Chip", "Integrity Chip" });
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
    }
}
