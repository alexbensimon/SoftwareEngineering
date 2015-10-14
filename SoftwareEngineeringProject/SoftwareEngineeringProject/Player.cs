using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineeringProject
{
    class Player
    {
        private string name;
        // The position of the player is a room id.
        private int _position;
        private int _qualityPoints;
        public int LearningChips { get; set; }
        public int CraftChips { get; set; }
        public int IntegrityChips { get; set; }
    }
}
