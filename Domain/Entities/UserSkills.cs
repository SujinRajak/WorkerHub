namespace Domain.Entities
{
    public class UserSkills
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public string Skill { get; set; }
        public int SkillPercent { get; set; }
        public string Description { get; set; }

    }
}
