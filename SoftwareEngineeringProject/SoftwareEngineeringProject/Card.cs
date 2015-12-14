using System;
using System.Windows.Forms;

namespace SoftwareEngineeringProject
{
    public abstract class Card
    {
        public abstract string Name { get; }
        public abstract string Reward { get; }
        public abstract int Year { get; }
        public abstract int[] CorrectRooms { get; }

        // Return true if success, false if failure.
        public abstract bool Play(Player player);
    }

    class Cecs105 : Card
    {
        public override string Name => "CECS 105";
        public override string Reward => "1 Learning Chip";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 14, 17 };

        public override bool Play(Player player)
        {
            player.LearningChips++;
            return true;
        }
    }


    class ResearchCompilers : Card
    {
        public override string Name => "Research Compilers";
        public override string Reward => "1 Learning Chip";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 7 };

        public override bool Play(Player player)
        {
            player.LearningChips++;
            return true;
        }
    }

    class Math122 : Card
    {
        public override string Name => "Math 122";
        private string _reward = "1 Learning chip or 1 Integrity Chip";
        public override string Reward => _reward;
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 7 };

        public override bool Play(Player player)
        {
            if (player.Name == "Human Player")
            {
                var form = new UserChoiceForm("Select the chip you want", new[] { "Learning Chip", "Integrity Chip" });
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    switch (form.GetCmbBoxSelectedContent())
                    {
                        case "Learning Chip":
                            _reward = "1 Learning Chip";
                            player.LearningChips++;
                            break;
                        case "Integrity Chip":
                            _reward = "1 Integrity Chip";
                            player.IntegrityChips++;
                            break;
                    }
                }
            }
            else
            {
                var bonus = new Random().Next(2);
                switch (bonus)
                {
                    case 0:
                        _reward = "1 Learning Chip";
                        player.LearningChips++;
                        break;
                    case 1:
                        _reward = "1 Integrity Chip";
                        player.IntegrityChips++;
                        break;
                }
            }
            return true;
        }
    }

    class Murgolo : Card
    {
        public override string Name => "Professor Murgolo's CECS 174 Class";
        public override string Reward => "1 Learning Chip";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 14 };

        public override bool Play(Player player)
        {
            player.LearningChips++;
            return true;
        }
    }

    class Bratwurst : Card
    {
        public override string Name => "Lunch at Bratwurst Hall";
        public override string Reward => "1 Craft Chip";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 9 };

        public override bool Play(Player player)
        {
            player.CraftChips++;
            return true;
        }
    }

    class Cecs100 : Card
    {
        public override string Name => "CECS 100";
        public override string Reward => "1 Craft Chip";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 17 };

        public override bool Play(Player player)
        {
            player.CraftChips++;
            return true;
        }
    }

    class Mind : Card
    {
        public override string Name => "Exercising Mind and Body";
        public override string Reward => "1 Integrity Chip";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 5 };

        public override bool Play(Player player)
        {
            player.IntegrityChips++;
            return true;
        }
    }

    class Parking : Card
    {
        public override string Name => "Parking Violation";
        private string _reward = "1 Learning Chip or 2 Learning Chips and 1 discarded card";
        public override string Reward => _reward;
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 6 };

        public override bool Play(Player player)
        {
            if (player.Name == "Human Player")
            {
                _reward = "1 Learning Chip";
                player.LearningChips++;
                if (MessageBox.Show("Choose!", "Do you want to discard a game card to get another Learning Chips?",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _reward = "2 Learning Chips and 1 discarded card";
                    player.LearningChips++;
                    player.DiscardCard();
                }
            }
            else
            {
                var bonus = new Random().Next(2);
                switch (bonus)
                {
                    case 0:
                        _reward = "1 Learning Chip";
                        player.LearningChips++;
                        break;
                    case 1:
                        _reward = "2 Learning Chips and 1 discarded card";
                        player.LearningChips++;
                        player.DiscardCard();
                        break;
                }
            }
            return true;
        }
    }

    class Finding : Card
    {
        public override string Name => "Finding the Lab";
        public override string Reward => "1 Integrity Chip";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 16 };

        public override bool Play(Player player)
        {
            player.IntegrityChips++;
            return true;
        }
    }

    class Goodbye : Card
    {
        public override string Name => "Goodbye, Professor";
        public override string Reward => "10 Quality Points";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 13 };

        public override bool Play(Player player)
        {
            if (player.LearningChips >= 6 && player.CraftChips >= 6 && player.IntegrityChips >= 6)
            {
                player.QualityPoints += 10;
                return true;
            }
            player.LoseCard();
            return false;
        }
    }

    class Peace : Card
    {
        public override string Name => "Enjoying the Peace";
        private string _reward = "1 Learning Chip or 1 Integrity Chip";
        public override string Reward => _reward;
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 1 };

        public override bool Play(Player player)
        {
            if (player.Name == "Human Player")
            {
                var form = new UserChoiceForm("Select the chip you want", new[] { "Learning Chip", "Integrity Chip" });
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    switch (form.GetCmbBoxSelectedContent())
                    {
                        case "Learning Chip":
                            _reward = "1 Learning Chip";
                            player.LearningChips++;
                            break;
                        case "Integrity Chip":
                            _reward = "1 Integrity Chip";
                            player.IntegrityChips++;
                            break;
                    }
                }
            }
            else
            {
                var bonus = new Random().Next(2);
                switch (bonus)
                {
                    case 0:
                        _reward = "1 Learning Chip";
                        player.LearningChips++;
                        break;
                    case 1:
                        _reward = "1 Integrity Chip";
                        player.IntegrityChips++;
                        break;
                }
            }
            return true;
        }
    }

    class Buddy : Card
    {
        public override string Name => "Buddy Up";
        private string _reward = "1 Learning Chip or 1 Craft Chip";
        public override string Reward => _reward;
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 0, 18 };

        public override bool Play(Player player)
        {
            if (player.Name == "Human Player")
            {
                var form = new UserChoiceForm("Select the chip you want", new[] { "Learning Chip", "Craft Chip" });
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    switch (form.GetCmbBoxSelectedContent())
                    {
                        case "Learning Chip":
                            _reward = "1 Learning Chip";
                            player.LearningChips++;
                            break;
                        case "Craft Chip":
                            _reward = "1 Craft Chip";
                            player.CraftChips++;
                            break;
                    }
                }
            }
            else
            {
                var bonus = new Random().Next(2);
                switch (bonus)
                {
                    case 0:
                        _reward = "1 Learning Chip";
                        player.LearningChips++;
                        break;
                    case 1:
                        _reward = "1 Craft Chip";
                        player.CraftChips++;
                        break;
                }
            }
            return true;
        }
    }

    class Late : Card
    {
        public override string Name => "Late for Class";
        public override string Reward => "1 Craft Chip";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 0, 1, 2, 3, 4, 5, 7, 8, 9, 10 };

        public override bool Play(Player player)
        {
            player.CraftChips++;
            player.Position = 20;
            return true;
        }
    }

    class Physics : Card
    {
        public override string Name => "Physics 151";
        public override string Reward => "5 Quality Points";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 17 };

        public override bool Play(Player player)
        {
            if (player.CraftChips >= 3)
            {
                player.QualityPoints += 5;
                return true;
            }
            player.QualityPoints -= 3;
            return false;
        }
    }

    class BigGame : Card
    {
        public override string Name => "The Big Game";
        public override string Reward => "1 Craft Chip";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 3 };

        public override bool Play(Player player)
        {
            player.CraftChips++;
            player.Position = 20;
            return true;
        }
    }

    class Kin253 : Card
    {
        public override string Name => "KIN 253";
        public override string Reward => "2 Craft Chips";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 0 };

        public override bool Play(Player player)
        {
            if (player.IntegrityChips >= 4)
            {
                player.CraftChips += 2;
                return true;
            }
            player.Position = 13;
            return false;
        }
    }

    class Math123 : Card
    {
        public override string Name => "Math 123";
        public override string Reward => "5 Quality Points";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 14, 17 };

        public override bool Play(Player player)
        {
            if (player.LearningChips >= 5)
            {
                player.QualityPoints += 5;
                return true;
            }
            player.QualityPoints -= 3;
            player.LoseCard();
            return false;
        }
    }

    class Netbeans : Card
    {
        public override string Name => "Learning Netbeans";
        public override string Reward => "5 Quality Points";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 20 };

        public override bool Play(Player player)
        {
            if (player.LearningChips >= 3)
            {
                player.QualityPoints += 5;
                return true;
            }
            player.QualityPoints -= 3;
            return false;
        }
    }

    class Major : Card
    {
        public override string Name => "Choosing a Major";
        public override string Reward => "5 Quality Points";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 19 };

        public override bool Play(Player player)
        {
            if (player.IntegrityChips >= 3)
            {
                player.QualityPoints += 5;
                return true;
            }
            player.QualityPoints -= 3;
            return false;
        }
    }

    class SoccerClass : Card
    {
        public override string Name => "Pass Soccer Class";
        public override string Reward => "5 Quality Points";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 0 };

        public override bool Play(Player player)
        {
            if (player.CraftChips >= 5)
            {
                player.QualityPoints += 5;
                return true;
            }
            player.QualityPoints -= 3;
            return false;
        }
    }

    class ScoreGoal : Card
    {
        public override string Name => "Score a Goal!";
        public override string Reward => "5 Quality Points and 1 Integrity Chip";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 0 };

        public override bool Play(Player player)
        {
            if (player.CraftChips >= 3)
            {
                player.QualityPoints += 5;
                player.IntegrityChips++;
                return true;
            }
            player.Position = 2;
            return false;
        }
    }

    class FallPond : Card
    {
        public override string Name => "Fall in the Pond";
        public override string Reward => "1 Integrity Chip and 1 Craft Chip";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 1 };

        public override bool Play(Player player)
        {
            if (player.LearningChips >= 3)
            {
                player.IntegrityChips++;
                player.CraftChips++;
                return true;
            }
            player.Position = 20;
            return false;
        }
    }

    class MakeDeansList : Card
    {
        public override string Name => "Make the Dean's List";
        public override string Reward => "5 Quality Points";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 12, 15 };

        public override bool Play(Player player)
        {
            if (player.LearningChips >= 6)
            {
                player.QualityPoints += 5;
                return true;
            }
            player.Position = 2;
            return false;
        }
    }

    class NewLaptop : Card
    {
        public override string Name => "A New Laptop";
        public override string Reward => "3 Quality Points and a Chip of his choice";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 11 };

        public override bool Play(Player player)
        {
            if (player.IntegrityChips >= 4)
            {
                player.QualityPoints += 3;
                player.GetAChipOfHisChoice();
                return true;
            }
            player.DiscardCard();
            return false;
        }
    }

    class MeetDean : Card
    {
        public override string Name => "Meet the Dean";
        public override string Reward => "5 Quality Points and a game card";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 12, 15 };

        public override bool Play(Player player)
        {
            if (player.LearningChips >= 3 && player.CraftChips >= 3 && player.IntegrityChips >= 3)
            {
                player.QualityPoints += 5;
                player.DrawCard();
                return true;
            }
            player.DiscardCard();
            return false;
        }
    }

    class LoudBuzzing : Card
    {
        public override string Name => "Loud Buzzing";
        public override string Reward => "1 Chip of his choice";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 18 };

        public override bool Play(Player player)
        {
            if (player.CraftChips >= 3)
            {
                player.GetAChipOfHisChoice();
                return true;
            }
            player.QualityPoints -= 2;
            return false;
        }
    }

    class ProgramCrashes : Card
    {
        public override string Name => "Program crashes";
        public override string Reward => "5 Quality Points and 1 Chip of his choice";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 20 };

        public override bool Play(Player player)
        {
            if (player.LearningChips >= 2)
            {
                player.QualityPoints += 5;
                player.GetAChipOfHisChoice();
                return true;
            }
            player.DiscardCard();
            return false;
        }
    }

    class ProfessorEnglert : Card
    {
        public override string Name => "Professor Englert";
        public override string Reward => "1 Chip of his choice";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 19 };

        public override bool Play(Player player)
        {
            if (player.IntegrityChips >= 3)
            {
                player.GetAChipOfHisChoice();
                return true;
            }
            player.DiscardCard();
            return false;
        }
    }

    class PressRightFloor : Card
    {
        public override string Name => "Press the Right Floor";
        public override string Reward => "2 Craft Chips";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 16 };

        public override bool Play(Player player)
        {
            if (player.LearningChips >= 4)
            {
                player.CraftChips += 2;
                return true;
            }
            player.QualityPoints -= 2;
            return false;
        }
    }

    class SoccerGoalie : Card
    {
        public override string Name => "Soccer Goalie";
        public override string Reward => "5 Quality Points and 1 Game Card";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 0 };

        public override bool Play(Player player)
        {
            if (player.LearningChips >= 3 && player.CraftChips >= 3)
            {
                player.QualityPoints += 5;
                player.DrawCard();
                return true;
            }
            player.Position = 2;
            return false;
        }
    }

    class ElectiveClass : Card
    {
        public override string Name => "Elective Class";
        public override string Reward => "1 Learning Chip and 1 Game Card";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 7 };

        public override bool Play(Player player)
        {
            if (player.LearningChips >= 2)
            {
                player.LearningChips++;
                player.DrawCard();
                return true;
            }
            player.QualityPoints -= 2;
            return false;
        }
    }

    class OralCommunication : Card
    {
        public override string Name => "Oral Communication";
        public override string Reward => "4 Quality Points and 1 Chip of his Choice";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public override bool Play(Player player)
        {
            if (player.IntegrityChips >= 4)
            {
                player.QualityPoints += 4;
                player.GetAChipOfHisChoice();
                return true;
            }
            player.DiscardCard();
            return false;
        }
    }

    class Hoffman : Card
    {
        public override string Name => "Professor Hoffman";
        public override string Reward => "5 Quality Points and 2 Game Cards";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 11, 13, 14, 16, 17, 18, 19 };

        public override bool Play(Player player)
        {
            if (player.LearningChips >= 3)
            {
                player.QualityPoints += 5;
                player.DrawCard();
                player.DrawCard();
                return true;
            }
            player.QualityPoints -= 5;
            player.Position = 20;
            return false;
        }
    }

    class Chem111 : Card
    {
        public override string Name => "CHEM 111";
        public override string Reward => "5 Quality Points";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public override bool Play(Player player)
        {
            if (player.CraftChips >= 6)
            {
                player.QualityPoints += 5;
                return true;
            }
            player.Position = 2;
            return false;
        }
    }

    class Outpost : Card
    {
        public override string Name => "The Outpost";
        public override string Reward => "1 Chip of his choice";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 0, 1, 2, 3, 4, 5, 7, 8, 9, 10 };

        public override bool Play(Player player)
        {
            player.GetAChipOfHisChoice();
            return true;
        }
    }

    class LearningLinux : Card
    {
        public override string Name => "Learning Linux";
        public override string Reward => "3 Quality Points and 1 Chip of his Choice";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 11 };

        public override bool Play(Player player)
        {
            if (player.CraftChips >= 2 && player.IntegrityChips >= 3)
            {
                player.QualityPoints += 3;
                player.GetAChipOfHisChoice();
                return true;
            }
            player.QualityPoints--;
            return false;
        }
    }

    class MakeFriend : Card
    {
        public override string Name => "Make a Friend";
        public override string Reward => "3 Quality Points and 1 Chip of his choice";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 12, 15 };

        public override bool Play(Player player)
        {
            if (player.IntegrityChips >= 2)
            {
                player.QualityPoints += 3;
                player.GetAChipOfHisChoice();
                return true;
            }
            player.DiscardCard();
            return false;
        }
    }

    class EnjoyingNature : Card
    {
        public override string Name => "Enjoying Nature";
        public override string Reward => "1 Craft Chip";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 0, 1, 2, 3, 4, 5, 7, 8, 9, 10 };

        public override bool Play(Player player)
        {
            player.CraftChips++;
            player.Position = 20;
            return true;
        }
    }

    class StudentParking : Card
    {
        public override string Name => "Student Parking";
        public override string Reward => "1 Craft Chip";
        public override int Year => 1;
        public override int[] CorrectRooms => new[] { 2 };

        public override bool Play(Player player)
        {
            player.CraftChips++;
            player.Position = 20;
            return true;
        }
    }

    class LbsuVsUci : Card
    {
        public override string Name => "LBSU vs UCI";
        public override string Reward => "1 Chip of his choice";
        public override int Year => 2;
        public override int[] CorrectRooms => new[] { 3 };

        public override bool Play(Player player)
        {
            player.GetAChipOfHisChoice();
            return true;
        }
    }

    class CarPool : Card
    {
        public override string Name => "Car Pool";
        public override string Reward => "3 Quality Points and 1 Game Card";
        public override int Year => 2;
        public override int[] CorrectRooms => new[] { 2, 6 };

        public override bool Play(Player player)
        {
            if (player.IntegrityChips >= 5)
            {
                player.QualityPoints += 3;
                player.DrawCard();
                return true;
            }
            player.QualityPoints -= 2;
            return false;
        }
    }

    class Cecs274 : Card
    {
        public override string Name => "CECS 274";
        public override string Reward => "5 Quality Points and 1 Game Card";
        public override int Year => 2;
        public override int[] CorrectRooms => new[] { 11, 14, 17 };

        public override bool Play(Player player)
        {
            if (player.LearningChips >= 7)
            {
                player.QualityPoints += 5;
                player.DrawCard();
                return true;
            }
            player.QualityPoints -= 3;
            return false;
        }
    }

    class Cecs201 : Card
    {
        public override string Name => "CECS 201";
        public override string Reward => "1 Learning, 1 Craft and 1 Integrity Chips";
        public override int Year => 2;
        public override int[] CorrectRooms => new[] { 11, 14, 17 };

        public override bool Play(Player player)
        {
            if (player.CraftChips >= 8)
            {
                player.LearningChips++;
                player.CraftChips++;
                player.IntegrityChips++;
                return true;
            }
            player.QualityPoints -= 3;
            player.DiscardCard();
            return false;
        }
    }

    class Engl317 : Card
    {
        public override string Name => "ENGL 317";
        public override string Reward => "5 Quality Points";
        public override int Year => 2;
        public override int[] CorrectRooms => new[] { 8 };

        public override bool Play(Player player)
        {
            if (player.CraftChips >= 6)
            {
                player.QualityPoints += 5;
                return true;
            }
            player.Position = 2;
            return false;
        }
    }

    class Phys152 : Card
    {
        public override string Name => "PHYS 152";
        public override string Reward => "5 Quality Points and a Chip of his choice";
        public override int Year => 2;
        public override int[] CorrectRooms => new[] { 7, 8 };

        public override bool Play(Player player)
        {
            if (player.IntegrityChips >= 7)
            {
                player.QualityPoints += 5;
                player.GetAChipOfHisChoice();
                return true;
            }
            player.DiscardCard();
            return false;
        }
    }

    class Phil270 : Card
    {
        public override string Name => "PHIL 270";
        public override string Reward => "3 Quality Points and 1 Learning Chip";
        public override int Year => 2;
        public override int[] CorrectRooms => new[] { 7, 8 };

        public override bool Play(Player player)
        {
            if (player.IntegrityChips >= 7)
            {
                player.QualityPoints += 3;
                player.LearningChips++;
                return true;
            }
            player.QualityPoints -= 3;
            return false;
        }
    }

    class Cecs228 : Card
    {
        public override string Name => "CECS 228";
        public override string Reward => "5 Quality Points";
        public override int Year => 2;
        public override int[] CorrectRooms => new[] { 11, 14, 17 };

        public override bool Play(Player player)
        {
            if (player.LearningChips >= 8 && player.CraftChips >= 8 && player.IntegrityChips >= 8)
            {
                player.QualityPoints += 5;
                return true;
            }
            player.QualityPoints -= 2;
            player.DiscardCard();
            return false;
        }
    }

    class Cecs277 : Card
    {
        public override string Name => "CECS 277";
        public override string Reward => "5 Quality Points";
        public override int Year => 2;
        public override int[] CorrectRooms => new[] { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        public override bool Play(Player player)
        {
            if (player.LearningChips >= 8 && player.CraftChips >= 8 && player.IntegrityChips >= 8)
            {
                player.QualityPoints += 5;
                return true;
            }
            player.QualityPoints -= 2;
            player.DiscardCard();
            return false;
        }
    }

    class Cecs285 : Card
    {
        public override string Name => "CECS 285";
        public override string Reward => "5 Quality Points and 1 Chip of your choice";
        public override int Year => 2;
        public override int[] CorrectRooms => new[] { 1, 18 };

        public override bool Play(Player player)
        {
            if (player.LearningChips >= 6)
            {
                player.QualityPoints += 5;
                player.GetAChipOfHisChoice();
                return true;
            }
            player.QualityPoints -= 3;
            return false;
        }
    }

    class Cecs282 : Card
    {
        public override string Name => "CECS 282";
        public override string Reward => "5 Quality Points";
        public override int Year => 2;
        public override int[] CorrectRooms => new[] { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        public override bool Play(Player player)
        {
            if (player.LearningChips >= 8 && player.CraftChips >= 8 && player.IntegrityChips >= 8)
            {
                player.QualityPoints += 5;
                return true;
            }
            player.QualityPoints -= 2;
            player.DiscardCard();
            return false;
        }
    }

    class HaveASwim : Card
    {
        public override string Name => "Have a Swim";
        public override string Reward => "1 Chip of your choice";
        public override int Year => 2;
        public override int[] CorrectRooms => new[] { 5 };

        public override bool Play(Player player)
        {
            player.GetAChipOfHisChoice();
            return true;
        }
    }
}
