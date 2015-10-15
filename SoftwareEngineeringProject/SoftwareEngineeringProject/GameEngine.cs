using System;
using System.Collections.Generic;

namespace SoftwareEngineeringProject
{
    class GameEngine
    {
        public GameEngine()
        {
            var humanPlayer = new Player();
            var aI1 = new Player();
            var aI2 = new Player();

            var playersList = new List<Player> {humanPlayer, aI1, aI2};

            AssignRandomSkillSets(playersList);
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
    }
}
