using System.Collections.Generic;
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

        }

        public void LoseCard()
        {

        }

        public void DrawCard()
        {

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
