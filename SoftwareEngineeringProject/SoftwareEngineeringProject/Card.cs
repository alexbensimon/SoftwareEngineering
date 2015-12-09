using System.Linq;
using System.Windows.Forms;

namespace SoftwareEngineeringProject
{
    public abstract class Card
    {
        public abstract void Play(Player player);
    }

    class Cecs105 : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 14 || player.Position == 17)
            {
                player.LearningChips++;
            }
        }
    }

    class ResearchCompilers : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 7)
            {
                player.LearningChips++;
            }
        }
    }

    class Math122 : Card
    {
        public override void Play(Player player)
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
            }
        }
    }

    class Murgolo : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 14)
            {
                player.LearningChips++;
            }
        }
    }

    class Bratwurst : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 9)
            {
                player.CraftChips++;
            }
        }
    }

    class Cecs100 : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 17)
            {
                player.CraftChips++;
            }
        }
    }

    class Mind : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 5)
            {
                player.IntegrityChips++;
            }
        }
    }

    class Parking : Card
    {
        public override void Play(Player player)
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
            }
        }
    }

    internal class Finding : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 16)
            {
                player.IntegrityChips++;
            }
        }
    }

    internal class Goodbye : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 13 && player.LearningChips >= 6 && player.CraftChips >= 6 && player.IntegrityChips >= 6)
            {
                player.QualityPoints += 10;
            }
            else
            {
                player.LoseCard();
            }
        }
    }

    internal class Peace : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 1)
            {
                player.LearningChips++;
                player.IntegrityChips++;
            }
        }
    }

    internal class Buddy : Card
    {
        public override void Play(Player player)
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
            }
        }
    }

    internal class Late : Card
    {
        public override void Play(Player player)
        {
            // TODO: checker si c'est bien ca la liste
            if (new[] { 0, 1, 2, 3, 4, 5, 7, 8, 9, 10 }.Contains(player.Position))
            {
                player.CraftChips++;
                player.MovePlayer(20);
            }
        }
    }

    internal class Physics : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 17 && player.CraftChips >= 3)
            {
                player.QualityPoints += 5;
            }
            else
            {
                player.QualityPoints -= 3;
            }
        }
    }

    internal class BigGame : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 3)
            {
                player.CraftChips++;
                player.MovePlayer(20);
            }
        }
    }

    internal class Kin253 : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 0 && player.IntegrityChips >= 4)
            {
                player.CraftChips += 2;
            }
            else
            {
                player.MovePlayer(13);
            }
        }
    }

    internal class Math123 : Card
    {
        public override void Play(Player player)
        {
            if ((player.Position == 14 || player.Position == 17) && player.LearningChips >= 5)
            {
                player.QualityPoints += 5;
            }
            else
            {
                player.QualityPoints -= 3;
                player.LoseCard();
            }
        }
    }

    internal class Netbeans : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 20 && player.LearningChips >= 3)
            {
                player.QualityPoints += 5;
            }
            else
            {
                player.QualityPoints -= 3;
            }
        }
    }

    internal class Major : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 19 && player.IntegrityChips >= 3)
            {
                player.QualityPoints += 5;
            }
            else
            {
                player.QualityPoints -= 3;
            }
        }
    }

    internal class SoccerClass : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 0 && player.CraftChips >= 5)
            {
                player.QualityPoints += 5;
            }
            else
            {
                player.QualityPoints -= 3;
            }
        }
    }

    internal class ScoreGoal : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 0 && player.CraftChips >= 3)
            {
                player.QualityPoints += 5;
                player.IntegrityChips++;
            }
            else
            {
                player.MovePlayer(2);
            }
        }
    }

    internal class FallPond : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 1 && player.LearningChips >= 3)
            {
                player.IntegrityChips++;
                player.CraftChips++;
            }
            else
            {
                player.MovePlayer(20);
            }
        }
    }

    internal class MakeDeansList : Card
    {
        public override void Play(Player player)
        {
            if ((player.Position == 12 || player.Position == 12) && player.LearningChips >= 6)
            {
                player.QualityPoints += 5;
            }
            else
            {
                player.MovePlayer(2);
            }
        }
    }

    internal class Newlaptop : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 11 && player.IntegrityChips >= 4)
            {
                player.QualityPoints += 3;
                player.GetAChipOfHisChoice();
            }
            else
            {
                player.DiscardCard();
            }
        }
    }

    internal class MeatDean : Card
    {
        public override void Play(Player player)
        {
            if ((player.Position == 12 || player.Position == 12) && player.LearningChips >= 3 && player.CraftChips >= 3 && player.IntegrityChips >= 3)
            {
                player.QualityPoints += 5;
                player.DrawCard();
            }
            else
            {
                player.DiscardCard();
            }
        }
    }

    internal class LoudBuzzing : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 18 && player.CraftChips >= 3)
            {
                player.GetAChipOfHisChoice();
            }
            else
            {
                player.QualityPoints -= 2;
            }
        }
    }

    internal class ProgramCrashes : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 20 && player.LearningChips >= 2)
            {
                player.QualityPoints += 5;
                player.GetAChipOfHisChoice();
            }
            else
            {
                player.DiscardCard();
            }
        }
    }

    internal class ProfesorEnglert : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 19 && player.IntegrityChips >= 3)
            {
                player.GetAChipOfHisChoice();
            }
            else
            {
                player.DiscardCard();
            }
        }
    }

    internal class PressRightFloor : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 16 && player.LearningChips >= 4)
            {
                player.CraftChips += 2;
            }
            else
            {
                player.QualityPoints -= 2;
            }
        }
    }

    internal class SoccerGoalie : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 0 && player.LearningChips >= 3 && player.CraftChips >= 3)
            {
                player.QualityPoints += 5;
                player.DrawCard();
            }
            else
            {
                player.MovePlayer(2);
            }
        }
    }

    internal class ElectiveClass : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 7 && player.LearningChips >= 2)
            {
                player.LearningChips++;
                player.DrawCard();
            }
            else
            {
                player.QualityPoints -= 2;
            }
        }
    }

    internal class OralCommunication : Card
    {
        public override void Play(Player player)
        {
            if (new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.Contains(player.Position) && player.IntegrityChips >= 4)
            {
                player.QualityPoints += 4;
                player.GetAChipOfHisChoice();
            }
            else
            {
                player.DiscardCard();
            }
        }
    }

    internal class Hoffman : Card
    {
        public override void Play(Player player)
        {
            if (new[] { 11, 13, 14, 16, 17, 18, 19 }.Contains(player.Position) && player.LearningChips >= 3)
            {
                player.QualityPoints += 5;
                player.DrawCard();
                player.DrawCard();
            }
            else
            {
                player.QualityPoints -= 5;
                player.MovePlayer(20);
            }
        }
    }

    internal class Chem111 : Card
    {
        public override void Play(Player player)
        {
            if (new[] { 2, 3, 4, 5, 7, 8, 9 }.Contains(player.Position) && player.CraftChips >= 6)
            {
                player.QualityPoints += 5;
            }
            else
            {
                player.MovePlayer(2);
            }
        }
    }

    internal class Outpost : Card
    {
        public override void Play(Player player)
        {
            if (new[] { 0, 1, 2, 3, 4, 5, 7, 8, 9, 10 }.Contains(player.Position) && player.CraftChips >= 6)
            {
                player.GetAChipOfHisChoice();
            }
        }
    }

    internal class LearningLinux : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 11 && player.CraftChips >= 2 && player.IntegrityChips >= 3)
            {
                player.QualityPoints += 3;
                player.GetAChipOfHisChoice();
            }
            else
            {
                player.QualityPoints--;
            }
        }
    }

    internal class MakeFriend : Card
    {
        public override void Play(Player player)
        {
            if ((player.Position == 12 || player.Position == 15) && player.IntegrityChips >= 2)
            {
                player.QualityPoints += 3;
                player.GetAChipOfHisChoice();
            }
            else
            {
                player.DiscardCard();
            }
        }
    }

    internal class EnjoyingNature : Card
    {
        public override void Play(Player player)
        {
            if (new[] { 0, 1, 2, 3, 4, 5, 7, 8, 9, 10 }.Contains(player.Position))
            {
                player.CraftChips++;
                player.MovePlayer(20);
            }
        }
    }

    internal class StudentParking : Card
    {
        public override void Play(Player player)
        {
            if (player.Position == 2)
            {
                player.CraftChips++;
                player.MovePlayer(20);
            }
        }
    }
}
