namespace HallOfFame.Models
{
    public class SkillModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public byte Level { get; set; }
    }
}