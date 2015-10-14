using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineeringProject
{
    class GameEngine
    {
        private Player _humanPlayer;

        public GameEngine()
        {
            var playersList = new List<Player> {_humanPlayer, new Player(), new Player()};

            AssignRandomSkillSets(playersList);
        }

        private void AssignRandomSkillSets(List<Player> playersList)
        {
            var skillSets = new List<List<int>> {
                new List<int> {2, 2, 2},
                new List<int> {3, 1 ,2},
                new List<int> {0, 3, 3}
            };

            foreach (var player in playersList)
            {
                player.LearningChips = 0;
                player.CraftChips = 0;
                player.IntegrityChips = 0;
            }
        }
    }
}
