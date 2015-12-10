using System.Linq;
using System.Windows.Forms;

namespace SoftwareEngineeringProject
{
    public abstract class Card
    {
        // Return true if success, false if failure.
        public abstract bool Play(Player player);
    }

    class Cecs105 : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 14 || player.Position == 17)
            {
                player.LearningChips++;
                return true;
            }
            return false;
        }
    }

    class ResearchCompilers : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 7)
            {
                player.LearningChips++;
                return true;
            }
            return false;
        }
    }

    class Math122 : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 7)
            {
                var form = new UserChoiceForm("Select the chip you want", new[] { "Learning Chip", "Integrity Chip" });
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    switch (form.GetCmbBoxSelectedContent())
                    {
                        case "Learning Chip":
                            player.LearningChips++;
                            break;
                        case "Integrity Chip":
                            player.IntegrityChips++;
                            break;
                    }
                }
                return true;
            }
            return false;
        }
    }

    class Murgolo : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 14)
            {
                player.LearningChips++;
                return true;
            }
            return false;
        }
    }

    class Bratwurst : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 9)
            {
                player.CraftChips++;
                return true;
            }
            return false;
        }
    }

    class Cecs100 : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 17)
            {
                player.CraftChips++;
                return true;
            }
            return false;
        }
    }

    class Mind : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 5)
            {
                player.IntegrityChips++;
                return true;
            }
            return false;
        }
    }

    class Parking : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 6)
            {
                player.LearningChips++;
                if (
                    MessageBox.Show("Choose!", "Do you want to discard a game card to get another Learning Chips?",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    player.LearningChips++;
                    player.DiscardCard();
                }
                return true;
            }
            return false;
        }
    }

    internal class Finding : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 16)
            {
                player.IntegrityChips++;
                return true;
            }
            return false;
        }
    }

    internal class Goodbye : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 13 && player.LearningChips >= 6 && player.CraftChips >= 6 && player.IntegrityChips >= 6)
            {
                player.QualityPoints += 10;
                return true;
            }

            player.LoseCard();
            return false;
        }
    }

    internal class Peace : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 1)
            {
                player.LearningChips++;
                player.IntegrityChips++;
                return true;
            }
            return false;
        }
    }

    internal class Buddy : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 18 || player.Position == 0)
            {
                var form = new UserChoiceForm("Select the chip you want", new[] { "Learning Chip", "Craft Chip" });
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    switch (form.GetCmbBoxSelectedContent())
                    {
                        case "Learning Chip":
                            player.LearningChips++;
                            break;
                        case "Craft Chip":
                            player.CraftChips++;
                            break;
                    }
                }
                return true;
            }
            return false;
        }
    }

    internal class Late : Card
    {
        public override bool Play(Player player)
        {
            // TODO: checker si c'est bien ca la liste
            if (new[] { 0, 1, 2, 3, 4, 5, 7, 8, 9, 10 }.Contains(player.Position))
            {
                player.CraftChips++;
                player.MovePlayer(20);
                return true;
            }
            return false;
        }
    }

    internal class Physics : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 17 && player.CraftChips >= 3)
            {
                player.QualityPoints += 5;
                return true;
            }

            player.QualityPoints -= 3;
            return false;
        }
    }

    internal class BigGame : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 3)
            {
                player.CraftChips++;
                player.MovePlayer(20);
                return true;
            }
            return false;
        }
    }

    internal class Kin253 : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 0 && player.IntegrityChips >= 4)
            {
                player.CraftChips += 2;
                return true;
            }

            player.MovePlayer(13);
            return false;
        }
    }

    internal class Math123 : Card
    {
        public override bool Play(Player player)
        {
            if ((player.Position == 14 || player.Position == 17) && player.LearningChips >= 5)
            {
                player.QualityPoints += 5;
                return true;
            }

            player.QualityPoints -= 3;
            player.LoseCard();
            return false;
        }
    }

    internal class Netbeans : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 20 && player.LearningChips >= 3)
            {
                player.QualityPoints += 5;
                return true;

            }

            player.QualityPoints -= 3;
            return false;
        }
    }

    internal class Major : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 19 && player.IntegrityChips >= 3)
            {
                player.QualityPoints += 5;
                return true;
            }

            player.QualityPoints -= 3;
            return false;
        }
    }

    internal class SoccerClass : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 0 && player.CraftChips >= 5)
            {
                player.QualityPoints += 5;
                return true;
            }

            player.QualityPoints -= 3;
            return false;
        }
    }

    internal class ScoreGoal : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 0 && player.CraftChips >= 3)
            {
                player.QualityPoints += 5;
                player.IntegrityChips++;
                return true;
            }

            player.MovePlayer(2);
            return false;
        }
    }

    internal class FallPond : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 1 && player.LearningChips >= 3)
            {
                player.IntegrityChips++;
                player.CraftChips++;
                return true;
            }

            player.MovePlayer(20);
            return false;
        }
    }

    internal class MakeDeansList : Card
    {
        public override bool Play(Player player)
        {
            if ((player.Position == 12 || player.Position == 12) && player.LearningChips >= 6)
            {
                player.QualityPoints += 5;
                return true;
            }

            player.MovePlayer(2);
            return false;
        }
    }

    internal class NewLaptop : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 11 && player.IntegrityChips >= 4)
            {
                player.QualityPoints += 3;
                player.GetAChipOfHisChoice();
                return true;
            }
            
                player.DiscardCard();
            return false;
        }
    }

    internal class MeetDean : Card
    {
        public override bool Play(Player player)
        {
            if ((player.Position == 12 || player.Position == 12) && player.LearningChips >= 3 && player.CraftChips >= 3 && player.IntegrityChips >= 3)
            {
                player.QualityPoints += 5;
                player.DrawCard();
                return true;
            }
            
                player.DiscardCard();
            return false;
        }
    }

    internal class LoudBuzzing : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 18 && player.CraftChips >= 3)
            {
                player.GetAChipOfHisChoice();
                return true;
            }
            
                player.QualityPoints -= 2;
            return false;
        }
    }

    internal class ProgramCrashes : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 20 && player.LearningChips >= 2)
            {
                player.QualityPoints += 5;
                player.GetAChipOfHisChoice();
                return true;
            }
            
                player.DiscardCard();
            return false;
        }
    }

    internal class ProfessorEnglert : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 19 && player.IntegrityChips >= 3)
            {
                player.GetAChipOfHisChoice();
                return true;
            }
            
                player.DiscardCard();
            return false;
        }
    }

    internal class PressRightFloor : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 16 && player.LearningChips >= 4)
            {
                player.CraftChips += 2;
                return true;
            }
            
                player.QualityPoints -= 2;
            return false;
        }
    }

    internal class SoccerGoalie : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 0 && player.LearningChips >= 3 && player.CraftChips >= 3)
            {
                player.QualityPoints += 5;
                player.DrawCard();
                return true;
            }
            
                player.MovePlayer(2);
            return false;
        }
    }

    internal class ElectiveClass : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 7 && player.LearningChips >= 2)
            {
                player.LearningChips++;
                player.DrawCard();
                return true;
            }
            
                player.QualityPoints -= 2;
            return false;
        }
    }

    internal class OralCommunication : Card
    {
        public override bool Play(Player player)
        {
            if (new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.Contains(player.Position) && player.IntegrityChips >= 4)
            {
                player.QualityPoints += 4;
                player.GetAChipOfHisChoice();
                return true;
            }
            
                player.DiscardCard();
            return false;
        }
    }

    internal class Hoffman : Card
    {
        public override bool Play(Player player)
        {
            if (new[] { 11, 13, 14, 16, 17, 18, 19 }.Contains(player.Position) && player.LearningChips >= 3)
            {
                player.QualityPoints += 5;
                player.DrawCard();
                player.DrawCard();
                return true;
            }
           
                player.QualityPoints -= 5;
                player.MovePlayer(20);
            return false;
        }
    }

    internal class Chem111 : Card
    {
        public override bool Play(Player player)
        {
            if (new[] { 2, 3, 4, 5, 7, 8, 9 }.Contains(player.Position) && player.CraftChips >= 6)
            {
                player.QualityPoints += 5;
                return true;
            }
            
                player.MovePlayer(2);
            return false;
        }
    }

    internal class Outpost : Card
    {
        public override bool Play(Player player)
        {
            if (new[] { 0, 1, 2, 3, 4, 5, 7, 8, 9, 10 }.Contains(player.Position) && player.CraftChips >= 6)
            {
                player.GetAChipOfHisChoice();
                return true;
            }
            return false;
        }
    }

    internal class LearningLinux : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 11 && player.CraftChips >= 2 && player.IntegrityChips >= 3)
            {
                player.QualityPoints += 3;
                player.GetAChipOfHisChoice();
                return true;
            }
            
                player.QualityPoints--;
            return false;
        }
    }

    internal class MakeFriend : Card
    {
        public override bool Play(Player player)
        {
            if ((player.Position == 12 || player.Position == 15) && player.IntegrityChips >= 2)
            {
                player.QualityPoints += 3;
                player.GetAChipOfHisChoice();
                return true;
            }
            
                player.DiscardCard();
            return false;
        }
    }

    internal class EnjoyingNature : Card
    {
        public override bool Play(Player player)
        {
            if (new[] { 0, 1, 2, 3, 4, 5, 7, 8, 9, 10 }.Contains(player.Position))
            {
                player.CraftChips++;
                player.MovePlayer(20);
                return true;
            }
            return false;
        }
    }

    internal class StudentParking : Card
    {
        public override bool Play(Player player)
        {
            if (player.Position == 2)
            {
                player.CraftChips++;
                player.MovePlayer(20);
                return true;
            }
            return false;
        }
    }
}
