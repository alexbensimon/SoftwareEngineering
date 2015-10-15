namespace SoftwareEngineeringProject
{
    public class Player
    {
        public string Name { get; set; }

        // The position of the player is a room id.
        public int Position { get; set; }

        // We wil use quality points later.
        //public int QualityPoints { get; set; }

        public int LearningChips { get; set; }
        public int CraftChips { get; set; }
        public int IntegrityChips { get; set; }
    }
}
