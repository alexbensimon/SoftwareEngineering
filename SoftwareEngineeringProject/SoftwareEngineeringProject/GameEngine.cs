using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareEngineeringProject
{
    public class GameEngine
    {
        public List<Player> PlayersList { get; set; }

        public List<string> RoomNames { get; set; } = new List<string>
        {
            "George Allen Field", "Japanese Garden", "Student Parking", "The Pyramid", "West Walkway",
            "Rec Center", "Forbidden Parking", "Library", "LA 5", "Bratwurst Hall", "East Walkway",
            "Computer Lab", "North Hall", "Room of Retirement", "ECS 302", "South Hall", "Elevators", "ECS 308",
            "EAT Club", "CECS Conference Room", "Lactation Lounge"
        };

        public List<List<int>> RoomsAvailable { get; set; } = new List<List<int>>
        {
            new List<int> {1, 3}, new List<int> {0, 2, 3}, new List<int> {1, 3, 5, 6},
            new List<int> {0, 1, 2, 5}, new List<int> {5, 7, 12}, new List<int> {2, 3, 4, 6},
            new List<int> {2, 5, 10}, new List<int> {4, 8}, new List<int> {7, 9, 16}, new List<int> {8, 10},
            new List<int> {6, 9, 15}, new List<int> {12}, new List<int> {4, 11, 13, 14, 15, 16},
            new List<int> {12}, new List<int> {12, 15}, new List<int> {10, 12, 14, 17, 18, 19, 20},
            new List<int> {8, 12}, new List<int> {15}, new List<int> {15}, new List<int> {15}, new List<int> {15}
        };

        public int[,] RoomCoordinates { get; set; } =
        {
            {38, 97}, {465, 54}, {964, 66}, {434, 288}, {27, 696}, {534, 572}, {1282, 512}, {71, 1726},
            {570, 1766}, {1132, 1636}, {1463, 975}, {216, 893}, {191, 1167}, {758, 1056}, {600, 892},
            {1000, 1160}, {594, 1406}, {816, 1347}, {1021, 891}, {1249, 887}, {1209, 1401}
        };

        public List<Card> Deck = new List<Card>();
        public List<Card> DiscardedDeck = new List<Card>();

        public GameEngine()
        {
            var humanPlayer = new Player("Human player", this);
            var aI1 = new Player("AI 1", this);
            var aI2 = new Player("AI 2", this);

            PlayersList = new List<Player> { humanPlayer, aI1, aI2 };

            // Initial position.
            foreach (var player in PlayersList)
            {
                player.Position = 17;
            }

            AssignRandomSkillSets(PlayersList);
            InitiateDeck();
            ShuffleDeck();
            AssignRandomHands(PlayersList);
        }

        private static void AssignRandomSkillSets(List<Player> playersList)
        {
            var skillSets = new List<List<int>> {
                new List<int> {2, 2, 2},
                new List<int> {3, 1 ,2},
                new List<int> {0, 3, 3}
            };

            foreach (var player in playersList)
            {
                var skillSetIndex = new Random().Next(skillSets.Count);
                var currentSkillSet = skillSets[skillSetIndex];

                player.LearningChips = currentSkillSet[0];
                player.CraftChips = currentSkillSet[1];
                player.IntegrityChips = currentSkillSet[2];

                skillSets.RemoveAt(skillSetIndex);
            }
        }

        private void InitiateDeck()
        {
            //Add all class derived from the abstract class Card to the Deck
            foreach (Type type in
            AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(assembly => assembly.GetTypes())
                       .Where(type => type.IsSubclassOf(typeof(Card))))
            {
                Deck.Add((Card)Activator.CreateInstance(type));
            }
        }

        private void AssignRandomHands(List<Player> playersList)
        {
            //Initiate hands of the players with the cards on top of the deck (it has been shuffled before)
            foreach (var player in playersList)
            {
                for (int i = 0; i < 5; i++)
                {
                    player.Hand.Add(Deck.First());
                    Deck.RemoveAt(0);
                }
            }
        }

        private void ShuffleDeck()
        {
            var tmpDeck = new Card[Deck.Count];
            Deck.CopyTo(tmpDeck);
            var tmpDeckList = tmpDeck.ToList();
            Deck.Clear();
            Random rnd = new Random();

            foreach (var card in tmpDeck)
            {
                int index = rnd.Next(tmpDeckList.Count);
                Deck.Add(tmpDeckList.ElementAt(index));
                tmpDeckList.RemoveAt(index);
            }
        }
    }
}
