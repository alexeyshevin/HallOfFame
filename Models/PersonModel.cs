namespace HallOfFame.Models
{
    public class PersonModel
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string DisplayName { get; set; }
        public required SkillModel[] Skills { get; set; }
    }
}